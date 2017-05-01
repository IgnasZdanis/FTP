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
        Stream stream;
        byte[] bytes = new byte[10000000];
        public FTPClient()
        {
            
        }
        public void Connect(String hostName, int port)
        {
            try {
                //IPHostEntry ipHostInfo = Dns.Resolve(@"ftp://speedtest.tele2.net");
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPHostEntry hostEntry;
                hostEntry = Dns.GetHostEntry("speedtest.tele2.net");
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                //Console.WriteLine(ipHostInfo.AddressList[0]);
                Console.WriteLine(hostEntry.AddressList[0]);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEP);

                

                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                //int bytesReceived = 0;
                //int numberOfLoops = 10000;

                //BinaryReader reader = new BinaryReader(socket.GetStream)

                /*
                using(Stream stream = new NetworkStream(socket, true), bufferedStream = new BufferedStream(stream))
                {
                    Console.WriteLine("NetworkStream {0} seeking.\n",
                    bufferedStream.CanSeek ? "supports" : "does not support");
                    Console.WriteLine("NetworkStream {0} seeking.\n",
                    bufferedStream.CanRead ? "supports" : "does not support");
                    while (bytesReceived < numberOfLoops * bytes.Length)
                    {
                        Console.WriteLine(stream.)
                        bytesReceived += stream.Read(
                            bytes, 0, bytes.Length);
                        Console.WriteLine(bytesReceived);
                    }
                }
                */

                /*
                BufferedStream bufferedStream = new BufferedStream(stream);
                int bytesToRead = bytes.Length;
                while(bytesToRead > 0)
                {
                    
                    int n = bufferedStream.Read(bytes, 0, bytes.Length);
                    Console.WriteLine(n);
                    if (n == 0) break;
                    bytesReceived += n;
                    bytesToRead -= n;
                }

                */
                /*
                int bytesReceived;
                StringBuilder sb = new StringBuilder();
                do
                {
                    bytesReceived = socket.Receive(bytes, bytes.Length, 0);
                    sb.Append(Encoding.ASCII.GetString(bytes, 0, bytesReceived));
                }
                while (bytesReceived == bytes.Length);
                */
                Console.WriteLine(GetResponse(socket));

                //stream = new NetworkStream(socket, true);
                //StreamReader reader = new StreamReader(stream);
                //int bytesReceived = 
                //Console.WriteLine(bytes.Length);
                    //Console.WriteLine(reader.ReadToEnd());
                


                //int bytesReceived = socket.Receive(bytes);

                //Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesReceived));
            }
            catch { }
            
        }

        public string Send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            socket.Send(msg);
            //int bytesRec = stream.Read(bytes, 0, bytes.Length);
            //int bytesRec = socket.Receive(bytes);
            //String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            String response = GetResponse(socket);
            Console.WriteLine("Send response: " + response);
            return response;
        }

        public void PassiveMode()
        {
            /*
            byte[] msg = Encoding.ASCII.GetBytes("PASV\r\n");
            socket.Send(msg);
            int bytesRec = socket.Receive(bytes);
            String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            */
            String response = Send("PASV\r\n");
            //Console.WriteLine(response
            response = response.Substring(27);
            response = response.Substring(0, response.Length - 3);
            //Console.WriteLine(response);
            String[] split = response.Split(',');

            int port = int.Parse(split[4]) * 256 + int.Parse(split[5]);
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            //IPHostEntry ipHostInfo = Dns.GetHostEntry("speedtest.tele2.net");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            //Console.WriteLine(port);
            dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dataSocket.Connect(remoteEP);

            
            //int bytesRec = dataSocket.Receive(bytes);
            //String responses = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            //Console.WriteLine(responses);
            //dataSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            
        }
        public void Disconnect()
        {
            socket.Close();
        }
        public List<String> GetList()
        {
            PassiveMode();
            //Send("TYPE A\r\n");
            
            byte[] msg = Encoding.ASCII.GetBytes("NLST\r\n");
            socket.Send(msg);
            String response = GetResponse(socket);
            Console.WriteLine(response);
            int bytesRec = dataSocket.Receive(bytes);
            response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            //String response = Send("NLST\r\n");
            //Console.WriteLine(response);
            String[] files = response.Split('\n');
            //String[] info = files[0].Split(' ');
            List<String> list = new List<string>();
            foreach(String file in files)
            {
                list.Add(file);
            }
            //bytesRec = socket.Receive(bytes);
            //response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            
            //bytesRec = socket.Receive(bytes);
            //response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            response = GetResponse(socket);
            Console.WriteLine(response);
            return list;
        }

        public void ChangeDirectory(string folderName)
        {
            Send("CWD " + folderName);
        }

        public void DownloadFile(string fileName)
        {
            PassiveMode();

            Console.WriteLine(fileName);

            byte[] msg = Encoding.ASCII.GetBytes("SIZE " + fileName + "\r\n");
            socket.Send(msg);

            

            //int bytesRec = socket.Receive(bytes);
            //string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            string response = GetResponse(socket);
            int fileSize = int.Parse(response.Substring(4, response.Length - 5));
            Console.WriteLine(response);

            //msg = Encoding.ASCII.GetBytes("TYPE I\r\n");
            //socket.Send(msg);
            Console.WriteLine(Send("TYPE I\r\n"));
            //Console.WriteLine(GetResponse());

            msg = Encoding.ASCII.GetBytes("RETR " + fileName + "\r\n");
            socket.Send(msg);

            response = GetResponse(socket);
            Console.WriteLine(response);

            //byte[] fileBytes = new byte[fileSize*2];
            //int bytesRec = dataSocket.Receive(fileBytes);
            //String file = GetResponse(dataSocket);
            //Console.WriteLine(file);
            byte[] fileBytes = GetResponesByte(dataSocket, fileSize);
            //response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            //Console.WriteLine(response);
            //Console.WriteLine(response.Length);
            //FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            //fileStream.Write(bytes, 0, bytes.Length);
            //fileStream.Close();
            /*
            BufferedStream inputStream, outputStream;
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = inputStream.Read(buffer)) > 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
            }
            */
            fileName = fileName.Substring(0, fileName.Length - 1);
            String path = @"C:\\Users\Ignas\" + fileName;
            File.WriteAllBytes(path, fileBytes);

            response = GetResponse(socket);
            Console.WriteLine(response);

        }

        public void UploadFile()
        {
            PassiveMode();

            Byte[] msg = Encoding.ASCII.GetBytes("STOR failas.txt\r\n");
            socket.Send(msg);

            Console.WriteLine(GetResponse(socket));
            String fileName = @"C:\\Users\Ignas\failas.txt";
            dataSocket.SendFile(fileName);
            Console.WriteLine(GetResponse(socket));
            Console.WriteLine(GetResponse(socket));
        }

        public string GetResponse(Socket socket)
        {
            //int bytesRec = socket.Receive(bytes);
            //return Encoding.ASCII.GetString(bytes, 0, bytesRec);
            
            int bytesReceived;
            StringBuilder sb = new StringBuilder();
            int i = 0;
            do
            {
                i++;
                bytesReceived = socket.Receive(bytes, bytes.Length, 0);
                sb.Append(Encoding.ASCII.GetString(bytes, 0, bytesReceived));
                Console.WriteLine("i: " + i);
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
    }
}
