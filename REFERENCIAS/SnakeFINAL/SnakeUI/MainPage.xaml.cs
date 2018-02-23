using Snake;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SnakeUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            StackPanel boton = (StackPanel)e.ClickedItem;

            switch (boton.Name)
            {
                case "stk_Jugar":
                    ContentFrame.Navigate(typeof(Jugar));
                    break;

                case "stk_Puntuaciones":
                    ContentFrame.Navigate(typeof(Puntuaciones));
                    break;

                case "stk_CrearMapa":
                    ContentFrame.Navigate(typeof(CreadorMapas));
                    break;

                case "stk_Mapas":
                    ContentFrame.Navigate(typeof(Mapas));
                    break;
            }


        }


    }
}
