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

namespace WindowsUniversalNavegarEntrePaginas
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

        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            //para navegar de una pagina a otra OJOOOOO important
            this.Frame.Navigate(typeof(BlankPage1));
        }

    }
}


/**
   <!-- 
    <!-- App bar button with symbol icon. -->
        <AppBarButton Name="btn_like" Icon="Like" Label="SymbolIcon" Click="AppBarButton_Click" RelativePanel.Below="rt_rectangulo" />

        <!-- App bar button with bitmap icon. -->
        <AppBarButton Name="btn_Algo" Label="BitmapIcon" Click="AppBarButton_Click" RelativePanel.Below="rt_rectangulo" RelativePanel.RightOf="btn_like">
            <AppBarButton.Icon>
                <BitmapIcon UriSource="ms-appx:///Assets/Slices.png"/>
            </AppBarButton.Icon>
        </AppBarButton>

        <!-- App bar button with font icon. -->
        <AppBarButton Name="btn_Font" Label="FontIcon" Click="AppBarButton_Click"  RelativePanel.Below="rt_rectangulo" RelativePanel.RightOf="btn_Algo">
            <AppBarButton.Icon>
                <FontIcon FontFamily="Candara" Glyph="&#x03A3;"/>
            </AppBarButton.Icon>
        </AppBarButton>

        <!-- App bar button with path icon. -->
        <AppBarButton Name="btn_path" Label="PathIcon" Click="AppBarButton_Click" RelativePanel.Below="rt_rectangulo" RelativePanel.RightOf="btn_Font">
            <AppBarButton.Icon>
                <PathIcon Data="F1 M 16,12 20,2L 20,16 1,16" HorizontalAlignment="Center"/>
            </AppBarButton.Icon>
        </AppBarButton>
     
     
     */
