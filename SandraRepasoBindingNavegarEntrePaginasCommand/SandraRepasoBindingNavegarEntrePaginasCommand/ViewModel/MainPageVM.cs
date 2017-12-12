using SandraRepasoBindingNavegarEntrePaginasCommand.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandraRepasoBindingNavegarEntrePaginasCommand.ViewModel
{
   public class MainPageVM:clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<Pelicula> _listaPeliculasAMostrar;
        private ObservableCollection<Persona>_listadoActores;
        private Pelicula _peliculaSeleccionada;


        #endregion


        #region "Constructores"
        public MainPageVM()
        {
            ListaPeliculas peliculas = new ListaPeliculas();

            _listaPeliculasAMostrar = peliculas.obtenerLista();
            _peliculaSeleccionada = null;

        }

        public MainPageVM(ObservableCollection<Pelicula> nListaPeliculasAMostrar, Pelicula nPeliculaSeleccionada)
        {

            _listaPeliculasAMostrar = nListaPeliculasAMostrar;
            _peliculaSeleccionada = nPeliculaSeleccionada;

        }


        #endregion


        #region "Gets y Sets"
        public ObservableCollection<Pelicula> ListaPeliculasAMostrar
        {
            get { return _listaPeliculasAMostrar; }
            set { this._listaPeliculasAMostrar = value; NotifyPropertyChanged("ListaPeliculasAMostrar"); }
        }

        public Pelicula PeliculaSeleccionada
        {
            get { return _peliculaSeleccionada; }
            set { this._peliculaSeleccionada = value; NotifyPropertyChanged("PeliculaSeleccionada"); }

        }


        #endregion


        #region "Metodos"

        #endregion


    }
}
