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
        private bool IsConnected;
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
        public void connectToServer(string IP, int port)
        {
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!soc.Connected)
            {
                try
                {
                    System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(IP);
                    System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, port);
                    soc.Connect(remoteEP);
                } catch
                {
                    continue;
                }
            }
            IsConnected = true;
        }

        // read from client and separate by commas
        public void writeToServer(String[] lines)
        {
            for (int i = 0; i<lines.Length; i++)
            {
                byte[] lineWithEnter = System.Text.Encoding.ASCII.GetBytes(lines[i]+ "\r\n");
                soc.Send(lineWithEnter);
            }
        }

        // close server
        public void CloseClient()
        {
            soc.Close();
            IsConnected = false;
        }
    }
}
