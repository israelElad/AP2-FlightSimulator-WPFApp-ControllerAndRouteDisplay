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
    class Server
    {
        private TcpListener server;
        private TcpClient connectedClient;
        private bool isConnected;
        private BinaryReader reader;

        public Server()
        {
            this.isConnected = false;
        }

        // open server
        public void openServer(string IP, int port)
        {
            server = new TcpListener(new System.Net.IPEndPoint(IPAddress.Parse(IP), port));
            server.Start();
        }

        // read from client and separate by commas
        public String[] readFromClient()
        {
            String[] separated = { };
            if (!isConnected)
            {
                connectedClient = server.AcceptTcpClient();
                reader = new BinaryReader(connectedClient.GetStream());
                isConnected = true;
            }
            String buffer = "";
            char c;
            c = reader.ReadChar();
            while (c != '\n')
            {
                buffer += c;
                c = reader.ReadChar();
            }
            separated = buffer.Split(',');
            return separated;
        }
        
        // close server
        public void closeServer()
        {
            server.Stop();
            isConnected = false;
        }
    }
}
