using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _13_DataContext.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace _13_DataContext.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {



        #region "Atributos"
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _listaPersonas;
        private DelegateCommand _buscarCommand;
        private DelegateCommand _eliminarCommad;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _nuevoCommand;
        private string _textoABuscar;


        #endregion

        #region "Constructores"
        public clsMainPageVM()
        {
            //Llamamos a un metodo asincrono
            rellenaLista();
           // _personaSeleccionada = new clsPersona();
            _buscarCommand = new DelegateCommand(BuscarCommand_Executed, BuscarCommand_CanExecute);
            _eliminarCommad = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            _guardarCommand = new DelegateCommand(GuardarCommand_Executed);
            _nuevoCommand = new DelegateCommand(NuevoCommand_Executed);
        }

        private async void rellenaLista()
        {
            clsListados oListados = new clsListados();
            _listaPersonas = await oListados.getPersonas();
            NotifyPropertyChanged("listaPersonas");
        }
        #endregion

        #region "Propiedades"


        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                _eliminarCommad.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }


        public string textoABuscar
        {
            get
            {
                return _textoABuscar;
            }
            set
            {
                _textoABuscar = value;
                NotifyPropertyChanged("textoABuscar");
            }
        }

        public ObservableCollection<clsPersona> listaPersonas
        {
            get
            {
                return _listaPersonas;
            }
        }


        public DelegateCommand buscarCommand
        {
            get
            {                
                return _buscarCommand;
            }
        }

        public DelegateCommand eliminarCommand
        {
            get
            {
                return _eliminarCommad;
            }
        }

        public DelegateCommand guardarCommand
        {
            get
            {
                return _guardarCommand;
            }
        }

        public DelegateCommand nuevoCommand
        {
            get
            {
                return _nuevoCommand;
            }
        }

        #endregion


        private void BuscarCommand_Executed()
        {
            //Filtrar
            if (!string.IsNullOrEmpty(_textoABuscar))
            {
                var listaFiltrada = from p in _listaPersonas where p.nombre.StartsWith(_textoABuscar) select p;
                _listaPersonas = new ObservableCollection<clsPersona>(listaFiltrada);


            }
            else
            {
                clsListados oListados = new clsListados();
                _listaPersonas = oListados.listadoPersonas();
            }

            NotifyPropertyChanged("listaPersonas");
        }

        private bool BuscarCommand_CanExecute()
        {
            bool hayEscrito = true;
            //Si no hay nada escrito en el textBox buscar se pone a false

            return hayEscrito;
        }

        public bool EliminarCommand_CanExecute()
        {

            bool sePuedeEliminar = true;

            if (_personaSeleccionada == null)
            {
                sePuedeEliminar = false;
            }

            return sePuedeEliminar;
        }

        public async void EliminarCommand_Executed()
        {
            HttpStatusCode respuesta;
            clsManejadoraPersona oManejadiraPersona = new clsManejadoraPersona();
            ContentDialog confirmarBorrado = new ContentDialog();

            confirmarBorrado.Title = "Eliminar";
            confirmarBorrado.Content = "¿Está seguro de que desa borrar?";
            confirmarBorrado.PrimaryButtonText = "Cancelar";
            confirmarBorrado.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await confirmarBorrado.ShowAsync();
            if (resultado == ContentDialogResult.Secondary)
            {
                try
                {
                    //Task tareaBorrado = Task.Run(async () => await oManejadiraPersona.deletePersonaDAL(_personaSeleccionada.id));
                    //Esperamos a que termine para rellenar la lista
                    //tareaBorrado.Wait();
                    //await oManejadiraPersona.deletePersonaDAL(_personaSeleccionada.id);
                    //Task.WaitAll();

                    respuesta = await oManejadiraPersona.deletePersonaDAL(_personaSeleccionada.id);
                    if (respuesta == HttpStatusCode.Ok)
                    {
                        rellenaLista();

                    }

                }
                catch (Exception)
                {

                    //Mostrar error;
                }


            }
        }

        public async void GuardarCommand_Executed()
        {
            HttpStatusCode respuesta;
            clsManejadoraPersona oManejadiraPersona = new clsManejadoraPersona();

            try
            {
                //Comprobamos si hay que actualizar o insertar
                if (_personaSeleccionada.id != 0)
                {
                    //Es una actualización
                    respuesta = await oManejadiraPersona.actualizaPersonaDAL(_personaSeleccionada.id, _personaSeleccionada);

                }
                else
                {
                    //es una insercion
                    respuesta = await oManejadiraPersona.insertaPersonaDAL(_personaSeleccionada);
                }

                if (respuesta == HttpStatusCode.Ok)
                {
                    rellenaLista();

                }

            }
            catch (Exception)
            {

                //Mostrar error;
            }

        }

        public void NuevoCommand_Executed()
        {
            personaSeleccionada = new clsPersona();
          
        }


    }
}
