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
        private Thread thread;

        public bool IsConnected { get; set; }
        private String[] data;
        public String[] Data {
            get
            {
                //mutex.WaitOne();
                return data;
            }
            set
            {
                data = value;
            }
        }

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
            thread = new Thread(() => 
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
            try
            {
                c = reader.ReadChar();
            }
            catch 
            {
                Console.WriteLine("Reading from client failed");
                return;
            }
            while (c != '\n')
            {
                buffer += c;
                try
                {
                    c = reader.ReadChar();
                }
                catch
                {
                    Console.WriteLine("Reading from client failed");
                    return;
                }
            }
            Data = buffer.Split(',');
            //Console.WriteLine(Data[23] + " " + Data[19] + " " + Data[20] + " " + Data[21]);
        }
        
        // close server
        public void CloseServer()
        {
            server.Stop();
            thread.Abort();
            IsConnected = false;
        }
    }
}
