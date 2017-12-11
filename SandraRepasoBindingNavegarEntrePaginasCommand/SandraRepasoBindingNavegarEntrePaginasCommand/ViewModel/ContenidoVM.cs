using SandraRepasoBindingNavegarEntrePaginasCommand.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandraRepasoBindingNavegarEntrePaginasCommand.ViewModel
{
   public class ContenidoVM:clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<Pelicula> _listaPeliculasAMostrar;
        private Pelicula _peliculaSeleccionada;

        private DelegateCommand _guardarNuevaPelicula;
        private DelegateCommand _agregarPelicula;
        private DelegateCommand _borrarPelicula;

        #endregion


        #region "Constructores"
        public ContenidoVM()
        {
            Gestionadora gestion = new Gestionadora();

            //relleno la lista de peliculas
            _listaPeliculasAMostrar = gestion.obtenerListaPeliculas();
            _peliculaSeleccionada = null;

            

        }

        public ContenidoVM(ObservableCollection<Pelicula> nListaPeliculasAMostrar, Pelicula nPeliculaSeleccionada)
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

        public DelegateCommand GuardarNuevaPelicula
        {
            get { return _guardarNuevaPelicula; }
            set { _guardarNuevaPelicula = value; NotifyPropertyChanged("GuardarNuevaPelicula"); }
        }

        public DelegateCommand AgregarPelicula
        {
            get { return _agregarPelicula; }
            set { _agregarPelicula = value; NotifyPropertyChanged("AgregarPelicula"); }
        }

        public DelegateCommand BorrarPelicula
        {
            get { return _borrarPelicula; }
            set { _borrarPelicula = value; NotifyPropertyChanged("BorrarPelicula"); }
        }


        #endregion


        #region "Metodos"
        public void ExecuteAgregarPelicula()
        {
            if (_peliculaSeleccionada!=null && _peliculaSeleccionada.Nombre!=null)
            {
                _listaPeliculasAMostrar.Add(_peliculaSeleccionada);
                NotifyPropertyChanged("ListaPeliculasAMostrar");

            }
        }

        #endregion


    }
}
