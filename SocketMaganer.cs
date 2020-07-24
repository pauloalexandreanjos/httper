using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;  
using System.Net.Sockets;  
using System.Text;

namespace httper
{
	class SocketManager
    {
		private static byte[] buffer = new byte[1024];
		
		private static Socket getSocket(string ip, int port)
		{
			IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress,port);
			
			Socket conn = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp );
            
			conn.Connect(remoteEP);
			
            return conn;
		}
	
		public static void Send()
		{
			Send("127.0.0.1", 80);
		}
		
		public static void Send(string ip)
		{
			Send(ip, 80);
		}
		
		public static void Send(string ip, int port)
		{
			try {
				var conn = getSocket(ip, port);
				
				Console.WriteLine("Socket connected to {0}", conn.RemoteEndPoint.ToString());
				
                byte[] msg = Encoding.ASCII.GetBytes(Httper.GetInstance().GetState());
  
                int bytesSent = conn.Send(msg);  
  
                int bytesRec = conn.Receive(buffer);  
                Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(buffer,0,bytesRec));  
				
				Close(conn);
				
			} catch (ArgumentNullException ane) {  
                Console.WriteLine("ArgumentNullException : {0}",ane.ToString());  
            } catch (SocketException se) {  
                Console.WriteLine("SocketException : {0}",se.ToString());  
            } catch (Exception e) {  
                Console.WriteLine("Unexpected exception : {0}", e.ToString());  
            }  
		}
		
		public static void Close(Socket conn)
		{
			conn.Shutdown(SocketShutdown.Both);  
			conn.Close();
		}
    }
}
