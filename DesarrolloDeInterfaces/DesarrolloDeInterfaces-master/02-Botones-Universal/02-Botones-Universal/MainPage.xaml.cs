using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _02_Botones_Universal
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            StackPanel stack = this.stkBotones;

            Button boton3 = new Button();
            boton3.Name = "btn3";
            boton3.Content = "Boton 3";
            boton3.HorizontalAlignment = HorizontalAlignment.Center;
            boton3.VerticalAlignment = VerticalAlignment.Bottom;
            boton3.HorizontalContentAlignment = HorizontalAlignment.Center;
            boton3.VerticalContentAlignment = VerticalAlignment.Center;
            boton3.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            boton3.Height = 70;
            boton3.Width = 200;
            boton3.FontSize = 16;
            boton3.FontWeight = FontWeights.Bold;
            boton3.FontFamily = new FontFamily("Verdana");
            boton3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);

            boton3.Click += boton3_Click;
            stack.Children.Add(boton3);
        }

        /// <summary>
        ///  Metodo que imprime en mensaje al hacer click en el botón 3.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boton3_Click(object sender, RoutedEventArgs e)
        {
            //To do
            this.btn1.Content = "Ey";
        }
    }
}
