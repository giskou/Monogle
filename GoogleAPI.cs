
using System;
using System.Text;
using System.Net;

namespace Monogle
{
	
	public class GoogleAPI{
		
		private string version { get; set; }
		private string query { get; set; }
		private string resultsSize { get; set; }
		private string hostLang {get; set; }
		private string APIkey { get; set; }
		private int page { get; set; }
		private StringBuilder URL;
		
		public class ResponseData{
			
			
		}
		
		public GoogleAPI(string v, string q, string rsz, string hl, string key, int start){
			
			this.version = v;
			this.query = q;
			this.resultsSize = rsz;
			this.hostLang = hl;
			this.APIkey = key;
			this.page = start;
		}
		
		public virtual string createURL(){
			
			return (this.URL.ToString());
		}
		
		public void sendRequest(){
			
			
		}
		
	}
}
