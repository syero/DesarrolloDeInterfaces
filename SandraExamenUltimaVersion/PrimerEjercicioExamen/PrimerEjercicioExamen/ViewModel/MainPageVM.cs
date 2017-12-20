using PrimerEjercicioExamen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;

namespace PrimerEjercicioExamen.ViewModel
{
   public class MainPageVM:clsVMBase
    {
          
        private Imagen _imagenOriginal;
        private Imagen _imagenConDiferencias;
        private double _opacidad;
        private int _diferenciasAcertadas;
        private Ellipse elipse;
        private ObservableCollection<Ellipse> elipses=new ObservableCollection<Ellipse>();

        public MainPageVM()
        {
            _imagenOriginal = new Imagen("ImagenOriginal", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias.jpg", UriKind.Absolute));
            _imagenConDiferencias = new Imagen("ImagenConDiferencias", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias2.jpg", UriKind.Absolute));
            _opacidad = 0;
            _diferenciasAcertadas = 0;
         }

        public Imagen ImagenOriginal
        {
            get { return _imagenOriginal; }
            set { this._imagenOriginal = value; NotifyPropertyChanged("ImagenOriginal"); }
        }

        public Imagen ImagenConDiferencias
        {
            get { return _imagenConDiferencias; }
            set { _imagenConDiferencias = value; NotifyPropertyChanged("ImagenConDiferencias"); }
        }

        public double Opacidad
        {
            get { return _opacidad; }
            set {this._opacidad = value; NotifyPropertyChanged("Opacidad"); }
        }


        public int DiferenciasAcertadas
        {
            get { return _diferenciasAcertadas; }
            set { this._diferenciasAcertadas=value; NotifyPropertyChanged("DiferenciasAcertadas"); }
        }

        /// <summary>
        /// este metodo es el que hace que se muestre la elipce cuando le damos click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MetodoPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            elipse = (Ellipse)sender;

          if(_opacidad==0) // if (elipse.GetValue(UIElement.OpacityProperty).ToString().Equals("0"))
            {
                elipse.SetValue(UIElement.OpacityProperty, 1);
                _diferenciasAcertadas++;

                elipses.Add(elipse);

                if (_diferenciasAcertadas == 7)
                {
                    DeseaVolverAJugar();
                }
            }
            
        }

        public async void DeseaVolverAJugar()
        {            
                ContentDialog VolverAJugar = new ContentDialog();
                VolverAJugar.Title = "Volver a jugar";
                VolverAJugar.Content = "¿Desea volver a jugar?";
                VolverAJugar.PrimaryButtonText = "Sí";
                VolverAJugar.SecondaryButtonText = "No";

                ContentDialogResult resultado = await VolverAJugar.ShowAsync();
                if (resultado == ContentDialogResult.Primary)
                {
                    _diferenciasAcertadas = 0;
                    NotifyPropertyChanged("DiferenciasAcertadas");

                for (int i=0 ; i<elipses.Count();i++)
                {
                   elipses.ElementAt(i).SetValue(UIElement.OpacityProperty, 0);

                }
                 

            }
        }
    }
}
