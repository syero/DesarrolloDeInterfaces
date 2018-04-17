﻿using StarWar_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    // https://stackoverflow.com/questions/31693314/titlebar-back-button-for-uwp/31693631

    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PeliculasPage : Page
    {
        public ViewModelPeliculas viewModelPeliculas { get; set; }

        public PeliculasPage()
        {
            this.InitializeComponent();
            viewModelPeliculas = (ViewModelPeliculas)this.DataContext;
            atras();
        }

        /// <summary>
        /// Aqui recibo el id de la trilogia que el usuario ha escogido
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                viewModelPeliculas.idTrilogia = (Int32)e.Parameter;
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
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                var backstack = rootFrame.BackStack;
                if (backstack.Count > 0)
                {
                    rootFrame.GoBack();
                    e.Handled = true;
                }

            }
        }
    }
}
