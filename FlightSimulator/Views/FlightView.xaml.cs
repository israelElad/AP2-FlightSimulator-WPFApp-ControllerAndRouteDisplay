using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;


namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Flight.xaml
    /// </summary>
    public partial class FlightView : UserControl
    {
        SettingsView settingsWindow;
        public FlightView()
        {
            InitializeComponent();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //if settings window wasn't created or was created but isn't open- create and show it.
            if (settingsWindow == null|| !settingsWindow.isOpen)
            { 
                settingsWindow = new SettingsView();
                settingsWindow.Show();
            }
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
