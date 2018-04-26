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
        private PersonajeCompleto _detallesPersonaje;
        public static MediaPlayer miMediaPlayer; //necesito que sea static para poder detener la musica en el App cuando navego para atras
        public Uri musica;
        public BitmapImage fotoPersonaje;
        private ImageSource _fotoConvertida;
        private ImageSource _fondo;

        public ViewModelDetalles()
        {
            fondo =  new BitmapImage(new Uri("ms-appx:///Assets/imagenes/fondopordefecto.jpg")); //fondo por defeto por que no le he puesto imagen de fondo personalida a todos los personajes
        }

        public PersonajeCompleto DetallesPersonaje
        {
            get { return (_detallesPersonaje); }
            set { _detallesPersonaje = value;
                reproductor();
                fondosPersonalizados();
                llamarMetodoConvertirImagen();
                NotifyPropertyChanged("DetallesPersonaje"); }
        }

        public ImageSource fondo
        {
            get {return (_fondo);}
            set { _fondo = value;               
                NotifyPropertyChanged("fondo"); }
        }

        public ImageSource FotoConvertida
        {
            get
            {return (_fotoConvertida);}
            set { _fotoConvertida = value; NotifyPropertyChanged("FotoConvertida"); }
        }

        /// <summary>
        /// Este metodo es para gestionar el reproductor de la musica del personaje
        /// </summary>
        public void reproductor()
        {
            miMediaPlayer = new MediaPlayer();
            miMediaPlayer.AudioCategory = MediaPlayerAudioCategory.Media;
            asignarAudio();
            miMediaPlayer.Source = MediaSource.CreateFromUri(musica);
            miMediaPlayer.Play();
        }

        /// <summary>
        /// Este metodo me permite asiganr un audio personalizado a los personajes buenos y malos
        /// </summary>
        public void asignarAudio()
        { 
            switch (_detallesPersonaje.IdPersonaje)
            {
                case 1: case 5: case 6: case 9:  case 10: case 12: case 14: case 15: case 16: case 17:
                    musica = new Uri("ms-appx:///Assets/audio/Star Wars- The Imperial March _Darth Vaders Theme_.mp3");
                break;

                case 2: case 3: case 4: case 7: case 8: case 11: case 13: 
                    musica = new Uri("ms-appx:///Assets/audio/Star Wars Music Theme.mp3");
                    break;
            }
        }

        /// <summary>
        /// Este metodo llama al metodo asincrono que convierte un array de bytes en un ImageSource
        /// </summary>
        public void llamarMetodoConvertirImagen()
        {
            convertirUnArrayDeBytsAUnaImagenAsync();         
        }



        /// <summary>
        /// este metodo sirve para convertir un array de bytes en un ImageSource
        /// </summary>
        /// <returns></returns>
        private async Task convertirUnArrayDeBytsAUnaImagenAsync()
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
                FotoConvertida = fotoPersonaje;
            }
        }


        /// <summary>
        /// Este metodo es para ponerle un fonso personalizado a cada personajes
        /// </summary>
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
