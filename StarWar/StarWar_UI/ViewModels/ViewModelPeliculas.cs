using StarWar_BL.Gestionadora_BL;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StarWar_UI.ViewModels
{
    public class ViewModelPeliculas : Base
    {
        #region "Atributos"       
        private ObservableCollection<PeliculaConNombreTrilogia> _listadoPeliculas;
        private PeliculaConNombreTrilogia _peliculaSeleccionada;
        private GestionadoraBL gestoraBL = new GestionadoraBL();
        public int idTrilogia;

        public ViewModelPeliculas() { }

        #endregion

        #region "Gets y Sets"
        public ObservableCollection<PeliculaConNombreTrilogia> ListadoPeliculas
        {
            get {
                _listadoPeliculas= new ObservableCollection<PeliculaConNombreTrilogia>(gestoraBL.obtenerPeliculasConNombreDeTrilogiaBL(idTrilogia));
                return (_listadoPeliculas); }
            set { this._listadoPeliculas = value; NotifyPropertyChanged("ListadoPeliculas"); }
        }

        public PeliculaConNombreTrilogia PeliculaSeleccionada
        {
            get { return (_peliculaSeleccionada); }
            set { this._peliculaSeleccionada = value;
                pasarAPersonajesIdTrilogiaYPelicula();
                NotifyPropertyChanged("PeliculaSeleccionada"); }
        }

        #endregion

        #region "Metodos"
        /// <summary>
        /// Este metodo me permite pasar la pelicula seleccionada a la Pagina de las Personajes
        /// </summary>
        public void pasarAPersonajesIdTrilogiaYPelicula()
        {
            try
            {
                Frame rootFrame = Window.Current.Content as Frame;
                if (_peliculaSeleccionada.IdTrilogia >= 0 && _peliculaSeleccionada.IdPelicula >= 0)
                {
                    rootFrame.Navigate(typeof(PersonajesPage), PeliculaSeleccionada);
                }

            }
            catch (Exception e) { DisplayDialogError(e); }
        }


        public async void DisplayDialogError(Exception e)
        {
            ContentDialog Dialog = new ContentDialog
            {
                Title = "Ha ocurrido un error",
                Content = "" + e.Message,
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await Dialog.ShowAsync();
        }



        #endregion

    }
}
