using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;
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
using System.Windows.Shapes;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        private SettingsWindowViewModel viewModel;
        public bool isOpen { get; set; } 
        public SettingsView()
        {
            InitializeComponent();
            isOpen = true;
            this.viewModel = new SettingsWindowViewModel(new ApplicationSettingsModel());
            DataContext = viewModel;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            isOpen = false;
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            IP.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            InfoPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            CommandPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            viewModel.SaveSettings();
            isOpen = false;
            this.Close();
        }
    }
}
