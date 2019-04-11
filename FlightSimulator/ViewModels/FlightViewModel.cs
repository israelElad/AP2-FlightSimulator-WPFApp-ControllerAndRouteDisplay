using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            get { return model.Lon; }
        }

        public double Lat
        {
            get { return model.Lat; }
        }

        public FlightViewModel()
        {
            model = new FlightModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);

            };
        }
        
        private void OnConnectClick()
        {
            if (settingsWindow == null)
            {
                settingsWindow = new SettingsView();
            }
            model.StartRead(settingsWindow.viewModel.FlightServerIP, settingsWindow.viewModel.FlightInfoPort);
        }

        private void OnSettingsClick()
        {
            //if settings window wasn't created or was created but isn't open- create and show it.
            if (settingsWindow == null || !settingsWindow.isOpen)
            {
                settingsWindow = new SettingsView();
                settingsWindow.Show();
            }
        }

      
    }
}
