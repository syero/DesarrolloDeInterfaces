using SankeBL.Listados;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeUI.ViewModels
{
   public class MapasViewModel :clsVMBase
    {
        private List<Mapa> _listaMapas;
        private Mapa _mapaSeleccionado;
        private bool _ordenarPorValoracion=true;

        ListadoMapasBL listadoMapasBL = new ListadoMapasBL();

        public MapasViewModel()
        {
            obtenerMapas();
        }

        public List<Mapa> ListaMapas
        {
            get { return _listaMapas; }
            set { this._listaMapas = value; NotifyPropertyChanged("ListaMapas"); }
        }

        public Mapa MapaSeleccionado
        {
            get { return _mapaSeleccionado; }
            set { this._mapaSeleccionado = value; NotifyPropertyChanged("MapaSeleccionado"); }
        }

        public bool OrdenarPorValoracion
        {
            get { return _ordenarPorValoracion; }
            set { this._ordenarPorValoracion = value; NotifyPropertyChanged("OrdenarPorValoracion"); }
        }

        private async void obtenerMapas()
        {
            _listaMapas = await listadoMapasBL.getListadoBL(OrdenarPorValoracion);
            NotifyPropertyChanged("ListaMapas");
        }

    }
}
