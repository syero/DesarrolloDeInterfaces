using SankeBL.Listados;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeUI.ViewModels
{
    public class PuntuacionVM : clsVMBase
    {
        private ObservableCollection<Puntuacion> _puntuaciones;

        public ObservableCollection<Puntuacion> puntuaciones
        { get {
                return _puntuaciones;
            } set {
                _puntuaciones = value;
                NotifyPropertyChanged("puntuaciones");
            }
        }


        public PuntuacionVM()
        {

            rellenarPuntuaciones();
        }

        private async void rellenarPuntuaciones()
        {
            ListadoPuntuacionesBL lbl = new ListadoPuntuacionesBL();

            puntuaciones = new ObservableCollection<Puntuacion>(await lbl.getListadoBL());
        }

    }
}
