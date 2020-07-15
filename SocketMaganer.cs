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
		
		private static Socket getSocket()
		{
			IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress,80);  
			
			Socket conn = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp );
            
			conn.Connect(remoteEP);
			
            return conn;
		}
	
		public static void Send()
		{
			
			
			try {
				var conn = getSocket();
				
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
