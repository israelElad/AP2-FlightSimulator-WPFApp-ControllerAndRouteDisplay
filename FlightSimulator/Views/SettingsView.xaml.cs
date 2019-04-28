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
        public SettingsView()
        {
            InitializeComponent();
            this.ViewModel = new SettingsWindowViewModel(new ApplicationSettingsModel());
            //Define the view's DataContext to be the view model - binding will sync between them. 
            DataContext = ViewModel;
            if (ViewModel.CloseAction == null)
            {
                ViewModel.CloseAction = new Action(() => this.Close());
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
            ViewModel.ReloadSettings();
        }
    }
}
