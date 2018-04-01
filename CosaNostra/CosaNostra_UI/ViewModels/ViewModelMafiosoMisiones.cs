using CosaNostra_BL.Gestionadora_BL;
using CosaNostra_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CosaNostra_UI.ViewModels
{
    public class ViewModelMafiosoMisiones : Base
    {
        #region "Atributos"
        private Mafioso _mafioso;

        private ObservableCollection<Mision> _misiones;
        private Mision _misionSeleccionada;
        public DateTime fechaMisionCumplida;
        
        Gestionadora_BL gestionadora = new Gestionadora_BL();

        public ViewModelMafiosoMisiones() { }

        #endregion


        #region "Gete and Setes"

        public Mafioso Mafioso
        {
            get { return (_mafioso); }
            set { this._mafioso = value; NotifyPropertyChanged("Mafioso"); }
        }

        public ObservableCollection<Mision> Misiones
        {
            get {
                obtenerMisiones();
                return (_misiones); }
            set { this._misiones = value; NotifyPropertyChanged("Misiones"); }
        }

        public Mision MisionSeleccionada
        {
            get { return (_misionSeleccionada); }
            set {
                this._misionSeleccionada = value;
                NotifyPropertyChanged("MisionSeleccionada");
            }
        }
        
        #endregion


        #region "Metodos"

        public void obtenerMisiones()
        {
            _misiones = new ObservableCollection<Mision>(gestionadora.obtenerMisionesNoReservadasNiCumplidasBL(_mafioso.codigoMafioso));    
        }

        /// <summary>
        /// Para obtener los datos del datapicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void asignarFechaMisionCumplida(object sender, DatePickerValueChangedEventArgs e)
        {
             DatePicker datePicker = sender as DatePicker;
             var date = datePicker.Date;
             var dia = date.Day;
             var mes = date.Month;
             var anio = date.Year;
            _misionSeleccionada.FechaCumplimiento = new DateTime(anio, mes, dia);
            NotifyPropertyChanged("MisionSeleccionada");
        }

        /// <summary>
        /// Este metod es para reservar la mision
        /// En caso de que la mision ya este reservada mostrara un cuadro de dialogo
        /// de indicara al usuario que nos puede reservar misiones reservadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       public void reservarMision()
       {
            if (_misionSeleccionada.Reservada != true)
            {
                gestionadora.reservarMisionBL(_misionSeleccionada.CondigoMision, _mafioso.codigoMafioso);
            }else {
                DisplayDialogMisionYaReservada();
            }             
            NotifyPropertyChanged("MisionSeleccionada");
            NotifyPropertyChanged("Misiones");
        }

        /// <summary>
        /// Este metodo nos va a permitir rellenar los datos restantes
        /// de la mision que hemos reservado una ves que la hayamos cumplido.
        /// Mostrar un cartel de error si
        /// la fecha de cumplimiento es menor a la fecha actual y la 
        /// mision tiene que estar reservada antes de ser completada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void completarMision()
        {
            if (_misionSeleccionada.Reservada == true && _misionSeleccionada.FechaCumplimiento >= DateTime.Now) 
            {
                gestionadora.misionCumplidaBL(_misionSeleccionada.CondigoMision, _misionSeleccionada.FechaCumplimiento, _misionSeleccionada.Observaciones);
            }
            else
            {
                DisplayDialogErrorCompletarMision();
            }           
            NotifyPropertyChanged("MisionSeleccionada");
            NotifyPropertyChanged("Misiones");
        }

        /// <summary>
        /// Dialogo de error para misiones no reservadas
        /// </summary>
        public async void DisplayDialogMisionYaReservada()
        {
            ContentDialog Dialog = new ContentDialog
            {
                Title = "Mision Reservada",
                Content = "No puede reservar una mision reservada",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await Dialog.ShowAsync();
        }

        /// <summary>
        /// Dialogo de error para cuando el mafioso 
        /// quiere completar una mision sin antes reservala 
        /// o para cuando pone un fecha anterios a la actual.
        /// </summary>
        public async void DisplayDialogErrorCompletarMision()
        {
            ContentDialog Dialog = new ContentDialog
            {
                Title = "Datos incorrectos",
                Content = "No puede guardar una mision si no esta reservada o poner una fecha anterior al dia de hoy ",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await Dialog.ShowAsync();
        }
        #endregion

    }
}
