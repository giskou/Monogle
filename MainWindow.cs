using System;
using Gtk;
using Pango;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnQuit (object sender, System.EventArgs e)
	{
		Application.Quit();
	}

	protected virtual void OnAbout (object sender, System.EventArgs e)  // TODO  Icon Logo and other stuff
	{
		AboutDialog about = new AboutDialog();
		about.ProgramName = "Monogle";
		about.Version = "0.0.1";
		about.Copyright = "(c) Giannis Skoulis";
		about.Comments = "Google search with Mono";
		about.License = "MIT";
		about.Run();
		about.Destroy();
	}
}