using System;
using System.Linq;
using System.Collections.Generic;
using Gtk;
using PasswordUsher;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;
using PasswordUsher.Core;

public partial class MainWindow: Gtk.Window
{	
	IEnumerable<Provider> Providers;	
	ListStore providerListStore;
	
	ProviderDataAccess providerData = new ProviderDataAccess ();
	AccountDataAccess accountData = new AccountDataAccess ();
	
	public delegate void ProviderAddedDelegate();

	public event ProviderAddedDelegate ProviderAddedEvent;
		
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{	
		Build ();		
		Initialise();	
		CreateTreeViewUi ();
		ProviderAddedEvent += new ProviderAddedDelegate(Initialise);
	}
	
	#region Initialisation

	public void Initialise ()
	{				
		Providers = providerData.GetAll();
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
		TreeStore accountStore = new TreeStore (typeof (string));
		
		foreach (var provider in Providers) 
		{
			TreeIter iter = accountStore.AppendValues (provider.Name);	
			var accounts = accountData.GetByProvider(provider.Id);			
			foreach (var account in accounts) {
				accountStore.AppendValues (iter, account.Name);
			}
		}	
		
		TreeviewAccounts.Model = accountStore;	
	}

	void BindProviderCombobox ()
	{		
		CellRendererText textRenderer = new CellRendererText ();

		providerListStore = new ListStore(typeof(string), typeof(Int64));		
		ProviderCombobox.Model = providerListStore;
		
		//ProviderCombobox.PackStart (textRenderer, false); 
		ProviderCombobox.AddAttribute (textRenderer, "text", 0);                
		
		foreach (var item in Providers) {
			providerListStore.AppendValues(item.Name, item.Id);
		}		
		
		TreeIter iter;
        if (providerListStore.GetIterFirst (out iter))
        {
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
		AddProviderWindow providerWindow = new AddProviderWindow(ProviderAddedEvent);
		providerWindow.Show();		
	}	

	protected void ApplicationQuit (object sender, System.EventArgs e)
	{
		Application.Quit();
	}
	
	protected void ResetAccount (object sender, System.EventArgs e)
	{
		EntryAccountName.Text = EntryPassword.Text = string.Empty;		 
	}

	protected void ShowPassword (object sender, System.EventArgs e)
	{
		EntryPassword.Visibility =  CheckbuttonShowPassword.Active;		
	}
	
	protected void EnableSaveAndCancel (object sender, System.EventArgs e)
	{
		ButtonSave.Sensitive = EntryAccountName.Text.Length > 0 && EntryPassword.Text.Length > 0;
		ButtonCancel.Sensitive = EntryAccountName.Text.Length > 0 || EntryPassword.Text.Length > 0;
	}		

	protected void SaveAccount (object sender, System.EventArgs e)
	{
		try {
			TreeIter activeIter;
			Int64 providerId = 0;
			if (ProviderCombobox.GetActiveIter (out activeIter)) 
			{
				providerId = (Int64)providerListStore.GetValue (activeIter, 1);
			}
		
			var account = new Account{ 
							Name = EntryAccountName.Text.Trim(),
							Password = EntryPassword.Text.Trim(),
							ProviderId = providerId
							};
							
			accountData.Insert(account);
			ResetAccount(this,null);
			Initialise();
		} catch (Exception ex) {
			MessageDialog dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Cancel, ex.Message); 				
				dialog.Run();
				dialog.Destroy();
		}		
	}
	#endregion
}
