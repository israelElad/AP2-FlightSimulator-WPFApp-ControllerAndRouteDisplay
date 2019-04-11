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
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using System.ComponentModel;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Flight.xaml
    /// </summary>
    public partial class FlightView : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;
        public FlightViewModel viewModel;

        public FlightView()
        {
            InitializeComponent();
            this.viewModel = new FlightViewModel();
            viewModel.propertyChanged += Vm_PropertyChanged;
            DataContext = viewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);
            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                Point p1 = new Point(viewModel.Lat, viewModel.Lon);
                Console.WriteLine("propChanges" + p1.X + "_" + p1.Y);
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }
    }
}
