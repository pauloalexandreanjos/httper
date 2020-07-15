using System;

namespace httper
{
    class Program
    {
        static void Main(string[] args)
        {
			string cmd;
			bool running = true;
			
			while (running) {
				Console.WriteLine();
				Console.Write(Inst().GetState());
				Console.WriteLine("[ COMMANDS: send, set, del, gen, quit ]");
				
				Console.Write("> ");
				cmd = Console.ReadLine();
				
				string[] cmds = cmd.Split(" ");
				
				switch(cmds[0]) {
					case "quit":
						running = false;
						break;
						
					case "set":
						if (cmds.Length < 3) {
							Console.WriteLine("error! usage: set key value");
							break;
						}
						Inst().SetParam(cmds[1], cmds[2]);
						break;
						
					case "del":
						if (cmds.Length < 2) {
							Console.WriteLine("error! usage: del key");
							break;
						}
						Inst().RemoveParam(cmds[1]);
						break;
						
					case "gen":
						if (cmds.Length < 2) {
							Console.WriteLine("error! usage: add-param key value");
							break;
						}
						if (cmds[1] == "user-agent") {
							Inst().SetParam("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36");
						}
						
						break;
						
					case "send":
						SocketManager.Send();
						break;
						
					default:
						break;
				}
			}
        }
		
		// Just a shortcut
		static Httper Inst() {
			return Httper.GetInstance();
		}
    }
	
}
