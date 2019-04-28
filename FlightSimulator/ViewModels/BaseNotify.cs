using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public abstract class BaseNotify : INotifyPropertyChanged
    {
        // an event that should be invoked when a propery is changed, and can accumulate functions to be activated when it was.
        public event PropertyChangedEventHandler PropertyChanged;

        // activates all the functions added to PropertyChanged event(if there was any), with the property's name received as a paremeter.
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
