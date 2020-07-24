using System.Collections;
using System.Collections.Generic;

namespace httper
{
	class CommandList
	{
		private static CommandList instance;
		
		private Dictionary<string, string> aliases;
		
		private CommandList()
		{
			this.cmds = new Dictionary<string, string>();
			
			/*
			st	set Host localhost
			m	mode print
			m	mode file
			l	location /
			l	location /home.html
			l	location /favicon.ico
			st	set Connection keep-alive
			st	set user-agent Mozilla/1.2 Chrome/5.0 Netscape/7.0
			d	del user-agent
			h	host google.com
			p	port 8080
			go	send (go)
			g	gen 
			q	quit
			*/
			
			this.aliases["exit"]="q";
			this.aliases["quit"]="q";
			this.aliases["location"]="l";
			this.aliases["mode"]="m";
			this.aliases["set"]="st";
			this.aliases["del"]="d";
			this.aliases["delete"]="d";
			this.aliases["host"]="qh";
			this.aliases["generate"]="g";
			this.aliases["gen"]="g";
			this.aliases["send"]="go";
		}
		
		public static CommandList GetInstance()
		{
			if(CommandList.instance == null) {
				CommandList.instance = new CommandList();
			}
		}
		
		public static string GetCommandKey(string fullCmdLine)
		{
			string[] cmdPieces = cmd.Split(" ");
		
			return CommandList.GetInstance().aliases[cmdPieces[0]];
		}
	}
}