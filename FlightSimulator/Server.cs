using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator
{
    class Server
    {
        private TcpListener server;
        private TcpClient connectedClient;
        private BinaryReader reader;

        public bool IsConnected { get; set; }
        public String[] Data { get; set; }

        // instance for singleton pattern
        private static Server instance = null;

        private Server()
        {
            this.IsConnected = false;
        }

        // instance method for singleton pattern
        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Server();
                }
                return instance;
            }
        }

        // open server
        public void OpenServer(string IP, int port)
        {
            server = new TcpListener(new IPEndPoint(IPAddress.Parse(IP), port));
            server.Start();
            Thread thread = new Thread(() => 
            {
                while (true) {
                    if (!IsConnected)
                    {
                        try
                        {
                            Console.WriteLine("enter try");
                            connectedClient = server.AcceptTcpClient();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    reader = new BinaryReader(connectedClient.GetStream());
                    IsConnected = true;
                    Console.WriteLine("enter ReadFromClient");
                    ReadFromClient();
                }
            });
            thread.Start();
        }

        // read from client and separate by commas
        public void ReadFromClient()
        {
            String buffer = "";
            char c;
            c = reader.ReadChar();
            while (c != '\n')
            {
                buffer += c;
                c = reader.ReadChar();
            }
            Data = buffer.Split(',');
            Console.WriteLine(Data[0] + " " + Data[1]);
        }
        
        // close server
        public void CloseServer()
        {
            server.Stop();
            IsConnected = false;
        }
    }
}
