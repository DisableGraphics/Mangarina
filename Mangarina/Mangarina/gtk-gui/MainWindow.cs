
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action OpenAction;

	private global::Gtk.Action CloseAction;

	private global::Gtk.Action HelpAction;

	private global::Gtk.Action TutorialAction;

	private global::Gtk.Action AboutAction;

	private global::Gtk.VBox vbox1;

	private global::Gtk.MenuBar menubar1;

	private global::Gtk.HBox hbox1;

	private global::Gtk.HBox hbox2;

	private global::Gtk.Button button_previous;

	private global::Gtk.Button button_next;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction, null);
		this.OpenAction = new global::Gtk.Action("OpenAction", global::Mono.Unix.Catalog.GetString("Open"), null, null);
		this.OpenAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Open");
		w1.Add(this.OpenAction, null);
		this.CloseAction = new global::Gtk.Action("CloseAction", global::Mono.Unix.Catalog.GetString("Close"), null, null);
		this.CloseAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Close");
		w1.Add(this.CloseAction, null);
		this.HelpAction = new global::Gtk.Action("HelpAction", global::Mono.Unix.Catalog.GetString("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Help");
		w1.Add(this.HelpAction, null);
		this.TutorialAction = new global::Gtk.Action("TutorialAction", global::Mono.Unix.Catalog.GetString("Tutorial"), null, null);
		this.TutorialAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Tutorial");
		w1.Add(this.TutorialAction, null);
		this.AboutAction = new global::Gtk.Action("AboutAction", global::Mono.Unix.Catalog.GetString("About"), null, null);
		this.AboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString("About");
		w1.Add(this.AboutAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Mangarina");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='OpenAction' action='OpenAction'/><menuitem name='CloseAction' action='CloseAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='TutorialAction' action='TutorialAction'/><menuitem name='AboutAction' action='AboutAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add(this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		this.vbox1.Add(this.hbox1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
		w3.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Homogeneous = true;
		this.hbox2.Spacing = 30;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button_previous = new global::Gtk.Button();
		this.button_previous.CanFocus = true;
		this.button_previous.Name = "button_previous";
		this.button_previous.UseUnderline = true;
		this.button_previous.Label = global::Mono.Unix.Catalog.GetString("Previous Chapter");
		this.hbox2.Add(this.button_previous);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button_previous]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button_next = new global::Gtk.Button();
		this.button_next.CanFocus = true;
		this.button_next.Name = "button_next";
		this.button_next.UseUnderline = true;
		this.button_next.Label = global::Mono.Unix.Catalog.GetString("Next Chapter");
		this.hbox2.Add(this.button_next);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button_next]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		this.vbox1.Add(this.hbox2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 444;
		this.DefaultHeight = 483;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.OpenAction.Activated += new global::System.EventHandler(this.Open);
		this.CloseAction.Activated += new global::System.EventHandler(this.Quit);
		this.TutorialAction.Activated += new global::System.EventHandler(this.Tutorial);
		this.AboutAction.Activated += new global::System.EventHandler(this.About);
		this.button_previous.Clicked += new global::System.EventHandler(this.PreviousChapter);
		this.button_next.Clicked += new global::System.EventHandler(this.NextChapter);
	}
}
