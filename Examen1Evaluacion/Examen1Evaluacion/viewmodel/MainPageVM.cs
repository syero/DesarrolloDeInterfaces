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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace Examen1Evaluacion
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<Carta> _lista;
        private Carta _cartaSeleccionada;
        private Carta _cartaaux;
        private int parejasencontradas;
        private bool _haganado;
        private bool _clickeable;
        DispatcherTimer timer;
        public Stopwatch miReloj = new Stopwatch();
        private Uri uridefault = new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute);
        private String _textoreloj;

        public MainPageVM()
        {
            _lista = new Listado().list;
            NotifyPropertyChanged("lista");
            parejasencontradas = 0;
            haganado = false;

            clickeable = true;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            miReloj.Start();


        }


        #region getters&setters

        public bool clickeable
        {
            get
            {
                return this._clickeable;
            }
            set
            {
                this._clickeable = value;
                NotifyPropertyChanged("clickeable");
            }
        }

        public String textoreloj
        {
            get
            {
                return this._textoreloj;
            }
            set
            {
                this._textoreloj = value;
                NotifyPropertyChanged("textoreloj");
            }
        }

        public Carta cartaSeleccionada
        {
            get
            {
                return this._cartaSeleccionada;
            }
            set
            {
                
                if (_cartaSeleccionada == null || _cartaSeleccionada!=_cartaaux)
                {
                    this._cartaSeleccionada = value;
                    if (_cartaSeleccionada.uri == uridefault)
                    {
                        _cartaSeleccionada.uri = this.cambiaFoto(cartaSeleccionada.nombre);
                        
                        NotifyPropertyChanged("cartaSeleccionada");
                        _cartaaux = _cartaSeleccionada;
                    }
                }

                else
                {
                    _cartaSeleccionada = value;
                    
                    if (!(_cartaSeleccionada == _cartaaux) && _cartaSeleccionada.uri == uridefault)
                    {
                        _cartaSeleccionada.uri = this.cambiaFoto(cartaSeleccionada.nombre);
                        
                        NotifyPropertyChanged("cartaSeleccionada");

                    }
                    this.retrasasegundo();
                }
            }
        }

     

        public bool haganado
        {
            get
            {
                return this._haganado;
            }
            set
            {
                this._haganado = value;
                NotifyPropertyChanged("haganado");
            }
        }
        public Carta cartaaux
        {
            get
            {
                return this._cartaaux;
            }
            set
            {
                this._cartaaux = value;

            }
        }

        public ObservableCollection<Carta> lista
        {
            get
            {
                return this._lista;
            }
            set
            {
                this._lista = value;
                NotifyPropertyChanged("lista");
            }
        }

        #endregion

        #region metodos
        /// <summary>
        /// Metodo para cambiar la foto de default a la original
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Uri cambiaFoto(String nombre)
        {
            Uri uri = null;

            switch (nombre)
            {
                case "AR-15" :
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/AR-15.jpg", UriKind.Absolute);
                    break;
                case "Ballesta":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Ballesta.jpg", UriKind.Absolute);
                    break;
                case "Colt":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Colt.jpg", UriKind.Absolute);
                    break;
                case "Daryl":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Daryl.jpg", UriKind.Absolute);
                    break;
                case "Katana":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Katana.jpg", UriKind.Absolute);
                    break;
                case "Lucille":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Lucille.jpg", UriKind.Absolute);
                    break;
                case "Martillo":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Martillo.jpg", UriKind.Absolute);
                    break;
                case "Michonne":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Michonne.jpg", UriKind.Absolute);
                    break;
                case "Negan":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Negan.jpg", UriKind.Absolute);
                    break;
                case "Rick":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Rick.jpg", UriKind.Absolute);
                    break;
                case "Sasha":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Sasha.jpg", UriKind.Absolute);
                    break;
                case "Tyreese":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Tyreese.jpg", UriKind.Absolute);
                    break;
            }

            return uri;
           
        }


        /// <summary>
        /// Metodo asincrono que retrasa la instruccion siguiente 1 segundo si las dos cartas
        ///     seleccionadas son incorrectas
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void retrasasegundo()
        {
            
            

            if (_cartaaux.id == _cartaSeleccionada.id)
            {
                parejasencontradas++;
                _cartaSeleccionada = null;
                _cartaaux = null;
                NotifyPropertyChanged("cartaSeleccionada");
            }
            else
            {
                clickeable = false;
                await Task.Delay(1000);
                clickeable = true;
                _cartaSeleccionada.uri = uridefault;
                
                NotifyPropertyChanged("cartaSeleccionada");
                
                
                _cartaSeleccionada = _cartaaux;
                _cartaSeleccionada.uri = uridefault;
                
                NotifyPropertyChanged("cartaSeleccionada");
                
                _cartaSeleccionada = null;
                _cartaaux = null;
                NotifyPropertyChanged("cartaSeleccionada");
            }

            if (parejasencontradas == 6)
            {
                haganado = true;
                miReloj.Stop();
            }
        }

        void timer_Tick(object sender, object e)
        {
            textoreloj = string.Format("{0}:{1}:{2}", miReloj.Elapsed.Hours.ToString(), miReloj.Elapsed.Minutes.ToString(), miReloj.Elapsed.Seconds.ToString());
        }
        #endregion
    }
}


