using Snake;
using SnakeUI.ViewModels;
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

namespace SnakeUI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Mapas : Page
    {
        public MapasViewModel mapasvm { get; set; }

        public Mapas()
        {
            this.InitializeComponent();
            mapasvm =(MapasViewModel) this.DataContext;
        }

        private void BotonJugar_Click(object sender, RoutedEventArgs e)
        {
            mapasvm.sourceList[17][0] = "Assets/gato/cabeza-izq.png";
            mapasvm.sourceList[18][0] = "Assets/gato/cuerpo-hor.png";
            mapasvm.sourceList[19][0] = "Assets/gato/culo-izq.png";
            Frame.Navigate(typeof(Jugar),mapasvm.sourceList);
        }
    

        private void MapasPorValoracion_Click(object sender, RoutedEventArgs e)
        {
            mapasvm.OrdenarPorValoracion = true;
            mapasvm.obtenerMapas();
        }

        private void MapasPorFecha_Click(object sender, RoutedEventArgs e)
        {
           mapasvm.OrdenarPorValoracion = false;
            mapasvm.obtenerMapas();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                mapasvm.OrdenarPorValoracion = (bool)e.Parameter;
                mapasvm.obtenerMapas();
            }

        }
    }
}
