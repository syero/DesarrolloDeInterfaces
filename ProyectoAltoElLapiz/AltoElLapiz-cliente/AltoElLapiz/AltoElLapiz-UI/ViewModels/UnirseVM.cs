using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AltoElLapiz_UI.ViewModels
{
    public class UnirseVM : clsVMBase
    {
        //private clsPartida _partidaSeleccionada;
        private bool _visibilidadPopUp = false;
        /*public clsPartida partidaSeleccionada {
            get
            {
                return _partidaSeleccionada;
            }

            set
            {
                _partidaSeleccionada = value;

                //Abrir popup
                _visibilidadPopUp = true;
                
            }
        }*/

        public bool visibilidadPopUp
        {
            get
            {
                return _visibilidadPopUp;
            }

            set
            {
                _visibilidadPopUp = value;
                NotifyPropertyChanged("visibilidadPopUp");
            }
        }
        /*public async Task MostrarPantallaEsperaUnirsePartidaAsync()
        {
            ContentDialog mostrarPantallaEsperaUnirsePartida = new ContentDialog();
            StackPanel stackPanel = new StackPanel();
            TextBlock nombre = new TextBlock();
            
            //stackPanel.Children.Add
            mostrarPantallaEsperaUnirsePartida.Title = "Sala de espera";
            mostrarPantallaEsperaUnirsePartida.Content = "";
            mostrarPantallaEsperaUnirsePartida.PrimaryButtonText = "Cerrar";

            ContentDialogResult resultado = await mostrarPantallaEsperaUnirsePartida.ShowAsync();
        }*/
    }
}
