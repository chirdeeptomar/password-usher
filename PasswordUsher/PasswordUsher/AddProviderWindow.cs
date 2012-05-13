using System;
using PasswordUsher.Core.Data;
using PasswordUsher.Domain.Entities;
using Gtk;

namespace PasswordUsher
{
	public partial class AddProviderWindow : Gtk.Window
	{
		ProviderDataAccess providerData;
		
		public AddProviderWindow () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			providerData = new ProviderDataAccess();
		}				

		protected void EnableSave (object sender, System.EventArgs e)
		{
			ButtonSaveProvider.Sensitive = EntryProvider.Text.Length > 0;
		}

		protected void SaveProvider (object sender, System.EventArgs e)
		{
		
			try {
				providerData.Insert(new Provider{ Name = EntryProvider.Text.Trim() });	
				this.Destroy();				
			} catch (Exception ex) {				
				MessageDialog dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Cancel, ex.Message); 				
				dialog.Run();
				dialog.Destroy();	
			}			
		}
	}
}
