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
using FlightSimulator.ViewModels;
using FlightSimulator.Model;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Flight.xaml
    /// </summary>
    public partial class FlightView : UserControl
    {
        public FlightViewModel viewModel;

        public FlightView()
        {
            InitializeComponent();
            this.viewModel = new FlightViewModel();
            DataContext = viewModel;
        }
    }
}
