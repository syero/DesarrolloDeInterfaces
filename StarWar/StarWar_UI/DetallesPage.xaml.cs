using StarWar_Entidades;
using StarWar_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace StarWar_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetallesPage : Page
    {
        public ViewModelDetalles viewModelDetalles { get; set; }

        public DetallesPage()
        {
            this.InitializeComponent();
            viewModelDetalles = (ViewModelDetalles)this.DataContext;
            atras();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                viewModelDetalles.DetallesPersonaje = (PersonajeCompleto)e.Parameter;
            }
        }


        /// <summary>
        /// Metodo para mostrar el boton de atras que aparece en el titleBar.
        /// Este metodo va a llamar al metodo que me permite volver a atras 
        /// OnBackRequested
        /// </summary>
        public void atras()
        {  
            Frame rootFrame = Window.Current.Content as Frame;
            var currentView = SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;           
            
            currentView.BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            //viewModelDetalles.miMediaPlayer.Pause();
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                viewModelDetalles.miMediaPlayer.Pause();

                var backstack = rootFrame.BackStack;
                if (backstack.Count >2)
                {
                    rootFrame.GoBack();
                    e.Handled = true;
                }

            }
        }

      
    }
}
