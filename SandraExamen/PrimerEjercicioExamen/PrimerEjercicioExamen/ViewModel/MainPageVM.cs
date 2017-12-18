

using PrimerEjercicioExamen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicioExamen.ViewModel
{
   public class MainPageVM:clsVMBase
    {
       // private ObservableCollection<Imagen> _imagenes;

       // private Imagen _imagenSeleccionada;       
        private Imagen _imagenOriginal;
        private Imagen _imagenConDiferencias;

        private DelegateCommand _pintar;
        
        public MainPageVM()
        {
            /*
            Imagenes obtenerImagenes = new Imagenes();
            _imagenes = obtenerImagenes.imagenes();*/

            _imagenOriginal = new Imagen("ImagenOriginal", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias.jpg", UriKind.Absolute));
            _imagenConDiferencias = new Imagen("ImagenConDiferencias", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias2.jpg", UriKind.Absolute));

        //    ImagenSeleccionada = null;

            _pintar =new DelegateCommand(ExecutePintar,CanExecutePintar);

        }
/*
        public Imagen ImagenSeleccionada
        {
            get { return _imagenSeleccionada; }
            set { _imagenSeleccionada = value; NotifyPropertyChanged("ImagenSeleccionada"); }
        }
        */
        public Imagen ImagenOriginal
        {
            get { return _imagenOriginal; }
            set { _imagenOriginal = value; NotifyPropertyChanged("ImagenOriginal"); }
        }

        public Imagen ImagenConDiferencias
        {
            get { return _imagenConDiferencias; }
            set { _imagenConDiferencias = value; NotifyPropertyChanged("ImagenConDiferencias"); }
        }

        public DelegateCommand Pintar
        {
            get
            {
                return _pintar;
            }
        }

        private void ExecutePintar()
        {
            

        }
        /// <summary>
        /// este es el canExecute de pintar
        /// </summary>
        /// <returns>devuelve si se puede pintar o no</returns>
        private bool CanExecutePintar()
        {
            bool sePuedepintar = false;

            if (ImagenConDiferencias != null )
            {
                sePuedepintar = true;
            }

            return (sePuedepintar);

        }


        /*
        private void abbDibujar_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Inking;
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Touch;
        }*/

        //    public ObservableCollection<Imagen> Imagenes { get { return _imagenes; } set { _imagenes = value; NotifyPropertyChanged("Imagenes"); } }











    }
}
