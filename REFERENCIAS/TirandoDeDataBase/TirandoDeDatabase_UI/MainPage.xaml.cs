using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace TirandoDeDatabase_UI
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

      
        IReadOnlyList<StorageFile> Videos;


        /// <summary>
        /// Esto te permite escoger un video de tu directorio y reproducirlo
        /// </summary>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var MyFilePicker = new FileOpenPicker();
            MyFilePicker.FileTypeFilter.Add(".mp4");
            Videos = await MyFilePicker.PickMultipleFilesAsync();
            MediaElementCounter = 0;
            MyListView.ItemsSource = Videos;
        }

        int MediaElementCounter;
        private async void MediaElement_Loaded(object sender, RoutedEventArgs e)
        {
            MediaElement CurrentMedia = sender as MediaElement;
            var MediaStream = await Videos[MediaElementCounter].OpenAsync(Windows.Storage.FileAccessMode.Read);
            CurrentMedia.SetSource(MediaStream, ".mp4");
            MediaElementCounter++;
        }
    }

    class MyMediaClass
    {
        public string MyFile { get; set; }
        public MediaElement MyMedia { get; set; }
    }


}
