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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for AutoControl.xaml
    /// </summary>
    public partial class AutoControlView : UserControl
    {
        public AutoControlView()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxAuto.Clear();
        }
    }
}
