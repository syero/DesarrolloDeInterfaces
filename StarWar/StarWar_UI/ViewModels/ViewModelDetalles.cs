using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWar_UI.ViewModels
{
    public class ViewModelDetalles : Base
    {
        private PersonajeCompleto _detallesPersonaje;
        public MediaPlayer miMediaPlayer;
        public Uri musica;
        private BitmapImage _fotoPersonaje;

        public ViewModelDetalles()
        {
            musica = new Uri("ms-appx:///Assets/audio/Star Wars_ Revenge Of The Sith - Battle Of The Heroes - John Williams .mp3");
        }

        public PersonajeCompleto DetallesPersonaje
        {
            get {
                reproductor();
                llamarMetodoConvertirImagen();
                return (_detallesPersonaje); }
            set { this._detallesPersonaje = value; NotifyPropertyChanged("DetallesPersonaje"); }
        }


        public  BitmapImage FotoPersonaje
        {
            get
            {return (_fotoPersonaje);}
            set { this._fotoPersonaje = value; NotifyPropertyChanged("FotoPersonaje"); }
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
                case 1: case 9:
                    musica = new Uri("ms-appx:///Assets/audio/Star Wars- The Imperial March _Darth Vaders Theme_.mp3");
                break;

                case 2:
                    musica = new Uri("ms-appx:///Assets/audio/Star Wars Music Theme.mp3");
                    break;
            }
        }


        public void llamarMetodoConvertirImagen()
        {
            //ConvertToBitmapImage(_detallesPersonaje.Foto);
            convertirUnArrayDeBytsAUnaImagenAsync();
        }


        //public BitmapImage ConvertToBitmapImage(byte[] image)
        //{
        //    FotoPersonaje = new BitmapImage();
        //    InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream(image);
        //    MemoryStream memoryStream = new MemoryStream(image);
        //    FotoPersonaje.SetSource(memoryStream);
        //    return FotoPersonaje;
        //}



        /// <summary>
        /// este metodo sirve para convertir un array de bytes en una imagen
        /// </summary>
        /// <returns></returns>
        public async Task<BitmapImage> convertirUnArrayDeBytsAUnaImagenAsync()
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(_detallesPersonaje.Foto);
                    await writer.StoreAsync();
                }
                FotoPersonaje = new BitmapImage();
                await FotoPersonaje.SetSourceAsync(stream);
                return FotoPersonaje;
            }
        }

    }
}
