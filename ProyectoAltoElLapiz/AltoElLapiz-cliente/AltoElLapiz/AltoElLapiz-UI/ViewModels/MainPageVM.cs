using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AltoElLapiz_UI.ViewModels
{
    public class MainPageVM
    {
        private DelegateCommand _unirseCommand;

        public MainPageVM()
        {

        }

        public DelegateCommand unirseCommand
        {
            get
            {
                _unirseCommand = new DelegateCommand(UnirseCommand);
                return _unirseCommand;
            }
        }

        private void UnirseCommand()
        {
            Frame frameActual = (Frame) Window.Current.Content;
            frameActual.Navigate(typeof(AltoElLapiz_UI.UnirsePage));
        }
    }
}
