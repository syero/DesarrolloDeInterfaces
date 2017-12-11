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

namespace SandraRepasoBindingNavegarEntrePaginasCommand
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

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.passwordBox1.GetBindingExpression(PasswordBox.TextReadingOrderProperty).UpdateSource();

        }

        /**para ir a la pagina del contenido*/
        private void btn_Gurdar_Click(object sender, RoutedEventArgs e)
        {           
            Frame.Navigate(typeof(Contenido));
          //  Frame.Navigate(typeof(View.BlankPage2));
        }

        
    }
}
