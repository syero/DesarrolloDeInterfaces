using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CRUD_Personas_UI.ViewModels
{

    /**
     En este ViewModel  vamos a tener el listado de las personas que se mostara en el ListView(listado de personas) 
     y la personas seleccionada que se mostrara en el formulario(Grid) del MainPage.xaml 
    */

    /*Cada Delegate Command tiene su 
     *      Execute(contiene el código que queremos que se ejecute con el comando)
     *      CanExecute(devuelve el estado del comando, True si está enable y false si está disabled.)
     
     */

    public class MainPageMV : clsVMBase
    {
       
        //abrimos  la region
        #region "Atributos"   
        private Persona _personaSeleccionada;
        private ObservableCollection<Persona> _listpersonas;
        private ObservableCollection<Persona> _listAuxiliarParaBuscarPersonas;
        private String _txtBuscar;
       
        //DelegateCommands privadas 
        private DelegateCommand _delegateCommandEliminarPersona;
        private DelegateCommand _delegateCommandGuardar;
        private DelegateCommand _delegateCommandAgregar;
        private DelegateCommand _delegateCommandBuscar;
        private DelegateCommand _delegateCommandActualizar;              

        private GestionadoraBL gestionBL =new GestionadoraBL();
        ListadoPersonasBL personas = new ListadoPersonasBL();
        private bool _habilitarProgressRing=true;
        private String _mensaje;
        private Boolean _mostrarMensaje;

        #endregion   //cerramos la region

        #region "Constructor"
        public MainPageMV()
        {
            _delegateCommandBuscar = new DelegateCommand(ExecuteBuscarPersona, CanExecuteBuscarPersona);
            _delegateCommandEliminarPersona = new DelegateCommand(ExecuteEliminarPersona, CanExecuteEliminarPersona);
            _delegateCommandGuardar = new DelegateCommand(ExecuteGuardarPersona, CanExecuteGuardarPersona);
            _delegateCommandAgregar = new DelegateCommand(ExecuteAgregarPersona, CanExecuteGuardarPersona);
            _delegateCommandActualizar = new DelegateCommand(ExecuteActualizar);
           
             rellenaListaPersona();
            _mostrarMensaje = false;
        }
        #endregion

        //getes y setes
        #region "GetesSetes"
        public ObservableCollection<Persona> ListaDepersonas
        {
            get { return _listpersonas; }
            set { this._listpersonas = value;  NotifyPropertyChanged("ListaDepersonas"); }
        }

        /// <summary>
        /// get y set de la persona seleccionada
        /// </summary>
        public Persona PersonaSeleccionada
        {
            get { return (_personaSeleccionada); }
            set
            {
                this._personaSeleccionada = value;

                /*este llama al CanExecuteEliminarPersona*/
                _delegateCommandEliminarPersona.RaiseCanExecuteChanged();
                _delegateCommandGuardar.RaiseCanExecuteChanged();

                //notificacion del cambio para la vista
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        /// <summary>
        /// lista auxiliar para buscar
        /// </summary>
        public ObservableCollection<Persona> ListaAuxiliarParaBuscarPersonas
        {
            get { return _listAuxiliarParaBuscarPersonas; }
            set { _listAuxiliarParaBuscarPersonas = value;  NotifyPropertyChanged("ListaAuxiliarParaBuscarPersonas"); }
        }

     
        /// <summary>
        /// 
        /// </summary>
        public bool habilitarProgressRing
        {
            get { return _habilitarProgressRing; }
            set { this._habilitarProgressRing = value; NotifyPropertyChanged("habilitarProgressRing"); }
        }

        /// <summary>
        /// texto a buscar 
        /// </summary>
        public String TxtBuscar
        {
            get { return _txtBuscar; }
            set { _txtBuscar = value;  _delegateCommandBuscar.RaiseCanExecuteChanged(); }
        }

        /// <summary>
        /// Mensaje de notificación, para mostrar si se ha eliminado correctamente una persona
        /// </summary>
        public String mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public Boolean mostrarMensaje
        {
            get { return _mostrarMensaje; }
            set { _mostrarMensaje = value; }           
        }

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand delegateCommandBuscar
        {
            get {  return _delegateCommandBuscar; }
            set { _delegateCommandBuscar = value; }
        }

        /// <summary>
        /// El delegate llama al ExecuteEliminarPersona para eliminar persona 
        /// </summary>
        public DelegateCommand delegateCommandEliminarPersona
        {
            get { return _delegateCommandEliminarPersona;  }
            set { _delegateCommandEliminarPersona = value; }
        }
                

        /// <summary>
        ///  El delegate llama al ExecuteGuardarPersona: Encargado de guardar o insertar una nueva persona a la base de datos.
        ///  Es llamado al ser presionado el boton "Guardar"
        /// </summary>
        public DelegateCommand delegateCommandGuardar
        {
            get { return _delegateCommandGuardar; }
            set { _delegateCommandGuardar = value;}
        }

        /// <summary>
        /// El delegate llama al metodo ExecuteAgregarPersona: Encargado de limpiar los campos a introducir
        /// información de la persona,
        /// </summary>
        public DelegateCommand delegateCommandAgregar
        {
            get { return _delegateCommandAgregar;  }
            set { _delegateCommandAgregar = value; }
        }

        public DelegateCommand actualizarLista
        {
            get { return _delegateCommandActualizar;  }           
            set { _delegateCommandActualizar = value; }
        }

        #endregion

        /// <summary>
        /// Execute para guardar una persona
        /// </summary>
        public async void ExecuteGuardarPersona()
        {
            if (_personaSeleccionada != null)
            {
               await gestionBL.insertarPersonaBL(_personaSeleccionada);
               _listpersonas.Add(_personaSeleccionada);
                rellenaListaPersona();
            }
            else
            {
                HttpStatusCode codigoRespuesta = await gestionBL.actualizarPersonaBL(_personaSeleccionada);

                if ((int)codigoRespuesta == 204)
                {
                    _listpersonas = new ObservableCollection<Persona>(await personas.getListaPersonaBL());
                    ListaAuxiliarParaBuscarPersonas = ListaDepersonas;
                    NotifyPropertyChanged("PersonaSeleccionada");
                }
            }
        }


        /// <summary>
        /// este es el canExecute de Guardar Persona
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteGuardarPersona()
        {
            bool hayPersonaModificadaONueva = false;

            if (_personaSeleccionada != null)
            {
                hayPersonaModificadaONueva = true;
            }
            return (hayPersonaModificadaONueva);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExecuteAgregarPersona()
        {
            _personaSeleccionada = new Persona();
            NotifyPropertyChanged("PersonaSeleccionada");
            _delegateCommandGuardar.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Llamo al metodo de eliminar persona de la gestionadora BL 
        /// </summary>
        public  void ExecuteEliminarPersona()
        {          
            cuadroDeDialogoDelete();            
        }

        /// <summary>
        /// CanExecute para Eliminar una Persona 
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteEliminarPersona()
        {
            bool hayUnaPersonaSeleccionada = false;

            if (_personaSeleccionada != null)
            {
                hayUnaPersonaSeleccionada = true;
            }
            return hayUnaPersonaSeleccionada;

        }

        
        /// <summary>
        ///  mantiene deshabilitado el boton de buscar mientras no se escriba nada en el campo de texto
        /// </summary>
        /// <returns></returns>

        private bool CanExecuteBuscarPersona()
        {
            bool quieroBuscar = false;
            if (!String.IsNullOrEmpty(TxtBuscar))
            {
                quieroBuscar = true;
            }
            else
            {
                ListaAuxiliarParaBuscarPersonas = _listpersonas;
                NotifyPropertyChanged("ListaAuxiliarParaBuscarPersonas");
            }
            return quieroBuscar;
        }

        /// <summary>
        /// Al ejecutarse la busqueda
        /// </summary>
        public void ExecuteBuscarPersona()
        {
            ListaAuxiliarParaBuscarPersonas = new ObservableCollection<Persona>();
            NotifyPropertyChanged("ListaAuxiliarParaBuscarPersonas");

            for (int i = 0; i < ListaDepersonas.Count; i++)
            {
                if ((ListaDepersonas.ElementAt(i).nombre.ToLower().StartsWith(TxtBuscar)) 
                    || (ListaDepersonas.ElementAt(i).apellidos.ToLower().StartsWith(TxtBuscar)))
                {
                    ListaAuxiliarParaBuscarPersonas.Add(ListaDepersonas.ElementAt(i));
                }
            }
            NotifyPropertyChanged("ListaAuxiliarParaBuscarPersonas");
        }

        /// <summary>
        /// 
        /// </summary>
        public async void ExecuteActualizar()
        {
            ListaDepersonas = new ObservableCollection<Persona>(await personas.getListaPersonaBL());
            ListaAuxiliarParaBuscarPersonas = this._listpersonas;

            NotifyPropertyChanged("ListaDepersonas");
            NotifyPropertyChanged("ListaAuxiliarParaBuscarPersonas");
        }


        /// <summary>
        /// Metodo lambada, que recibe un IEnumerable, en este caso, una lista de personas, y ejecuta un for each
        /// Por cada item, ejecuta una action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public void Each<T>(IEnumerable<T> items, Action<T> action)
        {

            foreach (var item in items)
                action(item);
        }

        /// <summary>
        /// 
        /// </summary>
        private async void rellenaListaPersona()
        {
            try
            {                
                _listpersonas = await personas.getListaPersonaBL();
                _listAuxiliarParaBuscarPersonas = _listpersonas;
                _habilitarProgressRing = false;

                NotifyPropertyChanged("ListaDepersonas");
                NotifyPropertyChanged("ListaAuxiliarParaBuscarPersonas");
                NotifyPropertyChanged("habilitarProgressRing");
            }
            catch (Exception e) { }

        }

        /// <summary>
        /// Metodo que muestra un cuadro que pregunta si de verdad desea eliminar  un elemento seleccionado
        /// En caso de dar click a SI, o PrimaryButton, lo borra.
        /// En caso contrario, vuelve a la vista con la lista
        /// </summary>
        public async void cuadroDeDialogoDelete()
        {
            ContentDialog cuadroDialogo = new ContentDialog();
            cuadroDialogo.Title = "Eliminar";
            cuadroDialogo.Content = $"¿Está seguro de que desea eliminar a la persona {_personaSeleccionada.nombre} {_personaSeleccionada.apellidos}?";
            cuadroDialogo.PrimaryButtonText = "Si";
            cuadroDialogo.SecondaryButtonText = "Cancelar";
            ContentDialogResult resultado = await cuadroDialogo.ShowAsync();
            int filasafectadas = 0;
            if (resultado == ContentDialogResult.Primary)
            {
               
                filasafectadas = await gestionBL.eliminarPersona(_personaSeleccionada.idPersona);
                if (filasafectadas == 1)
                {
                    //Hace el efecto inmediato de que borra de lista
                    ListaDepersonas.Remove(_personaSeleccionada);
                    NotifyPropertyChanged("ListaDepersonas");
                    _mensaje = "El elemento ha sido borrado";
                    _mostrarMensaje = true;
                }

            }

        }

    }
}
