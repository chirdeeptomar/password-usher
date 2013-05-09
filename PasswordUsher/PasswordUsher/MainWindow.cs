using System;
using System.Collections.Generic;
using Gtk;
using PasswordUsher;
using PasswordUsher.Domain.Entities;
using PasswordUsher.Service.Impl;
using PasswordUsher.Service.Contracts;
using Ninject;

public partial class MainWindow: Gtk.Window
{	
	IKernel kernel;
	IEnumerable<Provider> Providers;
	ListStore providerListStore;
	IProviderService providerService;
	IAccountService accountService;
	TreeStore accountStore;
	
	public delegate void ProviderAddedDelegate ();

	public event ProviderAddedDelegate ProviderAddedEvent;
		
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{	
		kernel = new StandardKernel (new ServiceModule ());
		
		providerService = kernel.Get<IProviderService> ();
		accountService = kernel.Get<IAccountService> ();

		Build ();		
		Initialise ();	
		CreateTreeViewUi ();
		ProviderAddedEvent += new ProviderAddedDelegate (Initialise);

	}
	
	#region Initialisation

	public void Initialise ()
	{				
		Providers = providerService.GetProviders ();
		BindProviderTree ();
		BindProviderCombobox ();			
	}

	#endregion
	
	#region Control Bindings

	void CreateTreeViewUi ()
	{
		Gtk.TreeViewColumn accountColumn = new Gtk.TreeViewColumn ();
		accountColumn.Title = "Accounts";
		
		Gtk.CellRendererText accountNameCell = new Gtk.CellRendererText ();
		
		accountColumn.PackStart (accountNameCell, true);
		
		TreeviewAccounts.AppendColumn (accountColumn);		
		
		accountColumn.AddAttribute (accountNameCell, "text", 0);
	}

	public void BindProviderTree ()
	{	
		accountStore = new TreeStore (typeof(string), typeof(Int64));
		
		foreach (var provider in Providers) {
			TreeIter iter = accountStore.AppendValues (provider.Name);	
			var accounts = accountService.GetByProvider (provider.Id);			
			foreach (var account in accounts) {
				accountStore.AppendValues (iter, account.Name, account.Id);
			}
		}	
		
		TreeviewAccounts.Model = accountStore;	
		TreeviewAccounts.ButtonPressEvent += new ButtonPressEventHandler (OnItemButtonPressed);
	}

	void BindProviderCombobox ()
	{
		providerListStore = new ListStore (typeof(string), typeof(Int64));		
		ProviderCombobox.Model = providerListStore;
				
		foreach (var item in Providers) {
			providerListStore.AppendValues (item.Name, item.Id);
		}		
		
		TreeIter iter;
		if (providerListStore.GetIterFirst (out iter)) {
			ProviderCombobox.SetActiveIter (iter);
		} 
	}

	#endregion
			
	#region Events
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnAbout (object sender, System.EventArgs e)
	{
		AboutDialog dialog = new AboutDialog ();

		dialog.ProgramName = "Password Usher";
		dialog.Version = "0.0.1";
		dialog.Comments = "A password manager utility";
		dialog.Authors = new string [] {"Chirdeep Tomar"};
		dialog.Website = "https://github.com/chirdeeptomar/password-usher";

		dialog.Run ();
		dialog.Destroy ();
	}
		
	protected void AddProvider (object sender, System.EventArgs e)
	{
		AddProviderWindow providerWindow = new AddProviderWindow (ProviderAddedEvent, providerService);		
		providerWindow.Show ();		
	}

	protected void ApplicationQuit (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	protected void ResetAccount (object sender, System.EventArgs e)
	{
		EntryAccountName.Text = EntryPassword.Text = string.Empty;		 
	}

	protected void ShowPassword (object sender, System.EventArgs e)
	{
		EntryPassword.Visibility = CheckbuttonShowPassword.Active;		
	}
	
	protected void EnableSaveAndCancel (object sender, System.EventArgs e)
	{
		ButtonSave.Sensitive = EntryAccountName.Text.Length > 0 && EntryPassword.Text.Length > 0;
		ButtonCancel.Sensitive = EntryAccountName.Text.Length > 0 || EntryPassword.Text.Length > 0;
	}
	
	long GetProviderId ()
	{
		TreeIter activeIter;
		Int64 providerId = 0;
		if (ProviderCombobox.GetActiveIter (out activeIter)) {
			providerId = (Int64)providerListStore.GetValue (activeIter, 1);
		}
		return providerId;
	}

	protected void SaveAccount (object sender, System.EventArgs e)
	{
		try {
			
			var account = new Account{ 
							Name = EntryAccountName.Text.Trim (),
							Password = EntryPassword.Text.Trim (),
							ProviderId = GetProviderId ()
							};
							
			accountService.SaveAccount (account);
			ResetAccount (this, null);
			Initialise ();
		} catch (Exception ex) {
			MessageDialog dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Cancel, ex.Message); 				
			dialog.Run ();
			dialog.Destroy ();
		}		
	}
	
	[GLib.ConnectBeforeAttribute]
	protected void OnItemButtonPressed (object sender, ButtonPressEventArgs e)
	{
		if (e.Event.Button == 3 && GetSelectedTreeViewItem () != 0) { /* right click */
			Menu m = new Menu ();
			MenuItem deleteItem = new MenuItem ("Delete");
			MenuItem showItem = new MenuItem ("Show");
			deleteItem.ButtonPressEvent += new ButtonPressEventHandler (OnDeleteItemButtonPressed);
			showItem.ButtonPressEvent += new ButtonPressEventHandler (OnShowItemButtonPressed);
			m.Add (showItem);
			m.Add (deleteItem);
			m.ShowAll ();
			m.Popup ();
		}
	}

	protected void OnDeleteItemButtonPressed (object sender, ButtonPressEventArgs e)
	{
		var accountId = GetSelectedTreeViewItem ();
		accountService.DeleteAccount (accountId);
		Initialise ();
	}

	void OnShowItemButtonPressed (object o, ButtonPressEventArgs args)
	{
		var accountId = GetSelectedTreeViewItem ();
		var account = accountService.Get (accountId);
		EntryAccountName.Text = account.Name;
		EntryPassword.Text = account.Password;
	}

	long GetSelectedTreeViewItem ()
	{
		TreeIter activeIter;	
		TreeviewAccounts.Selection.GetSelected (out activeIter);
		var accountId = (Int64)accountStore.GetValue (activeIter, 1);
		return accountId;
	}
	
	#endregion
}
