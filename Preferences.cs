// 
// Preferences.cs
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
using GConf;

namespace Monogle
{
	public class Preferences
	{
		public Client client = new Client();
		static string KEY_BASE = "/apps/monogle";
		static string KEY_RESULTS_SIZE = KEY_BASE + "/results_size";
		static string KEY_PROXY_STATUS = KEY_BASE + "/proxy/status";
		static string KEY_PROXY = KEY_BASE + "/proxy/url";
		static string KEY_PROXY_PORT = KEY_BASE + "/proxy/port";
		static string KEY_HOST_LANG = KEY_BASE + "/host_lang";
		static string KEY_RESULTS_LANG = KEY_BASE + "/results_lang";
		private string _pStatus;
		private string _proxy;
		private int _proxyPort;
		private string _resultsSize;
		private string _hostLang;
		private string _resultsWritenInLang;
		
		public string pStatus
		{
			get {
				return _pStatus;
			}
			set {
				client.Set (KEY_PROXY_STATUS, value);
				_pStatus = value;
			}
		}
		public string proxy
		{
			get{
				return _proxy;
			}
			set{
				client.Set (KEY_PROXY, value);
				_proxy = value;
			}
		}
		public int proxyPort
		{
			get{
				return _proxyPort;
			}
			set{
				client.Set (KEY_PROXY_PORT, value);
				_proxyPort = value;
			}
		}
		public string resultsSize
		{
			get{
				return _resultsSize;
			}
			set{
				client.Set (KEY_RESULTS_SIZE, value);
				_resultsSize = value;
			}
		}
		public string hostLang
		{
			get{
				return _hostLang;
			}
			set{
				client.Set (KEY_HOST_LANG, value);
				_hostLang = value;
			}
		}
		public string resultsWritenInLang
		{
			get{
				return _resultsWritenInLang;
			}
			set{
				client.Set (KEY_RESULTS_SIZE, value);
				_resultsSize = value;
			}
		}
		
		public Preferences()
		{
			client = new Client();
			GuiFromGconf();
			client.AddNotify(KEY_BASE, new NotifyEventHandler (GConf_Changed));
		}
		
		void GuiFromGconf()
		{
			try {
				pStatus = (string) client.Get (KEY_PROXY_STATUS);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					pStatus = "no";
				}
				else throw;
			}
			try {
				proxy = (string) client.Get (KEY_PROXY);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					proxy = "";
				}
				else throw;
			}
			try {
				proxyPort = (int) client.Get (KEY_PROXY_PORT);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					proxyPort = 0;
				}
				else throw;
			}
			try {
				resultsSize = (string) client.Get (KEY_RESULTS_SIZE);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					resultsSize = "small";
				}
				else throw;
			}
		}
		
		public void GConf_Changed(object sender, NotifyEventArgs args)
		{
			GuiFromGconf();
		}
	}
}
