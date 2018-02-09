using SankeBL.Listados;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SnakeUI.ViewModels
{
   public class MapasViewModel :clsVMBase
    {
        private List<Mapa> _listaMapas;
        private Mapa _mapaSeleccionado;
        private bool _ordenarPorValoracion=true;
       

        public ObservableCollection<ObservableCollection<String>> sourceList { get; set; }

        ListadoMapasBL listadoMapasBL = new ListadoMapasBL();
        private int MAX_FILAS = 11;
        private int MAX_COLUMNAS = 20;

        public MapasViewModel()
        {
            sourceList = new ObservableCollection<ObservableCollection<string>>();
            obtenerMapas();
            rellenarSourceListBlanco();

        }

        private void rellenarSourceListBlanco()
        {
            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                sourceList.Add(new ObservableCollection<String>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    sourceList[i].Add("../Assets/LockScreenLogo.scale-200.png");
                }
            }
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

        public void dibujar()
        {

            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                sourceList.Add(new ObservableCollection<String>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    if (_mapaSeleccionado.Casillas[i][j])
                    {
                        sourceList[i].Add("../Assets/LockScreenLogo.scale-200.png");
                    }
                    else
                    {
                        sourceList[i].Add("../Assets/transparente.png");
                    }
                    
                }
            }
        }


    }
}
