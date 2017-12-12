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

namespace CRUD_Personas_UI.Views
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            //para cuando le demos al boton guardar notifica que se han modificados los datos de la lista
            this.txtBx_Nombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.txtBx_Apellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.txtBx_FNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.txtBx_Direccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();

        }

/*
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {

        }
        */
    }
}
