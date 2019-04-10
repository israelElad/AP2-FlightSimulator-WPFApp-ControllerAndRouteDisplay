using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightViewModel : BaseNotify
    {
        private FlightModel model;
        private SettingsView settingsWindow;

        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnectClick()));
            }
        }

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand = new CommandHandler(() => OnSettingsClick()));
            }
        }

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }

        public FlightViewModel()
        {
            model = new FlightModel();
        }

        private void OnConnectClick()
        {
            model.StartRead(settingsWindow.IP, settingsWindow.InfoPort);
        }

        private void OnSettingsClick()
        {
            settingsWindow = new SettingsView();
            settingsWindow.Show();
        }
    }
}
