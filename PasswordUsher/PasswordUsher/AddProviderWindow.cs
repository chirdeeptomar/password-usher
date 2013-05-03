using System;
using PasswordUsher.Domain.Entities;
using Gtk;
using PasswordUsher.Service.Contracts;
using PasswordUsher.Service.Impl;

namespace PasswordUsher
{
	public partial class AddProviderWindow : Gtk.Window
	{
		IProviderService providerService;
		public event MainWindow.ProviderAddedDelegate ProviderAddedEvent;
						
		public AddProviderWindow (MainWindow.ProviderAddedDelegate providerAddedEvent, IProviderService service) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			ProviderAddedEvent = providerAddedEvent;
			providerService = service;
		}				

		protected void EnableSave (object sender, System.EventArgs e)
		{
			ButtonSaveProvider.Sensitive = EntryProvider.Text.Length > 0;
		}

		protected void SaveProvider (object sender, System.EventArgs e)
		{
		
			try {
				providerService.AddProvider(new Provider{ Name = EntryProvider.Text.Trim() });
				if (ProviderAddedEvent!=null) 
				{
					ProviderAddedEvent();
				}
						
				this.Destroy();				
			} catch (Exception ex) {				
				MessageDialog dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Cancel, ex.Message); 				
				dialog.Run();
				dialog.Destroy();	
			}			
		}
	}
}
