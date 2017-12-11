using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _06_Canvas_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InkCanvasPage : Page
    {
        public InkCanvasPage()
        {
            this.InitializeComponent();
           
            
        }

        private void abbDibujar_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Inking;
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Touch;
        }

        private void abbBorrar_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Erasing;
        }

        private void abbAtras_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MainPage));
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();
            inkDrawingAttributes.Color = Windows.UI.Colors.Blue;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }
    }
}
