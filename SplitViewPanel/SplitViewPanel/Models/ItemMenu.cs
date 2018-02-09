using SplitViewPanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitViewPanel.Models
{
    class ItemMenu : clsVMBase
    {
        private string _estiloLetra;
        private string _nombreIntem;
        private DelegateCommand command;
        private Type navigationDestination;

        public string EstiloLetra
        {
            get { return _estiloLetra; }
            set { SetProperty(ref _estiloLetra, value); }
        }

        public string NombreIntem
        {
            get { return _nombreIntem; }
            set { SetProperty(ref _nombreIntem, value); }
        }

        private void SetProperty(ref string nombreIntem, string value)
        {
            throw new NotImplementedException();
        }


        public Type NavigationDestination
        {
            get { return navigationDestination; }
            set { SetProperty(ref navigationDestination, value); }
        }

        public bool IsNavigation
        {
            get { return navigationDestination != null; }
        }

    }
}
