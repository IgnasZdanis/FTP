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
        public bool connected = false;
        public bool loggedIn = false;
        String hostName;
        Socket socket = null;
        Socket dataSocket = null;
        byte[] bytes = new byte[10000000];
        public FTPClient()
        {
            
        }
        public void Connect(String hostName, int port)
        {
            this.hostName = hostName;
            try {
                IPHostEntry ipHostInfo;
                if (hostName == "localhost")
                {
                    ipHostInfo = Dns.Resolve(Dns.GetHostName());
                }
                else ipHostInfo = Dns.GetHostEntry(hostName);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                Console.WriteLine(ipHostInfo.AddressList[0]);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEP);

                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                connected = true;
                Console.WriteLine(GetResponse(socket));
            }
            catch { }
            
        }

        public string Send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            socket.Send(msg);
            String response = GetResponse(socket);
            //Console.WriteLine("Send response: " + response);
            return response;
        }

        public void PassiveMode()
        {
            String response = Send("PASV\r\n");
            response = response.Substring(response.IndexOf('(') + 1);
            response = response.Substring(0, response.IndexOf(')'));
            String[] split = response.Split(',');

            int port = int.Parse(split[4]) * 256 + int.Parse(split[5]);
            IPHostEntry ipHostInfo;
            if (hostName == "localhost")
            {
                ipHostInfo = Dns.Resolve(Dns.GetHostName());
            }
            else ipHostInfo = Dns.GetHostEntry(hostName);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dataSocket.Connect(remoteEP);
            
        }
        public void Disconnect()
        {
            if (connected) 
                socket.Close();
        }
        public List<String> GetList()
        {
            PassiveMode();

            String response = Send("NLST\r\n");
            Console.WriteLine(response);

            response = GetResponse(dataSocket);
            Console.WriteLine(response);

            String[] files = response.Split('\n');

            List<String> list = new List<string>();
            /*
            foreach(String file in files)
            {
                list.Add(file);
            }
            */
            for(int i=0; i<files.Length-1; i++)
            {
                list.Add(files[i]);
            }
            response = GetResponse(socket);

            return list;
        }

        public string ChangeDirectory(string folderName)
        {
            return Send("CWD " + folderName);
        }

        public void DownloadFile(string fileName, string path)
        {
            PassiveMode();

            Console.WriteLine(fileName);

            byte[] msg = Encoding.ASCII.GetBytes("SIZE " + fileName + "\r\n");
            socket.Send(msg);

            string response = Send("SIZE " + fileName + "\r\n");
            int fileSize = int.Parse(response.Substring(4, response.Length - 5));
            Console.WriteLine(response);

            msg = Encoding.ASCII.GetBytes("RETR " + fileName + "\r\n");
            socket.Send(msg);

            response = GetResponse(socket);
            Console.WriteLine(response);

            byte[] fileBytes = GetResponesByte(dataSocket, fileSize);

            fileName = fileName.Substring(0, fileName.Length - 1);
            String filePath = path + @"\" + fileName;
            File.WriteAllBytes(filePath, fileBytes);

            response = GetResponse(socket);
            Console.WriteLine(response);

        }

        public bool UploadFile(String filepath)
        {
            PassiveMode();

            string file = filepath.Substring(filepath.LastIndexOf('\\') + 1);
            if (!file.Contains("."))
            {
                return false;
            }

            Console.WriteLine(file);
            
            Byte[] msg = Encoding.ASCII.GetBytes("STOR " + file + "\r\n");
            socket.Send(msg);

            Console.WriteLine(GetResponse(socket));
            Console.WriteLine(filepath);
            //String fileName = @"C:\\Users\Ignas\PSI2.rar";
            String fileName = filepath;
            byte[] bytes = System.IO.File.ReadAllBytes(fileName);

            dataSocket.Send(bytes);
            return true;
        }

        public string GetResponse(Socket socket)
        {          
            int bytesReceived;
            StringBuilder sb = new StringBuilder();
            do
            {
                bytesReceived = socket.Receive(bytes, bytes.Length, 0);
                sb.Append(Encoding.ASCII.GetString(bytes, 0, bytesReceived));
            }
            while (bytesReceived == bytes.Length);
            return sb.ToString();
        }
        public byte[] GetResponesByte(Socket socket)
        {
            int i = 0;
            int bytesReceived;
            do
            {
                i++;
                bytesReceived = socket.Receive(bytes, bytes.Length, 0);
                
            }
            while (bytesReceived == bytes.Length);
            Console.WriteLine("i:" + i);
            Console.WriteLine(bytesReceived);
            return bytes;
        }

        public byte[] GetResponesByte(Socket socket, int size)
        {
            int totalBytes = 0;
            int bytesReceived = 0;
            byte[] fileBytes = new byte[size];
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            do
            {
                bytesReceived = socket.Receive(fileBytes, fileBytes.Length, 0);
                totalBytes += bytesReceived;
                Console.WriteLine("Bytes received: " + bytesReceived);
                //writer.Write(fileBytes);
                writer.Write(fileBytes, 0, bytesReceived);
                //Console.WriteLine("i:" + i);
            }
            while (totalBytes != size);
            //Console.WriteLine("i:" + i);
            //Console.WriteLine(bytesReceived);
            return stream.ToArray();
        }

        public void RenameFile(string oldName, string newName)
        {
            Send("RNFR " + oldName + "\r\n");
            Send("RNTO " + newName + "\r\n");
        }

        public bool ResponseSuccesful(String response)
        {
            if (response.Substring(0, 1) == "1") return true;
            if (response.Substring(0, 1) == "2") return true;
            if (response.Substring(0, 1) == "3") return true;
            return false;
        }
    }
}
