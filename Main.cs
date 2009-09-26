using System;
using Gtk;

namespace Monogle{
	
	class MainClass	{
		
		public static void Main (string[] args){
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			
			GoogleWebSearch gweb = new GoogleWebSearch("google", "small", "el", "", "", "", "");
			GoogleAPI.GoogleResponse result = gweb.Search();
		}
	}
}