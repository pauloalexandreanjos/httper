using System;
using System.Collections;
using System.Collections.Generic;

namespace httper
{
	enum ContentMode
	{
		IGNORE,
		FILE,
		PRINT
	}
	
    class HttpResponse
    {
		private Dictionary<string, string> headers = null;
		private byte[] content;
		private int status { get; set; }
		private ContentMode mode;
		
		public HttpResponse()
		{
			headers = new Dictionary<string, string>();
			content = null;
			status = 0;
			mode = ContentMode.PRINT;
		}
		
		
    }
}
