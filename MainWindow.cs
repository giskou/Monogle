// 
// PreferencesWin.cs
//  
// Author:
//       Giannis Skoulis <giskou@gmail.com>
// 
// Copyright (c) 2009 Giannis Skoulis
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Text;
using System.Net;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.IO;
using Gtk;
using Gdk;
using Pango;
using Monogle;
using Microsoft.JScript;

public partial class MainWindow: Gtk.Window
{	
	Preferences prefs = new Preferences();
	delegate GoogleAPI.GoogleResponse Searcher();
	int width, height;
	TextBuffer text;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.GetSize(out width , out height);
		text = resultsView.Buffer;
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
		about.License = @" Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the """"Software""""), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED """"AS IS"""", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.";
		about.Run();
		about.Destroy();
	}

	protected virtual void OnPreferences (object sender, System.EventArgs e)
	{
		PreferencesWin prefWin = new PreferencesWin(prefs);
		prefWin.Run();
		prefWin.Destroy();
	}

	protected virtual void OnSearch (object sender, System.EventArgs e)
	{
		StringBuilder query = new StringBuilder();
		string search = GlobalObject.escape(searchEntry.Text.Trim());
		string phrase = "\"" + GlobalObject.escape(phraseSearchEntry.Text.Trim()) + "\"";
		string excludes = excludeSearchEntry.Text.Trim();
		string[] parts = excludes.Split(' ');
		StringBuilder ex = new StringBuilder();
		foreach (string s in parts) {
			s.Trim();
			if (s != "") ex.Append(" -" + s);
		}
		
		query.Append(search);
		query.Append(phrase);
		query.Append(GlobalObject.escape(ex.ToString()));
		
		GoogleWebSearch testWebsearch;
		
		
		
		
		if (prefs.pStatus == "system") {
			testWebsearch = new GoogleWebSearch(query.ToString(), prefs.resultsSize, prefs.hostLang,
			                                    prefs.safe, prefs.resultsWritenInLang, prefs.filter,
			                                    prefs.systemProxy);
		}
		else if (prefs.pStatus == "manual"){
			testWebsearch = new GoogleWebSearch(query.ToString(), prefs.resultsSize, prefs.hostLang,
		                                        prefs.safe, prefs.resultsWritenInLang, prefs.filter,
		                                        prefs.userProxy);
		}
		else {
			testWebsearch = new GoogleWebSearch(query.ToString(), prefs.resultsSize, prefs.hostLang,
		                                        prefs.safe, prefs.resultsWritenInLang, prefs.filter);
		}
		
		Searcher sr = new Searcher(testWebsearch.Search);
		AsyncCallback ac = new AsyncCallback(DrawResults);
		IAsyncResult res = sr.BeginInvoke (ac, 123456789);
	}
	
	protected void DrawResults(IAsyncResult ar)
	{
		Searcher sr = (Searcher) ((AsyncResult) ar).AsyncDelegate;
		
		Gdk.Threads.Enter();
		GoogleAPI.GoogleResponse testResponce = sr.EndInvoke (ar);
		Gdk.Threads.Leave();
		
		text.Clear();
		string res = "";
		string temp;
		foreach (GoogleAPI.GoogleSearchResult result in testResponce.responseData.results){
			temp = result.titleNoFormatting.Replace("<b>", "");
			temp = temp.Replace("</b>", "");
			res += temp + "\n";
			
			temp = result.content.Replace("<b>", "");
			temp = temp.Replace("</b>", "");
			res += temp + "\n";
			
			res += result.unescapedUrl + "\n\n";
			
			res += "-------------------------------------------------------------------\n\n";
		}
		text.Text = res;
	}
}