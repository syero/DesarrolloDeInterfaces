using Snake.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Snake
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Jugar : Page
    {
        public JugarVM ViewModel { get; set; }
        public Jugar()
        {
            this.InitializeComponent();

            this.ViewModel = (JugarVM)this.DataContext;
        }

        private void RelativePanel_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.Content.KeyDown += this.ViewModel.teclaPulsada;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ObservableCollection<ObservableCollection<String>> mapa = new ObservableCollection<ObservableCollection<string>>();

            if (e.Parameter != null && e.Parameter.GetType() == mapa.GetType()) {
                mapa = (ObservableCollection<ObservableCollection<String>>)e.Parameter;


                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        this.ViewModel.sourceList[i][j] = mapa[i][j];
                    }
                }
            }
            this.ViewModel.serpiente.generarComida();
        }
    }
}
