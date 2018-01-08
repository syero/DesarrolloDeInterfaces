using Juego.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

/**Proporciona un conjunto de métodos y propiedades que puede usar para medir el tiempo transcurrido con precisión.
   Un Stopwatch instancia puede medir el tiempo transcurrido para un intervalo o el total de tiempo transcurrido entre varios intervalos. 
   En un típico Stopwatch escenario, se llama a la Start método, utilizamos finalmente el Stop método y, a continuación, compruebe el tiempo transcurrido mediante la Elapsed propiedad.
 */

namespace Juego.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        private ObservableCollection<Carta> _cartas;
        private ObservableCollection<Carta> _listaCartasAux;

        private Carta _cartaSeleccionada;
        private Carta _cartaAuxiliar;

        private int _contadorParejasAcertadas;
        private int _contadorDeJugadas;
        private bool _gana;
        private bool _estaSeleccionada;
        DispatcherTimer temporizador;
        public Stopwatch tiempoDeJuego = new Stopwatch(); 
        private Uri uridefault = new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute);
        private String _reloj;
        private String _textoGanaPierde;

        ListaCartas lista = new ListaCartas();


        public MainPageVM()
        {
            _cartas = lista.obtenerCartas();
            NotifyPropertyChanged("Cartas");

            _contadorParejasAcertadas = 0;
            _contadorDeJugadas = 0;
            Gana = false;
            EstaSeleccionada = true;

            temporizador = new DispatcherTimer();
            temporizador.Interval = TimeSpan.FromSeconds(1);
            temporizador.Tick += tiempoTranscurrido;
            temporizador.Start();

            tiempoDeJuego.Start();


        }


        #region Gets y Sets

        public bool EstaSeleccionada
        {
            get{ return this._estaSeleccionada; }
            set
            {
                this._estaSeleccionada = value;
                NotifyPropertyChanged("EstaSeleccionada");
            }
        }

        public int ContadorDeJugadas
        {
            get { return _contadorDeJugadas; }
            set
            {
                this._contadorDeJugadas = value;
                NotifyPropertyChanged("ContadorDeJugadas");
            }
        }

        public String Reloj
        {
            get { return this._reloj; }
            set
            {
                this._reloj = value;
                NotifyPropertyChanged("Reloj");
            }
        }

        public Carta CartaSeleccionada
        {
            get { return this._cartaSeleccionada; }
            set
            {

                if (_cartaSeleccionada == null || _cartaSeleccionada != _cartaAuxiliar)
                {
                    
                    this._cartaSeleccionada = value;

                    if (_cartaSeleccionada.uri == uridefault)
                    {
                        _cartaSeleccionada.uri = this.girarCarta(CartaSeleccionada.nombre);
                         NotifyPropertyChanged("CartaSeleccionada");

                        _cartaAuxiliar = _cartaSeleccionada;
                    }
                }else
                {
                    this._cartaSeleccionada = value;
                    NotifyPropertyChanged("CartaSeleccionada");

                    if (!(_cartaSeleccionada == _cartaAuxiliar) && _cartaSeleccionada.uri == uridefault)
                    {
                        _cartaSeleccionada.uri = this.girarCarta(CartaSeleccionada.nombre);
                         NotifyPropertyChanged("CartaSeleccionada");

                    }

                    this.comprobarJugada();
                }
                

            }
        }



        public bool Gana
        {
            get{ return this._gana; }
            set
            {
                this._gana = value;
                NotifyPropertyChanged("Gana");
            }
        }

        public String textoGanaPierde
        {
            get { return this._textoGanaPierde; }
            set
            {
                this._textoGanaPierde = value;      
                NotifyPropertyChanged("textoGanaPierde");
            }

        }

        
        public Carta CartaAuxiliar
        {
            get{ return this._cartaAuxiliar; }
            set
            {
                this._cartaAuxiliar = value;
                NotifyPropertyChanged("CartaAuxiliar");
            }
        }

        public ObservableCollection<Carta> Cartas
        {
            get{ return this._cartas; }
            set
            {
                this._cartas = value;
                NotifyPropertyChanged("Cartas");
            }
        }

        #endregion

        #region metodos
        /// <summary>
        /// Metodo para muestra la carta que esta detras del la carta seleccionada
        /// </summary>
        public Uri girarCarta(String nombre)
        {
            Uri uri = null;

            switch (nombre)
            {
                case "Alicia":
                    uri = new Uri("ms-appx://Juego/Imagenes/alicia.jpg", UriKind.Absolute);
                    break;

                case "Gato":
                    uri = new Uri("ms-appx://Juego/Imagenes/gato.jpg", UriKind.Absolute);
                    break;

                case "BellaYBestia":
                    uri = new Uri("ms-appx://Juego/Imagenes/bellaybestia.jpg", UriKind.Absolute);
                    break;

                case "Lumiere":
                    uri = new Uri("ms-appx://Juego/Imagenes/lumiere.jpg", UriKind.Absolute);
                    break;

                case "Cocodrilo":
                    uri = new Uri("ms-appx://Juego/Imagenes/cocodrilo.jpg", UriKind.Absolute);
                    break;

                case "Mickey":
                    uri = new Uri("ms-appx://Juego/Imagenes/mickey.jpg", UriKind.Absolute);
                    break;

                case "DamaYVagabundo":
                    uri = new Uri("ms-appx://Juego/Imagenes/damayvagabundo.jpg", UriKind.Absolute);
                    break;

                case "FamiliaDamaYVagabundo":
                    uri = new Uri("ms-appx://Juego/Imagenes/familiadamayvagabundo.jpg", UriKind.Absolute);
                    break;

                case "Garfio":
                    uri = new Uri("ms-appx://Juego/Imagenes/garfio.png", UriKind.Absolute);
                    break;

                case "PeterPan":
                    uri = new Uri("ms-appx://Juego/Imagenes/peterpan.jpg", UriKind.Absolute);
                    break;

                case "Mapache":
                    uri = new Uri("ms-appx://Juego/Imagenes/mapache.jpg", UriKind.Absolute);
                    break;

                case "Pocahontas":
                    uri = new Uri("ms-appx://Juego/Imagenes/pocahontas.jpg", UriKind.Absolute);
                    break;
            }

            return uri;

        }


        /// <summary>
        ///  Este metodos compruba si la jugada realizada es correcta o no, si es correcta se quedan
        ///  descubiertas las cartas seleccionada en caso de no ser correcta las cartas vuelven a quedar ocultas
        ///  no devuelve nada
        /// </summary>
        private void comprobarJugada()
        {           
            _contadorDeJugadas++;
            NotifyPropertyChanged("ContadorDeJugadas");

            if (_contadorDeJugadas <= 10)
            {
                if (_cartaAuxiliar.idCarta == _cartaSeleccionada.idCarta)
                {
                    _contadorParejasAcertadas++;
                    _cartaSeleccionada = null;
                    _cartaAuxiliar = null;
                    NotifyPropertyChanged("CartaSeleccionada");
                }
                else
                {
                    giraCartasIncorrectas();
                }
            }
            else
            {
                comprobarGanadorJuego();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void comprobarGanadorJuego()
        {

            if(_contadorParejasAcertadas == 6)
            {
                Gana = true;
                _textoGanaPierde = " HA GANADO ¡¡¡¡ FELICIDADES !!!!";
                NotifyPropertyChanged("textoGanaPierde");
                tiempoDeJuego.Stop();

            }
            else
            {
                Gana = true;
                _textoGanaPierde = "HA PERDIDO";
                NotifyPropertyChanged("textoGanaPierde");
                tiempoDeJuego.Stop();
                _contadorDeJugadas = 0;

                //giraCartasIncorrectas();
                //_cartas.Clear();
                //_cartas = lista.obtenerCartas();
                //NotifyPropertyChanged("Cartas");
            }

        }

        //private void comprobarJugada()
        //{
        //     if (_cartaAuxiliar.idCarta == _cartaSeleccionada.idCarta)
        //        {
        //            _contadorParejasAcertadas++;
        //            _cartaSeleccionada = null;
        //            _cartaAuxiliar = null;
        //            NotifyPropertyChanged("CartaSeleccionada");

        //        }
        //        else
        //        {
        //            giraCartasIncorrectas();

        //        }
        //        if (_contadorParejasAcertadas == 6)
        //        {
        //            Gana = true;
        //            _textoGanaPierde = " HA GANADO ¡¡¡¡ FELICIDADES !!!!";
        //            NotifyPropertyChanged("textoGanaPierde");
        //            tiempoDeJuego.Stop();

        //        }

        //}


        /// <summary>
        /// Este metodo retrasa la proxima instruccion cuando las cartas seleccionadas son diferentes 
        /// </summary>
        public async void giraCartasIncorrectas()
        {
            EstaSeleccionada = false;
            await Task.Delay(1000);
            EstaSeleccionada = true;

            _cartaSeleccionada.uri = uridefault;
            NotifyPropertyChanged("CartaSeleccionada");

            _cartaSeleccionada = _cartaAuxiliar;
            _cartaSeleccionada.uri = uridefault;
            NotifyPropertyChanged("CartaSeleccionada");

            _cartaSeleccionada = null;
            _cartaAuxiliar = null;
            NotifyPropertyChanged("CartaSeleccionada");

        }



        /// <summary>
        /// Este metodo comprueba el tiempo transcurrido mediante la Elapsed propiedad del Stopwatch 
        /// utilizamos finalmente el Stop método y, a continuación,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       public void tiempoTranscurrido(object sender, object e)
        {
            Reloj = string.Format("{0}:{1}:{2}", tiempoDeJuego.Elapsed.Hours.ToString(), tiempoDeJuego.Elapsed.Minutes.ToString(), tiempoDeJuego.Elapsed.Seconds.ToString());
        }
        #endregion
 
        /// <summary>
        /// Este metod permite realizar el efecto de que se gire la carta cuando se le de click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void giraCartaPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            storyboard.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            DoubleAnimation rotateAnimation = new DoubleAnimation();

            rotateAnimation.From = 90.0;
            rotateAnimation.To = 0.0;
            rotateAnimation.Duration = storyboard.Duration;

            Storyboard.SetTarget(rotateAnimation, (Image)e.OriginalSource);
            Storyboard.SetTargetProperty(rotateAnimation, "(UIElement.Projection).(PlaneProjection.RotationY)");


            storyboard.Children.Add(rotateAnimation);

            storyboard.Begin();
        }
    }
}

