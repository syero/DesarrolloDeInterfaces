using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Examen1Evaluacion
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPageVM ViewModel { get; }
        

        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = (MainPageVM)this.DataContext;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            storyboard.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            DoubleAnimation rotateAnimation = new DoubleAnimation();

            rotateAnimation.From = 90.0;
            rotateAnimation.To = 0.0;
            rotateAnimation.Duration = storyboard.Duration;
            

            
            Storyboard.SetTarget(rotateAnimation,(Image)e.OriginalSource);
            Storyboard.SetTargetProperty(rotateAnimation, "(UIElement.Projection).(PlaneProjection.RotationY)");

            
            storyboard.Children.Add(rotateAnimation);

            storyboard.Begin();


        }
    }
}
