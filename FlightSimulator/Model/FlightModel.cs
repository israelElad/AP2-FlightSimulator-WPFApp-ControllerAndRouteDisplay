using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightModel : BaseNotify
    {
        private Server server;

        private double lon;
        public double Lon
        {
            get
            {
                return lon;   
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat"); 
            }
        }

        public FlightModel()
        {
            server = new Server();
        }

        //opens a server and a thread that reads data from client
        public void StartRead(String ip, int port)
        {
            server.openServer(ip, port);
            new Thread(delegate ()
            {
                while (true)
                {
                    String[] data = server.readFromClient();
                    Lon = Convert.ToDouble(data[0]);
                    Lat = Convert.ToDouble(data[1]);
                    Console.WriteLine("from client:1:"+lon);
                    Console.WriteLine("from client:2:"+lat);
                }
            }).Start();
        }

      
    }
}
