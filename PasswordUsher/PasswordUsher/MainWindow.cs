using System;
using System.Collections.Generic;
using Gtk;
using PasswordUsher;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;
using PasswordUsher.Core;

public partial class MainWindow: Gtk.Window
{	
	IEnumerable<Provider> Providers;	
	
	ProviderDataAccess providerData = new ProviderDataAccess ();
	AccountDataAccess accountData = new AccountDataAccess ();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{	
		Build ();		
		Initialise();	
		CreateTreeViewUi ();
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
		foreach (var item in Providers) {
			ProviderCombobox.AppendText (item.Name);
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
		AddProviderWindow providerWindow = new AddProviderWindow();
		providerWindow.Show();
		Initialise();
	}	
	

	protected void ApplicationQuit (object sender, System.EventArgs e)
	{
		Application.Quit();
	}
	
	#endregion
}
