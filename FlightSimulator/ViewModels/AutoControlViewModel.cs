using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class AutoControlViewModel
    {
        public string TextWithSets { get; set; }
        public Action WhiteBackgroundAction { get; set; }

        private ICommand _OKCommand;
        public ICommand OKCommand
        {
            get
            {
                return _OKCommand ?? (_OKCommand = new CommandHandler(() => OnOKClick()));
            }
        }

        private void OnOKClick()
        {
            WhiteBackgroundAction();
            String[] separated = TextWithSets.Split('\n');
            Client.Instance.WriteToServer(separated);
        }
    }
}
