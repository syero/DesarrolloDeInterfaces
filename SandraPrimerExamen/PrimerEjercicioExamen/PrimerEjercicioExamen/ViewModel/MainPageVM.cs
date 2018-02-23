using PrimerEjercicioExamen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace PrimerEjercicioExamen.ViewModel
{
   public class MainPageVM:clsVMBase
    {
       // private ObservableCollection<Imagen> _imagenes;

       // private Imagen _imagenSeleccionada;       
        private Imagen _imagenOriginal;
        private Imagen _imagenConDiferencias;
        private int _opacidad;
       
        
        public MainPageVM()
        {
            /*
            Imagenes obtenerImagenes = new Imagenes();
            _imagenes = obtenerImagenes.imagenes();*/

            _imagenOriginal = new Imagen("ImagenOriginal", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias.jpg", UriKind.Absolute));
            _imagenConDiferencias = new Imagen("ImagenConDiferencias", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias2.jpg", UriKind.Absolute));

         }

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

        public int Opacidad
        {
            get { return _opacidad; }
            set { _opacidad = value; NotifyPropertyChanged("Opacidad"); }
        }

        public void MetodoPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _opacidad = 1;

        }


    }
}
