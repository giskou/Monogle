using System;
using Gtk;
using Pango;

public partial class MainWindow: Gtk.Window
{	
	Pango.Layout layout; //***********
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		//****************START*******************
		drawingArea.ExposeEvent += Expose_Event; 

		layout = new Pango.Layout(this.PangoContext);
		layout.Width = Pango.Units.FromPixels(600);
		layout.Wrap = Pango.WrapMode.Word;
		layout.Alignment = Pango.Alignment.Left;
		layout.FontDescription = Pango.FontDescription.FromString("Ahafoni CLM Bold 50");
		layout.SetMarkup("<span color=" + (char)34 + "blue" + (char)34 + ">" + "Hello Rad :D" + "</span>");
	 	this.Add(drawingArea);
		//******************END******************
	}
	
	//**************
	void Expose_Event(object obj, ExposeEventArgs args){
		drawingArea.GdkWindow.DrawLayout (drawingArea.Style.TextGC (StateType.Normal), 5, 5, layout);
	}
	//***************
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnQuit (object sender, System.EventArgs e)
	{
		Application.Quit();
	}

	protected virtual void OnAbout (object sender, System.EventArgs e)
	{
		AboutDialog about = new AboutDialog();
		about.ProgramName = "Monogle";
		about.Version = "0.0.1";
		about.Run();
		about.Destroy();
	}
}