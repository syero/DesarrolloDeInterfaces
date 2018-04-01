using CosaNostra_BL.Gestionadora_BL;
using CosaNostra_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CosaNostra_UI.ViewModels
{
    public class ViewModelLogin : Base
    {
        private String _nick;
        private Mafioso _mafioso;
        Gestionadora_BL gestionadora = new Gestionadora_BL();

        #region "Gete and Setes"
        public String Nick
        {
            get { return (_nick); }
            set { this._nick = value; NotifyPropertyChanged("Nick"); }
        }


        public Mafioso Mafioso
        {
            get { return (_mafioso); }
            set { this._mafioso = value; NotifyPropertyChanged("Mafioso"); }
        }

        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void validarNick()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (_nick != null)
            {
                _mafioso = gestionadora.validarMafiosoBL(_nick);
                if (_mafioso.nickMafioso != null)
                {
                    rootFrame.Navigate(typeof(MafiosoMisiones), _mafioso);
                }
                else
                {
                    DisplayDialog();
                    _nick = null;
                    NotifyPropertyChanged("Mafioso");
                }
            }
            else
            {
                DisplayDialogNickNull();
            }
        }

        /// <summary>
        /// Este es el dialogo que aparecera cuando el nick del mafioso no sea
        /// encontrado en la base de datos.
        /// </summary>
        public async void DisplayDialog()
        {
            ContentDialog datosIncorrectosDialog = new ContentDialog
            {
                Title = "Nick Incorrecto",
                Content = "El nick no esta registrado en base de datos",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await datosIncorrectosDialog.ShowAsync();
        }

        /// <summary>
        /// Dialogo para cuando el usuario no escriba nada ne el nick
        /// </summary>
        public async void DisplayDialogNickNull()
        {
            ContentDialog datoNullDialog = new ContentDialog
            {
                Title = "Introduzca un nick",
                Content = "El nick no puede esta vacío",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await datoNullDialog.ShowAsync();
        }
    }
}
