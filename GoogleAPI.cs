
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Generic;
using JsonExSerializer;


namespace Monogle{
	
	public class GoogleAPI{
		
		private string version { get; set; }
		private string query { get; set; }
		private string resultsSize { get; set; }
		private string hostLang {get; set; }
		private string APIkey { get; set; }
		private string page { get; set; }
		protected StringBuilder URL;
		protected StringBuilder subURL;
		
		public class GooglePage{
			
			public string start;
			public string label;
		}
		
		public class GoogleCursor{
			
			public List<GooglePage> pages;
			public string estimatedResultCount;
			public string currentPageIndex;
			public string moreResultsUrl;
		}
		
		public class GoogleSearchResult{
			
			public string GsearchResultClass;
			public string unescapedUrl;
			public string url;
			public string visibleUrl;
			public string cacheUrl;
			public string title;
			public string titleNoFormatting;
			public string content;
		}
		
		public class GoogleResponseData{
			
			public List<GoogleSearchResult> results;
			public GoogleCursor cursor;
		}
		
		public class GoogleResponse{
			
			public GoogleResponseData responseData;
			public string responseDetails;
			public string responseStatus;
		}
		
		public GoogleAPI(string q, string rsz, string hl, string start){
			
			string g = "&";
			this.version = "v=1.0&";
			this.query = "q=" + q + g;
			this.resultsSize = "rsz=" + rsz + g;
			this.hostLang = "hl=" + hl +g;
			this.APIkey = "key=ABQIAAAAfVDCgLjQaekBZYnvF3E7VxQ88Z8YDRFL8VAjDU7Tor2kkw5kaBQUsGM7NZDR-ejmoKN4FAXGv3gu7A&";
			this.page = "start=" + start + g;
			this.subURL = new StringBuilder();
			this.subURL.Append(this.version);
			this.subURL.Append(this.query);
			this.subURL.Append(this.resultsSize);
			this.subURL.Append(this.hostLang);
			this.subURL.Append(this.APIkey);
			this.subURL.Append(this.page);
		}
		
		public void baseURL(){
			
			this.URL = new StringBuilder();
			this.URL.Append("http://ajax.googleapis.com/ajax/services/search/");
		}
		
		public string getRequest(){
			
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL.ToString());
			request.Referer = "http://lera.gr";
			request.Timeout = 10000;
			try{
				HttpWebResponse response = (HttpWebResponse) request.GetResponse();
				Stream receiveStream = response.GetResponseStream();
				StreamReader readStream = new StreamReader (receiveStream); // TODO  Encoding
				string JSON = readStream.ReadToEnd();
				receiveStream.Close();
				readStream.Close();
				response.Close ();
				return JSON;
			}
			catch(WebException ex){
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		
		public GoogleResponse Serealize(string jsonString){
			
			Serializer serializer = new Serializer(typeof(GoogleResponse));
			GoogleResponse response = (GoogleResponse) serializer.Deserialize(jsonString);
			return response;
		}
	}
	
	public class GoogleWebSearch : GoogleAPI{
		
		private string type = "web";
		private string safetyLevel;
		private string writenInLang;
		private string filter;
		
		public GoogleWebSearch(string q, string rsz, string hl, string start, string safe, string ls, string filtr) :base(q, rsz, hl, start){
			
			string g = "&";
			this.safetyLevel = "safe=" + safe +g;
			this.writenInLang = "ls=" + ls + g;
			this.filter = "filter=" + filtr + g;
		}
		
		public void getURL (){
			
			this.baseURL();
			this.URL.Append(this.type);
			this.URL.Append("?");
			this.URL.Append(this.subURL);
			this.URL.Append(this.safetyLevel);
			this.URL.Append(this.writenInLang);
			this.URL.Append(this.filter);
		}
		
		public GoogleResponse Search(){
			
			this.getURL();
			GoogleResponse result = this.Serealize(this.getRequest());
			return result;
		}
	}
}
