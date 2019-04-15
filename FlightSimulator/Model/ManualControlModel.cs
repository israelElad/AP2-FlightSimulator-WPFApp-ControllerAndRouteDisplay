using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualControlModel : BaseNotify
    {
        private double throttle;
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }

        private double aileron;
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }

        private double elevator;
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }

        private double rudder;
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }

        public ManualControlModel()
        {
            ReadIndicators();
        }

        public void ReadIndicators()
        {
            new Thread(delegate ()
            {
                while (true)
                {
                    if (Server.Instance.Data != null)
                    {
                        Throttle = Convert.ToDouble(Server.Instance.Data[23]);
                        Aileron = Convert.ToDouble(Server.Instance.Data[19]);
                        Elevator = Convert.ToDouble(Server.Instance.Data[20]);
                        Rudder = Convert.ToDouble(Server.Instance.Data[22]);
                        Thread.Sleep(1000);
                        Console.WriteLine(Server.Instance.Data[23] + "_" + Server.Instance.Data[19] + "_" + Server.Instance.Data[20] + "_" + Server.Instance.Data[21]);
                        Console.WriteLine(Throttle + " " + Aileron + " " + Elevator + " " + Rudder);
                    }
                }
            }).Start();
        }
    }
}
