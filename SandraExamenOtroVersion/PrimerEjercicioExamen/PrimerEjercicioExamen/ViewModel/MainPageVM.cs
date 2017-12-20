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
            set { _opacidad = value; NotifyPropertyChanged("Opacidad"); }
        }


        public int DiferenciasAcertadas
        {
            get { return _diferenciasAcertadas; }
            set { this._diferenciasAcertadas=value; NotifyPropertyChanged("DiferenciasAcertados"); }
        }


        public void MetodoPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            
            Ellipse elipse = (Ellipse)sender;

            //Se comprueba si no la diferencia no ha sido ya descubierta para que el jugador no pueda ganar pulsando 7 veces la misma diferencia
            if (elipse.GetValue(UIElement.OpacityProperty).ToString().Equals("0"))
            {
               // Opacidad = 1;
                elipse.SetValue(UIElement.OpacityProperty, 1);
                this._diferenciasAcertadas++;
                DeseaVolverAJugar();
            }

        }

        public async void DeseaVolverAJugar()
        {
            if (_diferenciasAcertadas >= 7)
            {
                ContentDialog VolverAJugar = new ContentDialog();
                VolverAJugar.Title = "Volver a jugar";
                VolverAJugar.Content = "¿Desea volver a jugar?";
                VolverAJugar.PrimaryButtonText = "Sí";
                VolverAJugar.SecondaryButtonText = "No";

                ContentDialogResult resultado = await VolverAJugar.ShowAsync();
                if (resultado == ContentDialogResult.Primary)
                {
                    this._diferenciasAcertadas = 0;

                    //this.elipse0.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipse1.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipse2.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipse3.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipse4.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipse5.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipse6.SetValue(UIElement.OpacityProperty, 0);

                    //this.elipseb0.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipseb1.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipseb2.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipseb3.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipseb4.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipseb5.SetValue(UIElement.OpacityProperty, 0);
                    //this.elipseb6.SetValue(UIElement.OpacityProperty, 0);

                }
            }
        }


        //public void OcultarElipses()
        //{

        //    Ellipse elipse = new Ellipse();

        //    for (int i = 0; i < 7; i++)
        //    { 
        //        if (elipse.Name.Equals("AntonioPodemos") || elipse.Name.Equals("PiernaJavi") || elipse.Name.Equals("GafasRebeca") || elipse.Name.Equals("PinDeFrank")
        //            || elipse.Name.Equals("CascoDeManu") || elipse.Name.Equals("PeloMiguelAngel") || elipse.Name.Equals("CaraPablo"))
        //        {
        //            elipse.SetValue(UIElement.OpacityProperty, 0);

        //        }
        //}
        //}

    }
}
