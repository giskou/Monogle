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

public partial class PreferencesWin : Gtk.Dialog
{
	Preferences pref;
	
	public PreferencesWin(Preferences pr)
	{
		pref = pr;
		this.Build();
		proxyEntry.Text = pref.proxy;
		portSpinButton.Value = pref.proxyPort;
		switch(pref.pStatus) {
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
		if (manualProxyEntryBox.Sensitive == false) manualProxyEntryBox.Sensitive = true;
		else manualProxyEntryBox.Sensitive = false;
	}

	protected virtual void OnNoProxy (object sender, System.EventArgs e)
	{
		pref.pStatus = "no";
	}

	protected virtual void OnSystemProxy (object sender, System.EventArgs e)
	{
		pref.pStatus = "system";
	}

	protected virtual void OnManualProxy (object sender, System.EventArgs e)
	{
		pref.pStatus = "manual";
	}

	protected virtual void OnProxyChange (object sender, System.EventArgs e)
	{
		pref.proxy = proxyEntry.Text;
	}

	protected virtual void OnProxyPortChange (object sender, System.EventArgs e)
	{
		pref.proxyPort = portSpinButton.ValueAsInt;
	}

}

