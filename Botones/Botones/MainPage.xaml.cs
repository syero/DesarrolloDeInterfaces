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

namespace Botones
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Mi TextBox
        TextBox escribeText = new TextBox();
        TextBlock mostrarText = new TextBlock();

        public MainPage()
        {

            /**InitializeComponent es parte de la infraestructura proporcionada por marcos o tecnologías que usan XAML combinan con modelos de programación y 
             * de aplicación .Ese método también existe en el ensamblado compilado y desempeña una función en el modelo de aplicación de WPF de cargar el 
             * contenido de la UI XAML en tiempo de análisis XAML
             */
            this.InitializeComponent();

          //  TextBlock textoHaEscribir = new TextBlock();

            Button boton3 = new Button(); //creamos el boton
            boton3.Content = "Boton3";

            //esto me permite decir que mi boton es hijo de mi StackPanel, asi se crea la relacion entre ellos (esta para mi es mas simple)
            btn.Children.Add(boton3); //btn es el nombre del StackPanel

            //ojo tambien he visto que se puede hacer asi , aunque para mi gusto creo que esta no es la mejor forma de hacerlo
            /*    StackPanel stkP = new StackPanel();
                  stkP.Children.Add(boton3);
            */
            //caracteristicas del boton
            boton3.HorizontalAlignment = HorizontalAlignment.Left;
            boton3.Margin = new Thickness(76, 78, 0, 0);  //los numero de dentro los he copiado de uno de los botones de xaml 
            boton3.VerticalAlignment = VerticalAlignment.Top;
            boton3.Height = 70;
            boton3.Width = 200;
            boton3.Background = new SolidColorBrush(Windows.UI.Colors.Blue); //para el fondo
            boton3.FontFamily = new FontFamily("Verdana");
            boton3.FontSize = 16;
            boton3.FontWeight = Windows.UI.Text.FontWeights.Bold;
            boton3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow); //para los bordes

            
            
            //caracteristicas del textBox
               escribeText.Width = 500;
               escribeText.Header = "Nombre";
               escribeText.PlaceholderText = "Escriba su nombre";


            //indicamos que el textBox es hijo del StackPanel
                btn.Children.Add(escribeText);


            //caracteteristicas del textBlock
                mostrarText.Height =40;
                mostrarText.FontSize = 30;
                mostrarText.Margin =new Thickness(20, 20, 0, 0);

            
            btn.Children.Add(mostrarText);

            
             boton3.Click += OnClick3;

                        

        }//fin MainPage

        private void OnClick3(Object objeto, RoutedEventArgs accion){

            mostrarText.Text = escribeText.Text;
            //escribeText.Text="Hola";
        }

    }
}
