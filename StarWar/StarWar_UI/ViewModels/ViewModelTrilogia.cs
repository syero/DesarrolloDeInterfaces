using StarWar_BL.Listados_BL;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StarWar_UI.ViewModels
{
    public class ViewModelTrilogia : Base
    {
        #region "Atributos"
        private ObservableCollection<Trilogia> _listadetrilogias;
        private Trilogia _trilogiaSeleccionada;
        ListadosBL listadoBL = new ListadosBL();
       
        public ViewModelTrilogia()
        {          
            ListadeTrilogias = new ObservableCollection<Trilogia>(listadoBL.obtenerTrilogiaBL());
        }

        #endregion

        #region "Gets y Sets"
        public ObservableCollection<Trilogia> ListadeTrilogias
        {
            get{return (_listadetrilogias);}
            set { this._listadetrilogias = value; NotifyPropertyChanged("Listadetrilogias"); }
        }


        public Trilogia TrilogiaSeleccionada
        {
            get { return (_trilogiaSeleccionada); }
            set { this._trilogiaSeleccionada = value;
                pasarAPeliculasIdTrilogia();
                NotifyPropertyChanged("TrilogiaSeleccionada"); }
        }


        #endregion

        #region "Metodos"

        /// <summary>
        /// Este metodo me permite pasar la id de la trilogia seleccionada a la Pagina de las Peliculas
        /// </summary>
        public void pasarAPeliculasIdTrilogia()
        {
            try
            {
                Frame rootFrame = Window.Current.Content as Frame;
                if (TrilogiaSeleccionada.IdTrilogia>=0)
                {
                    rootFrame.Navigate(typeof(PeliculasPage), TrilogiaSeleccionada.IdTrilogia);
                }
                                
            }catch (Exception e) { DisplayDialogError(e); }
        }

        /// <summary>
        /// Mensaje de error generico 
        /// </summary>
        /// <param name="e"></param>
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
