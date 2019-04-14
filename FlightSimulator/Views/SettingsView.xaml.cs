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
        public SettingsWindowViewModel ViewModel { get; }
        public bool IsOpen { get; set; } 
        public SettingsView()
        {
            InitializeComponent();
            IsOpen = true;
            this.ViewModel = new SettingsWindowViewModel(new ApplicationSettingsModel());
            DataContext = ViewModel;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            IsOpen = false;
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            IP.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            InfoPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            CommandPort.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ViewModel.SaveSettings();
            IsOpen = false;
            this.Close();
        }
    }
}
