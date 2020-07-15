using System;
using System.Collections;
using System.Collections.Generic;

namespace httper
{
	enum HttpMethods {
		GET,
		POST,
		DELETE,
		PUT
	}
	
    class Httper
    {
		private static Httper instance = null;
		
		private Dictionary<string, string> headers;
		
		public HttpMethods Method { get; set; }
		
		public string location { get; set; }
		
		private const string PROTOCOL = "HTTP/1.1";
		
        private Httper() {
			this.Method = HttpMethods.GET;
			
			this.headers = new Dictionary<string, string>();
			this.SetParam("Host", "localhost");
			this.SetParam("Connection", "keep-alive");
			this.location = "/";
		}
		
		public static Httper GetInstance()
		{
			if (instance == null)
			{
				instance = new Httper();
			}
			
			return instance;
		}
		
		public string GetState()
		{
			string state = "";
			state = state + Method.ToString() + " " + location + " " + PROTOCOL + '\n';
			
			foreach (KeyValuePair<string, string> param in headers)
			{
				state = state + param.Key + ": " + param.Value + '\n';
			}
			
			state = state + '\n';
			
			return state;
		}
		
		public void SetParam(string key, string content)
		{
			headers[key] = content;
		}
		
		public void RemoveParam(string key)
		{
			headers.Remove(key);
		}
    }
}
