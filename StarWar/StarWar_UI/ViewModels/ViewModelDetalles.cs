using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWar_UI.ViewModels
{
    public class ViewModelDetalles : Base
    {
        private static PersonajeCompleto _detallesPersonaje;
        public MediaPlayer miMediaPlayer;
        public Uri musica;
        public BitmapImage fotoPersonaje;
        private ImageSource _fondo;

        public ViewModelDetalles()
        {
            musica = new Uri("ms-appx:///Assets/audio/Star Wars_ Revenge Of The Sith - Battle Of The Heroes - John Williams .mp3");
            fondo =  new BitmapImage(new Uri("ms-appx:///Assets/imagenes/fondopordefecto.jpg")); 
        }

        public PersonajeCompleto DetallesPersonaje
        {
            get {
                reproductor();               
                llamarMetodoConvertirImagen();
                return (_detallesPersonaje); }
            set { _detallesPersonaje = value; NotifyPropertyChanged("DetallesPersonaje"); }
        }


        public ImageSource fondo
        {
            get {
                fondosPersonalizados();
                return (_fondo);}
            set { _fondo = value; NotifyPropertyChanged("fondo"); }
        }

        public void reproductor()
        {
            miMediaPlayer = new MediaPlayer();
            miMediaPlayer.AudioCategory = MediaPlayerAudioCategory.Media;
            asignarAudio();
            miMediaPlayer.Source = MediaSource.CreateFromUri(musica);
            miMediaPlayer.Play();
        }

        public void asignarAudio()
        { 
            switch (_detallesPersonaje.IdPersonaje)
            {
                case 1: case 5: case 6: case 9:
                    musica = new Uri("ms-appx:///Assets/audio/Star Wars- The Imperial March _Darth Vaders Theme_.mp3");
                break;

                case 2: case 3: case 7:
                    musica = new Uri("ms-appx:///Assets/audio/Star Wars Music Theme.mp3");
                    break;
            }
        }


        public void llamarMetodoConvertirImagen()
        {
            convertirUnArrayDeBytsAUnaImagenAsync();
            NotifyPropertyChanged("FotoPersonaje");
        }



        /// <summary>
        /// este metodo sirve para convertir un array de bytes en una imagen
        /// </summary>
        /// <returns></returns>
        public async Task<ImageSource> convertirUnArrayDeBytsAUnaImagenAsync()
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(_detallesPersonaje.Foto);
                    await writer.StoreAsync();
                }
                fotoPersonaje = new BitmapImage();
                await fotoPersonaje.SetSourceAsync(stream);
                return fotoPersonaje;
            }
        }

        public void fondosPersonalizados()
        {
            switch (_detallesPersonaje.IdPersonaje)
            {
                case 1:                   
                     fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/fondoDark.jpg"));
                    break;
                case 2:
                    fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/obiwankenobi.jpg"));
                    break;
                case 3:
                    fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/yoda.jpg"));
                    break;
                case 4:
                    fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/c3po.jpg"));
                    break;
                case 5:
                    fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/jarjarbinks.jpg"));
                    break;
                case 6:
                    fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/lukeskywalker.jpg"));
                    break;
                case 7:
                    fondo = new BitmapImage(new Uri("ms-appx:///Assets/imagenes/chewbacca.jpg"));
                    break;


            }

        }

    }
}
