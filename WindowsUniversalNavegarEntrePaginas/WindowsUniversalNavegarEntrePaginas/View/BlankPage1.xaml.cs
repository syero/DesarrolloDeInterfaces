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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsUniversalNavegarEntrePaginas
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }


        private void btn_Atras_Click(object sender, RoutedEventArgs e)
        {
           // if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
            Frame.GoBack();
        }

        private void btn_Navegar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.BlankPage2));
        }
    }
}
