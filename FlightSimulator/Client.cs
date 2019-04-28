using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimulator
{
    class Client
    {
        public bool IsConnected { get;set;}
        Thread thread;
        Socket soc;

        // instance for singleton pattern
        private static Client instance = null;

        private Client()
        {
            this.IsConnected = false;
        }

        // instance method for singleton pattern
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }

        // open server
        public void ConnectToServer(string IP, int port)
        {
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!soc.Connected)
            {
                try
                {
                    IPAddress ipAdd = IPAddress.Parse(IP);
                    IPEndPoint remoteEP = new IPEndPoint(ipAdd, port);
                    soc.Connect(remoteEP);
                } catch (SocketException)
                {
                    Console.WriteLine("Waiting for connection...");
                    continue;
                }
            }
            IsConnected = true;
        }

        // read from client and separate by commas
        public void WriteToServer(String[] lines)
        {
            thread = new Thread(() =>
            {
                if (IsConnected)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        byte[] lineWithEnter = System.Text.Encoding.ASCII.GetBytes(lines[i] + "\r\n");
                        try
                        {
                            soc.Send(lineWithEnter);
                            Thread.Sleep(2000);
                        }
                        catch
                        {
                            Console.WriteLine("Writing to server failed");
                            CloseClient();
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Client not connected. Cannot send data!");
                }
            });
            thread.Start();
        }

        // close client
        public void CloseClient()
        {
            soc.Close();
            IsConnected = false;
        }
    }
}
