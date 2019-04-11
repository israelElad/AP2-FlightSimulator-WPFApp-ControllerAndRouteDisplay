using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    class Client
    {
        private TcpClient client;
        private bool IsConnected;
        private BinaryWriter writer;

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
        public void connectToServer(string IP, int port)
        {
            client = new TcpClient();
            while (!client.Connected)
            {
                try
                {
                    client.Connect(new System.Net.IPEndPoint(IPAddress.Parse(IP), port));
                } catch
                {
                    continue;
                }
            }
            IsConnected = true;
            writer = new BinaryWriter(client.GetStream());
        }

        // read from client and separate by commas
        public void writeToServer(String[] lines)
        {
            for (int i = 0; i<lines.Length; i++)
            {
                String lineWithEnter = lines[i] + "\r\n";
                writer.Write(lineWithEnter);
            }
        }

        // close server
        public void CloseClient()
        {
            client.Close();
            IsConnected = false;
        }
    }
}
