using System;
using Gtk;

namespace Monogle{
	
	class MainClass	{
		
		public static void Main (string[] args){
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			
			/*GoogleWebSearch testWebsearch = new GoogleWebSearch("lalaki", "large", "en", "1", "off", " ", "0");
			GoogleAPI.GoogleResponse testResponce = testWebsearch.Search();
			
			foreach (GoogleAPI.GoogleSearchResult result in testResponce.responseData.results){
				Console.Write(result.title + "\n");
				Console.Write(result.content + "\n\n");
			}*/
			
		}
	}
}