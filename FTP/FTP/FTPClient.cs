using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FTP
{
    class FTPClient
    {
        Socket socket = null;
        Socket dataSocket = null;
        byte[] bytes = new byte[1024];
        public FTPClient()
        {
            
        }
        public void Connect(String hostName, int port)
        {
            try {
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                Console.WriteLine(ipHostInfo.AddressList[0]);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEP);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                int bytesRec = socket.Receive(bytes);
                
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            }
            catch { }
            
        }

        public string Send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            socket.Send(msg);
            int bytesRec = socket.Receive(bytes);
            String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Console.WriteLine(response);
            return response;
        }

        public void PassiveMode()
        {
            byte[] msg = Encoding.ASCII.GetBytes("PASV\r\n");
            socket.Send(msg);
            int bytesRec = socket.Receive(bytes);
            String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Console.WriteLine(response);
            response = response.Substring(27);
            response = response.Substring(0, response.Length - 3);
            String[] split = response.Split(',');

            int port = int.Parse(split[4]) * 256 + int.Parse(split[5]);
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            Console.WriteLine(ipHostInfo.AddressList[0]);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dataSocket.Connect(remoteEP);

            
            //int bytesReca = dataSocket.Receive(bytes);
            //String responses = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            //Console.WriteLine(responses);
            //dataSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            
        }
        public void Disconnect()
        {
            socket.Close();
        }
        public List<String> getList()
        {
            PassiveMode();
            byte[] msg = Encoding.ASCII.GetBytes("LIST\r\n");
            socket.Send(msg);
            int bytesRec = dataSocket.Receive(bytes);
            String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Console.WriteLine(response);
            String[] files = response.Split('\n');
            String[] info = files[0].Split(' ');
            List<String> list = new List<string>();
            foreach(String file in files)
            {
                list.Add(file);
            }
            bytesRec = socket.Receive(bytes);
            response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Console.WriteLine(response);
            for (int i = 0; i < info.Length; i++) {
                Console.WriteLine(info[i]);
            }
            return list;
        }
    }
}
