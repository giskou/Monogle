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
using Monogle;

public partial class PreferencesWin : Gtk.Window
{
	Preferences pr;
	
	public PreferencesWin(Preferences prefs) :base(Gtk.WindowType.Toplevel)
	{
		pr = prefs;
		this.Build();
		proxyEntry.Text = pr.proxy;
		portSpinButton.Value = pr.proxyPort;
		switch(pr.pStatus) {
			case "no":
				noProxyRadioButton.Click();
				break;
			case "system":
				systemProxyRadioButton.Click();
				break;
			case "manual":
				manualProxyRadioButton.Click();
				break;
		}
	}

	protected virtual void OnClose (object sender, System.EventArgs e)
	{
		this.Destroy();
	}

	protected virtual void OnTonggle (object sender, System.EventArgs e)
	{
		if (manualProxyBox.Sensitive == false) manualProxyBox.Sensitive = true;
		else manualProxyBox.Sensitive = false;
	}

	protected virtual void OnNoProxy (object sender, System.EventArgs e)
	{
		pr.pStatus = "no";
	}

	protected virtual void OnSystemProxy (object sender, System.EventArgs e)
	{
		pr.pStatus = "system";
	}

	protected virtual void OnManualProxy (object sender, System.EventArgs e)
	{
		pr.pStatus = "manual";
	}

	protected virtual void OnProxyChange (object sender, System.EventArgs e)
	{
		pr.proxy = proxyEntry.Text;
	}

	protected virtual void OnProxyPortChange (object sender, System.EventArgs e)
	{
		pr.proxyPort = portSpinButton.ValueAsInt;
	}
}

