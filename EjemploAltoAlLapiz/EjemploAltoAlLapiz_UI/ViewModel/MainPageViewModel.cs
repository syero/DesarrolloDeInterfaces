using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EjemploAltoAlLapiz_UI.ViewModel
{
    public class MainPageViewModel:Base
    {
        private ObservableCollection<String> _listaCategorias;
        private ObservableCollection<String> _categoriasSeleccionadas;

        public ObservableCollection<String> ListaCategorias
        {
            get { return _listaCategorias; }
            set { _listaCategorias = value; NotifyPropertyChanged("ListaCategorias"); }
        }

        public ObservableCollection<String> CategoriasSeleccionadas
        {
            get { return _categoriasSeleccionadas; }
            set { _categoriasSeleccionadas = value; NotifyPropertyChanged("CategoriasSeleccionadas"); }
        }

        public void agregarCategoria(object sender, RoutedEventArgs e)
        {
            String unaCategoria = (String)sender;
            for (var i = 0; i < ListaCategorias.Count; i++)
            {
                if (unaCategoria.Equals(ListaCategorias[i]) && _categoriasSeleccionadas.Count < 7)
                {
                    _categoriasSeleccionadas.Add(unaCategoria);
                }
            }

        }

        /// <summary>
        /// Este metodo va a pasar al view model de juego  las categorias seleccionadas por el usuario 
        /// </summary>
        public void pasarCategoriasSeleccionadas()
        {
            try
            {
                Frame rootFrame = Window.Current.Content as Frame;
                if (CategoriasSeleccionadas != null)
                {
                    rootFrame.Navigate(typeof(JuegoViewModel), CategoriasSeleccionadas);
                }

            }
            catch (Exception e) { }
        }


        /// <summary>
        /// Metodo para meter datos de pruba en la lista de categorias
        /// </summary>
        public void DatosDePrueba()
        {
            _listaCategorias.Add("Animal");
            _listaCategorias.Add("Flor");
            _listaCategorias.Add("Fruta");
            _listaCategorias.Add("Profesión");
            _listaCategorias.Add("Ciudad");
            _listaCategorias.Add("Color");
            _listaCategorias.Add("Nombre");
            _listaCategorias.Add("Objeto");
            _listaCategorias.Add("Marca");
            _listaCategorias.Add("Película");
            _listaCategorias.Add("Cancion");
            _listaCategorias.Add("Deporte");
            _listaCategorias.Add("Libro");
            _listaCategorias.Add("Apellido");
            _listaCategorias.Add("Personaje");
        }


    }
}
