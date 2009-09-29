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
using System.Net;
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
		static string KEY_FILTER = KEY_BASE + "/filter";
		static string KEY_SAFE = KEY_BASE + "/safe";
		private string _pStatus;
		private string _proxy;
		private int _proxyPort;
		private string _resultsSize;
		private string _hostLang;
		private string _resultsWritenInLang;
		private string _filter;
		private string _safe;
		private string system_proxy_host;
		private int system_proxy_port;
		private bool system_proxy_auth;
		private string system_proxy_user;
		private string system_proxy_pass;
		private bool system_use_proxy;
		
		public WebProxy systemProxy{
			get {
				if (system_use_proxy){
					try {
						WebProxy myProxy = new WebProxy();
						Uri newUri = new Uri(system_proxy_host + ":" + system_proxy_port);
						myProxy.Address = newUri;
						if (system_proxy_auth) {
							myProxy.Credentials = new NetworkCredential(system_proxy_user,system_proxy_pass);
						}
						return myProxy;
					}
					catch (Exception){
						return null;
					}
				}
				return null;
			}
		}
		public WebProxy userProxy{
			get {
				try {
					WebProxy myProxy = new WebProxy();
					Uri newUri = new Uri(proxy.TrimEnd() + ":" + proxyPort);
					myProxy.Address = newUri;
					return myProxy;
				}
				catch (Exception){
					return null;
				}
			}
		}
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
				client.Set (KEY_RESULTS_LANG, value);
				_resultsWritenInLang = value;
			}
		}
		public string safe
		{
			get{
				return _safe;
			}
			set{
				client.Set (KEY_SAFE, value);
				_safe = value;
			}
		}
		public string filter
		{
			get{
				return _filter;
			}
			set{
				client.Set (KEY_FILTER, value);
				_filter = value;
			}
		}
		
		public Preferences()
		{
			client = new Client();
			GuiFromGconf();
			client.AddNotify(KEY_BASE, new NotifyEventHandler (GConf_Changed));
		}
		
		private void GuiFromGconf()
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
				system_proxy_host = (string) client.Get ("/system/http_proxy/host");
				system_proxy_port = (int) client.Get ("/system/http_proxy/port");
				system_proxy_auth = (bool) client.Get ("/system/http_proxy/use_authentication");
				system_proxy_user = (string) client.Get ("/system/http_proxy/authentication_user");
				system_proxy_pass = (string) client.Get ("/system/http_proxy/authentication_password");
				system_use_proxy = (bool) client.Get ("/system/http_proxy/use_http_proxy");
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
			try {
				hostLang = (string) client.Get (KEY_HOST_LANG);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					hostLang = "en";
				}
				else throw;
			}
			try {
				resultsWritenInLang = (string) client.Get (KEY_RESULTS_LANG);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					resultsWritenInLang = "lang_en";
				}
				else throw;
			}
			try {
				safe = (string) client.Get (KEY_SAFE);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					safe = "moderate";
				}
				else throw;
			}
			try {
				filter = (string) client.Get (KEY_FILTER);
			}
			catch (Exception ex){
				if (ex is NoSuchKeyException || ex is InvalidCastException){
					filter = "0";
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
