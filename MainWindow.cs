// 
// PreferencesWin.cs
//  
// Author:
//       Giannis Skoulis
//       Thanos Papathanasiou
// 
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
using Gnome;

public partial class MainWindow: Gtk.Window
{	
	Preferences prefs = new Preferences();
	delegate GoogleAPI.GoogleResponse Searcher();
	GoogleWebSearch websearch;
	int page = 0;
	
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
		about.Version = "0.1.0";
		about.Copyright = "(c) Giannis Skoulis  Thanos Papathanasiou";
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
		
		if (prefs.pStatus == "system") {
			websearch = new GoogleWebSearch(query.ToString(), prefs.resultsSize, prefs.hostLang,
			                                    prefs.safe, prefs.resultsWritenInLang, prefs.filter,
			                                    prefs.systemProxy);
		}
		else if (prefs.pStatus == "manual"){
			websearch = new GoogleWebSearch(query.ToString(), prefs.resultsSize, prefs.hostLang,
		                                        prefs.safe, prefs.resultsWritenInLang, prefs.filter,
		                                        prefs.userProxy);
		}
		else {
			websearch = new GoogleWebSearch(query.ToString(), prefs.resultsSize, prefs.hostLang,
		                                        prefs.safe, prefs.resultsWritenInLang, prefs.filter);
		}
		
		Searcher sr = new Searcher(websearch.Search);
		AsyncCallback ac = new AsyncCallback(DrawResults);
		IAsyncResult res = sr.BeginInvoke (ac, 123456789);
	}
	
	protected void DrawResults(IAsyncResult ar)
	{
		Searcher sr = (Searcher) ((AsyncResult) ar).AsyncDelegate;
		
		Gdk.Threads.Enter();
		GoogleAPI.GoogleResponse testResponce = sr.EndInvoke (ar);
		Gdk.Threads.Leave();
		
		if (testResponce.responseStatus != "200") {
			MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error, 
			                                     ButtonsType.Close, testResponce.responseDetails);
			md.Run();
			md.Destroy();
		}
		else if (testResponce.responseData.results.Capacity == 0){
			MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Info, 
			                                     ButtonsType.Close, "Nothing found!!\nTry again.");
			md.Run();
			md.Destroy();
		}
		else {
			result5Box.Visible = false;
			result6Box.Visible = false;
			result7Box.Visible = false;
			result8Box.Visible = false;
			
			resultsNumber.Markup = "Estimated results <b>" + testResponce.responseData.cursor.estimatedResultCount + "</b>";
			
			string res = "\n";
			res += testResponce.responseData.results[0].title + "\n";
			res += testResponce.responseData.results[0].content.Replace("&middot","-");
			result1.Markup = res;
			result1Button.Label = testResponce.responseData.results[0].unescapedUrl;
			result1Button.Visible = true;
			
			res += "\n" + testResponce.responseData.results[1].title + "\n";
			res += testResponce.responseData.results[1].content.Replace("&middot","-") + "\n";
			result2.Markup = res;
			result2Button.Label = testResponce.responseData.results[1].unescapedUrl;
			result2Button.Visible = true;
			
			res += testResponce.responseData.results[2].title + "\n";
			res += testResponce.responseData.results[2].content.Replace("&middot","-") + "\n";
			result3.Markup = res;
			result3Button.Label = testResponce.responseData.results[2].unescapedUrl;
			result3Button.Visible = true;
			
			res += testResponce.responseData.results[3].title + "\n";
			res += testResponce.responseData.results[3].content.Replace("&middot","-") + "\n";
			result4.Markup = res;
			result4Button.Label = testResponce.responseData.results[3].unescapedUrl;
			result4Button.Visible = true;
			
			if (prefs.resultsSize == "large") {
				resultBox.ShowAll();
				
				res += testResponce.responseData.results[4].title + "\n";
				res += testResponce.responseData.results[4].content.Replace("&middot","-") + "\n";
				result5.Markup = res;
				result5Button.Label = testResponce.responseData.results[4].unescapedUrl;
				result5Button.Visible = true;
				
				res += testResponce.responseData.results[5].title + "\n";
				res += testResponce.responseData.results[5].content.Replace("&middot","-") + "\n";
				result6.Markup = res;
				result6Button.Label = testResponce.responseData.results[5].unescapedUrl;
				result6Button.Visible = true;
				
				res += testResponce.responseData.results[6].title + "\n";
				res += testResponce.responseData.results[6].content.Replace("&middot","-") + "\n";
				result7.Markup = res;
				result7Button.Label = testResponce.responseData.results[6].unescapedUrl;
				result7Button.Visible = true;
				
				res += testResponce.responseData.results[7].title + "\n";
				res += testResponce.responseData.results[7].content.Replace("&middot","-") + "\n";
				result8.Markup = res;
				result8Button.Label = testResponce.responseData.results[7].unescapedUrl;
				result8Button.Visible = true;
			}
		}
	}

	protected virtual void OnPrevPageClicked (object sender, System.EventArgs e)
	{
		if (page > 0){
			page--;
			Searcher sr = new Searcher(websearch.PrevPage);
			AsyncCallback ac = new AsyncCallback(DrawResults);
			IAsyncResult res = sr.BeginInvoke (ac, 123456789);
		}
	}

	protected virtual void OnNextPageClicked (object sender, System.EventArgs e)
	{
		page++;
		Searcher sr = new Searcher(websearch.NextPage);
		AsyncCallback ac = new AsyncCallback(DrawResults);
		IAsyncResult res = sr.BeginInvoke (ac, 123456789);
	}
	
	protected virtual void OnLinkClick (object sender, System.EventArgs e)
	{
		Button bt = (Button) sender;
		Url.Show(bt.Label);
	}
}