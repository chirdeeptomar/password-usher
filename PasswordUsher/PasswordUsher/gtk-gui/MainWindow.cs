
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action newAction2;
	private global::Gtk.Action newAction3;
	private global::Gtk.Action newAction;
	private global::Gtk.Action newAction1;
	private global::Gtk.Action helpAction;
	private global::Gtk.Action dialogInfoAction;
	private global::Gtk.Action quitAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar3;
	private global::Gtk.Toolbar toolbar3;
	private global::Gtk.HPaned hpaned1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TreeView TreeviewAccounts;
	private global::Gtk.VBox vbox2;
	private global::Gtk.Table table2;
	private global::Gtk.CheckButton CheckbuttonShowPassword;
	private global::Gtk.Entry EntryAccountName;
	private global::Gtk.Entry EntryPassword;
	private global::Gtk.Label LabelAccountName;
	private global::Gtk.Label LabelPassword;
	private global::Gtk.Label LableProviderCombobox;
	private global::Gtk.ComboBox ProviderCombobox;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Fixed fixed1;
	private global::Gtk.Button ButtonCancel;
	private global::Gtk.Button ButtonSave;
	private global::Gtk.Statusbar statusbar;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.newAction2 = new global::Gtk.Action ("newAction2", global::Mono.Unix.Catalog.GetString ("_New Provider"), global::Mono.Unix.Catalog.GetString ("New Provider"), "gtk-new");
		this.newAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("_New Provider");
		w1.Add (this.newAction2, null);
		this.newAction3 = new global::Gtk.Action ("newAction3", global::Mono.Unix.Catalog.GetString ("_New Account"), global::Mono.Unix.Catalog.GetString ("New Account"), "gtk-new");
		this.newAction3.ShortLabel = global::Mono.Unix.Catalog.GetString ("_New Account");
		w1.Add (this.newAction3, null);
		this.newAction = new global::Gtk.Action ("newAction", null, global::Mono.Unix.Catalog.GetString ("New Provider"), "gtk-new");
		w1.Add (this.newAction, "<Primary><Mod2>p");
		this.newAction1 = new global::Gtk.Action ("newAction1", null, global::Mono.Unix.Catalog.GetString ("New Account"), "gtk-new");
		w1.Add (this.newAction1, "<Primary><Mod2>a");
		this.helpAction = new global::Gtk.Action ("helpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, "gtk-help");
		this.helpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
		w1.Add (this.helpAction, null);
		this.dialogInfoAction = new global::Gtk.Action ("dialogInfoAction", global::Mono.Unix.Catalog.GetString ("About"), null, "gtk-dialog-info");
		this.dialogInfoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About");
		w1.Add (this.dialogInfoAction, null);
		this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("_Quit"), null, "gtk-quit");
		this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
		w1.Add (this.quitAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Password Manager");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		this.Gravity = ((global::Gdk.Gravity)(5));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar3'><menu name='FileAction' action='FileAction'><menuitem name='newAction2' action='newAction2'/><menuitem name='newAction3' action='newAction3'/><separator/><menuitem name='quitAction' action='quitAction'/></menu><menu name='helpAction' action='helpAction'><menuitem name='dialogInfoAction' action='dialogInfoAction'/></menu></menubar></ui>");
		this.menubar3 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar3")));
		this.menubar3.Name = "menubar3";
		this.vbox1.Add (this.menubar3);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar3]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar3'><toolitem name='newAction' action='newAction'/><toolitem name='newAction1' action='newAction1'/></toolbar></ui>");
		this.toolbar3 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar3")));
		this.toolbar3.Name = "toolbar3";
		this.toolbar3.ShowArrow = false;
		this.vbox1.Add (this.toolbar3);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar3]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hpaned1 = new global::Gtk.HPaned ();
		this.hpaned1.CanFocus = true;
		this.hpaned1.Name = "hpaned1";
		this.hpaned1.Position = 263;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.TreeviewAccounts = new global::Gtk.TreeView ();
		this.TreeviewAccounts.CanFocus = true;
		this.TreeviewAccounts.Name = "TreeviewAccounts";
		this.GtkScrolledWindow.Add (this.TreeviewAccounts);
		this.hpaned1.Add (this.GtkScrolledWindow);
		global::Gtk.Paned.PanedChild w5 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.GtkScrolledWindow]));
		w5.Resize = false;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.table2 = new global::Gtk.Table (((uint)(3)), ((uint)(3)), false);
		this.table2.Name = "table2";
		this.table2.RowSpacing = ((uint)(6));
		this.table2.ColumnSpacing = ((uint)(6));
		// Container child table2.Gtk.Table+TableChild
		this.CheckbuttonShowPassword = new global::Gtk.CheckButton ();
		this.CheckbuttonShowPassword.CanFocus = true;
		this.CheckbuttonShowPassword.Name = "CheckbuttonShowPassword";
		this.CheckbuttonShowPassword.Label = global::Mono.Unix.Catalog.GetString ("Show Password");
		this.CheckbuttonShowPassword.DrawIndicator = true;
		this.CheckbuttonShowPassword.UseUnderline = true;
		this.table2.Add (this.CheckbuttonShowPassword);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2 [this.CheckbuttonShowPassword]));
		w6.TopAttach = ((uint)(2));
		w6.BottomAttach = ((uint)(3));
		w6.LeftAttach = ((uint)(2));
		w6.RightAttach = ((uint)(3));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.EntryAccountName = new global::Gtk.Entry ();
		this.EntryAccountName.WidthRequest = 300;
		this.EntryAccountName.CanFocus = true;
		this.EntryAccountName.Name = "EntryAccountName";
		this.EntryAccountName.IsEditable = true;
		this.EntryAccountName.InvisibleChar = '•';
		this.table2.Add (this.EntryAccountName);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2 [this.EntryAccountName]));
		w7.TopAttach = ((uint)(1));
		w7.BottomAttach = ((uint)(2));
		w7.LeftAttach = ((uint)(1));
		w7.RightAttach = ((uint)(2));
		w7.XOptions = ((global::Gtk.AttachOptions)(4));
		w7.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.EntryPassword = new global::Gtk.Entry ();
		this.EntryPassword.WidthRequest = 300;
		this.EntryPassword.CanFocus = true;
		this.EntryPassword.Name = "EntryPassword";
		this.EntryPassword.IsEditable = true;
		this.EntryPassword.Visibility = false;
		this.EntryPassword.InvisibleChar = '•';
		this.table2.Add (this.EntryPassword);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table2 [this.EntryPassword]));
		w8.TopAttach = ((uint)(2));
		w8.BottomAttach = ((uint)(3));
		w8.LeftAttach = ((uint)(1));
		w8.RightAttach = ((uint)(2));
		w8.XOptions = ((global::Gtk.AttachOptions)(4));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.LabelAccountName = new global::Gtk.Label ();
		this.LabelAccountName.Name = "LabelAccountName";
		this.LabelAccountName.Xalign = 0F;
		this.LabelAccountName.LabelProp = global::Mono.Unix.Catalog.GetString ("Account Name:");
		this.table2.Add (this.LabelAccountName);
		global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table2 [this.LabelAccountName]));
		w9.TopAttach = ((uint)(1));
		w9.BottomAttach = ((uint)(2));
		w9.XOptions = ((global::Gtk.AttachOptions)(4));
		w9.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.LabelPassword = new global::Gtk.Label ();
		this.LabelPassword.Name = "LabelPassword";
		this.LabelPassword.Xalign = 0F;
		this.LabelPassword.LabelProp = global::Mono.Unix.Catalog.GetString ("Password:");
		this.table2.Add (this.LabelPassword);
		global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2 [this.LabelPassword]));
		w10.TopAttach = ((uint)(2));
		w10.BottomAttach = ((uint)(3));
		w10.XOptions = ((global::Gtk.AttachOptions)(4));
		w10.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.LableProviderCombobox = new global::Gtk.Label ();
		this.LableProviderCombobox.Name = "LableProviderCombobox";
		this.LableProviderCombobox.Xalign = 0F;
		this.LableProviderCombobox.LabelProp = global::Mono.Unix.Catalog.GetString ("Please select a Provider:");
		this.table2.Add (this.LableProviderCombobox);
		global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table2 [this.LableProviderCombobox]));
		w11.XOptions = ((global::Gtk.AttachOptions)(4));
		w11.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.ProviderCombobox = global::Gtk.ComboBox.NewText ();
		this.ProviderCombobox.Name = "ProviderCombobox";
		this.table2.Add (this.ProviderCombobox);
		global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table2 [this.ProviderCombobox]));
		w12.LeftAttach = ((uint)(1));
		w12.RightAttach = ((uint)(2));
		w12.XOptions = ((global::Gtk.AttachOptions)(4));
		w12.YOptions = ((global::Gtk.AttachOptions)(4));
		this.vbox2.Add (this.table2);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table2]));
		w13.Position = 0;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		this.hbox1.Add (this.fixed1);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.fixed1]));
		w14.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.ButtonCancel = new global::Gtk.Button ();
		this.ButtonCancel.WidthRequest = 100;
		this.ButtonCancel.Sensitive = false;
		this.ButtonCancel.CanFocus = true;
		this.ButtonCancel.Name = "ButtonCancel";
		this.ButtonCancel.UseUnderline = true;
		this.ButtonCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancel");
		this.hbox1.Add (this.ButtonCancel);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.ButtonCancel]));
		w15.Position = 1;
		w15.Expand = false;
		w15.Fill = false;
		w15.Padding = ((uint)(5));
		// Container child hbox1.Gtk.Box+BoxChild
		this.ButtonSave = new global::Gtk.Button ();
		this.ButtonSave.WidthRequest = 100;
		this.ButtonSave.Sensitive = false;
		this.ButtonSave.CanFocus = true;
		this.ButtonSave.Name = "ButtonSave";
		this.ButtonSave.UseUnderline = true;
		this.ButtonSave.Label = global::Mono.Unix.Catalog.GetString ("Save");
		this.hbox1.Add (this.ButtonSave);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.ButtonSave]));
		w16.Position = 2;
		w16.Expand = false;
		w16.Fill = false;
		w16.Padding = ((uint)(5));
		this.vbox2.Add (this.hbox1);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
		w17.Position = 1;
		w17.Expand = false;
		w17.Fill = false;
		this.hpaned1.Add (this.vbox2);
		this.vbox1.Add (this.hpaned1);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hpaned1]));
		w19.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar = new global::Gtk.Statusbar ();
		this.statusbar.Name = "statusbar";
		this.statusbar.Spacing = 6;
		this.vbox1.Add (this.statusbar);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar]));
		w20.Position = 3;
		w20.Expand = false;
		w20.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 941;
		this.DefaultHeight = 452;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.newAction.Activated += new global::System.EventHandler (this.AddProvider);
		this.dialogInfoAction.Activated += new global::System.EventHandler (this.OnAbout);
		this.quitAction.Activated += new global::System.EventHandler (this.ApplicationQuit);
		this.EntryPassword.Changed += new global::System.EventHandler (this.EnableSaveAndCancel);
		this.EntryAccountName.Changed += new global::System.EventHandler (this.EnableSaveAndCancel);
		this.CheckbuttonShowPassword.Toggled += new global::System.EventHandler (this.ShowPassword);
		this.ButtonCancel.Clicked += new global::System.EventHandler (this.ResetAccount);
		this.ButtonSave.Clicked += new global::System.EventHandler (this.SaveAccount);
	}
}
