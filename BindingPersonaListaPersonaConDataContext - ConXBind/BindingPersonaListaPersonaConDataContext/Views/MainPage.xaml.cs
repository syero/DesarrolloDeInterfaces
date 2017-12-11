using BindingPersonaListaPersonaConDataContext.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BindingPersonaListaPersonaConDataContext
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /**
         * 
         * Necesitamos declarar un objeto VM en el code behind de la página para que 
         * los x:Bind funcionen,tenemos que declarar un objeto del Tipo Nuestro VM.
         * forma corta
         */
      //  public MainPageMV vistaModelo{ get; } =new MainPageMV();

        public MainPage()
        {
            this.InitializeComponent();

            this.viewModel = new MainPageMV(); //forma larga
        }

        public MainPageMV viewModel { get; } //esto esta parte de la forma larga


        public void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            //para cuando le demos al boton guardar se modifiquen los datos de la lista
            this.txtBx_Nombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.txtBx_Apellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.txtBx_FNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.txtBx_Direccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();

        }

       
    }
}
