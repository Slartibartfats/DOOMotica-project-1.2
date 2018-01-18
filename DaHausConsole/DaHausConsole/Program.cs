using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace DaHausConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String responseData = String.Empty;
                Int32 port = 11000;
                string server = "127.0.0.1";
                System.Net.IPAddress IP = System.Net.IPAddress.Parse("127.0.01");
                TcpListener listener = new TcpListener(IP, port);
                
                
                string message = Console.ReadLine() + "\r\n";           
                TcpClient client = new TcpClient(server, port);
                Byte[] data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                listener.Start();
                Console.WriteLine("Sent: {0}", message);

                
                data = new Byte[256];
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
            
        }
    }
}
