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
using System.Threading;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Generic;
using JsonExSerializer;


namespace Monogle
{
	public class GoogleAPI
	{
		private string version;
		private string query;
		private string resultsSize;
		private string hostLang;
		private string APIkey;
		private bool useProxy;
		private WebProxy proxy;
		protected StringBuilder URL;
		protected StringBuilder subURL;
		protected string JSON;
		
		public class GooglePage
		{
			public string start;
			public string label;
		}
		
		public class GoogleCursor
		{
			public List<GooglePage> pages;
			public string estimatedResultCount;
			public string currentPageIndex;
			public string moreResultsUrl;
		}
		
		public class GoogleSearchResult
		{
			public string GsearchResultClass;
			public string unescapedUrl;
			public string url;
			public string visibleUrl;
			public string cacheUrl;
			public string title;
			public string titleNoFormatting;
			public string content;
		}
		
		public class GoogleResponseData
		{
			public List<GoogleSearchResult> results;
			public GoogleCursor cursor;
		}
		
		public class GoogleResponse
		{
			public GoogleResponseData responseData;
			public string responseDetails;
			public string responseStatus;
		}
		
		public GoogleAPI(string q, string rsz, string hl)
		{
			useProxy = false;
			this.Constructor(q, rsz, hl);
		}
		
		public GoogleAPI(string q, string rsz, string hl, WebProxy p)
		{
			this.useProxy = true;
			this.proxy = p;
			this.Constructor(q, rsz, hl);
		}
		
		public void Constructor(string q, string rsz, string hl)
		{
			string g = "&";
			this.version = "v=1.0&";
			this.query = "q=" + q + g;
			this.resultsSize = "rsz=" + rsz + g;
			this.hostLang = "hl=" + hl +g;
			this.APIkey = "key=ABQIAAAAfVDCgLjQaekBZYnvF3E7VxQ88Z8YDRFL8VAjDU7Tor2kkw5kaBQUsGM7NZDR-ejmoKN4FAXGv3gu7A&";
			this.subURL = new StringBuilder();
			this.subURL.Append(this.version);
			this.subURL.Append(this.query);
			this.subURL.Append(this.resultsSize);
			this.subURL.Append(this.hostLang);
			this.subURL.Append(this.APIkey);
		}
		
		public void baseURL()
		{
			this.URL = new StringBuilder();
			this.URL.Append("http://ajax.googleapis.com/ajax/services/search/");
		}
		
		public void getRequest()
		{	
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL.ToString());
			request.Referer = "http://lera.gr";
			request.Timeout = 10000;
			if (useProxy) {
				request.Proxy = proxy;
			}
			try {
				HttpWebResponse response = (HttpWebResponse) request.GetResponse();
				Stream receiveStream = response.GetResponseStream();
				StreamReader readStream = new StreamReader (receiveStream); // TODO  Encoding
				JSON = readStream.ReadToEnd();
				receiveStream.Close();
				readStream.Close();
				response.Close ();
			}
			catch(WebException e) {
				Console.WriteLine(e);
			}
		}
		
		public GoogleResponse Serealize(string jsonString)
		{
			Serializer serializer = new Serializer(typeof(GoogleResponse));
			GoogleResponse response = (GoogleResponse) serializer.Deserialize(jsonString);
			return response;
		}
	}
	
	public class GoogleWebSearch : GoogleAPI
	{
		private string type = "web";
		private string safetyLevel;
		private string writenInLang;
		private string filter;
		private string start;
		private int size;
		private int page;
		public GoogleResponse result;
		
		public GoogleWebSearch(string q, string rsz, string hl, string safe,
		                       string ls, string filtr) :base(q, rsz, hl)
		{
			this.Constructor(q, rsz, hl, safe, ls, filtr);
		}
		
		public GoogleWebSearch(string q, string rsz, string hl, string safe,
		                       string ls, string filtr, WebProxy pr) :base(q, rsz, hl, pr)
		{
			this.Constructor(q, rsz, hl, safe, ls, filtr);
		}
		
		private void Constructor(string q, string rsz, string hl, string safe,
		                         string ls, string filtr)
		{
			string g = "&";
			if (rsz == "small") {
				size = 4;
			}
			else {
				size = 8;
			}
			page = 0;
			this.safetyLevel = "safe=" + safe +g;
			this.writenInLang = "ls=" + ls + g;
			this.filter = "filter=" + filtr + g;
			this.start = "start=" + page + g;
		}
		
		public void getURL ()
		{
			this.baseURL();
			this.URL.Append(this.type);
			this.URL.Append("?");
			this.URL.Append(this.subURL);
			this.URL.Append(this.safetyLevel);
			this.URL.Append(this.writenInLang);
			this.URL.Append(this.filter);
			this.URL.Append(this.start);
		}

		public GoogleResponse Search()
		{
			this.getURL();
			this.getRequest();
			return this.Serealize(JSON);
		}
		
		public GoogleResponse NextPage()
		{
			this.page += size;
			this.start = "start=" + this.page.ToString() + "&";
			return Search();
		}
	}
}
