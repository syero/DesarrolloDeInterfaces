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
        #endregion   //cerramos la region

        private GestionadoraBL gestionBL;
        private ListadoPersonasBL personas;


        #region "Constructor"
        public MainPageMV()
        {
            
            gestionBL = new GestionadoraBL();
            personas = new ListadoPersonasBL();

            _listpersonas = new ObservableCollection<Persona>(personas.getListaPersonaBL());
            _listAuxiliarParaBuscarPersonas =new ObservableCollection<Persona>(_listpersonas);

            _delegateCommandEliminarPersona = new DelegateCommand(ExecuteEliminarPersona, CanExecuteEliminarPersona);
            _delegateCommandAgregar = new DelegateCommand(ExecuteAgregarPersona);
            _delegateCommandGuardar = new DelegateCommand(ExecuteGuardarPersona, CanExecuteGuardarPersona);
            _delegateCommandBuscar = new DelegateCommand(ExecuteBuscarPersona, CanExecuteBuscarPersona);


        }
        #endregion

        //getes y setes
        #region "GetesSetes"
        public ObservableCollection<Persona> ListaDepersonas
        {
            get { return _listpersonas; }
            set
            {
                this._listpersonas = value;
                NotifyPropertyChanged("ListaDepersonas");
            }
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
                _delegateCommandAgregar.RaiseCanExecuteChanged();
                _delegateCommandGuardar.RaiseCanExecuteChanged();
                _delegateCommandBuscar.RaiseCanExecuteChanged();

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
            set
            {
                _listAuxiliarParaBuscarPersonas = value;
                //Notificación a la vista
                NotifyPropertyChanged("_ListaAuxiliarParaBuscarPersonas");
            }
        }

        /// <summary>
        /// texto a buscar 
        /// </summary>
        public String TxtBuscar
        {
            get { return _txtBuscar; }
            set
            {
                _txtBuscar = value;
                //Notificación a la vista
                _delegateCommandBuscar.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand delegateCommandBuscar
        {
            get
            {
                return _delegateCommandBuscar;
            }
            set
            {
                _delegateCommandBuscar = value;
            }
        }

        /// <summary>
        /// get del delegate command para eliminar persona 
        /// </summary>
        public DelegateCommand delegateCommandEliminarPersona
        {
            get
            {
                return _delegateCommandEliminarPersona;
            }
        }

        /// <summary>
        /// get del delegate command para guardar persona 
        /// </summary>
        public DelegateCommand delegateCommandGuardar
        {
            get
            {
                return _delegateCommandGuardar;
            }
        }

        /// <summary>
        /// get del delegate command para agregar persona 
        /// </summary>
        public DelegateCommand delegateCommandAgregar
        {
            get
            {
                return _delegateCommandAgregar;
            }
        }

        //esto ya no vale pa na
        /*   public int IndicePersonaSeleccionada
           {
               get { return _indicePersonaseleccionada; }
               set { this._indicePersonaseleccionada = value; }

           }*/

        #endregion

        /// <summary>
        /// execute para guardar una persona
        /// </summary>
        private void ExecuteGuardarPersona()
        {

            if (_personaSeleccionada != null && _personaSeleccionada.idPersona < 0)
            {
                _personaSeleccionada.idPersona = ListaDepersonas.ElementAt(ListaDepersonas.Count - 1).idPersona + 1;
                NotifyPropertyChanged("PersonaSeleccionada");
                ListaDepersonas.Add(_personaSeleccionada);
                NotifyPropertyChanged("ListaDepersonas");
            }
        }


        /// <summary>
        /// este es el canExecute de Guardar Persona
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteGuardarPersona()
        {
            bool hayPersonaModificadaONueva = false;

            if (_personaSeleccionada != null && !String.IsNullOrWhiteSpace(_personaSeleccionada.nombre))
            {
                hayPersonaModificadaONueva = true;
            }
            return (hayPersonaModificadaONueva);


        }

        /// <summary>
        /// execute para Eliminar una persona
        /// </summary>
        private void ExecuteEliminarPersona()
        {
            this._listpersonas.Remove(_personaSeleccionada);
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
        /// 
        /// </summary>
        private void ExecuteAgregarPersona()
        {
            _personaSeleccionada = new Persona();
            NotifyPropertyChanged("PersonaSeleccionada");
            _delegateCommandGuardar.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///  mantiene deshabilitado el boton de buscar mientras no se escriba nada en el campo de texto
        /// </summary>
        /// <returns></returns>

        public bool CanExecuteBuscarPersona()
        {
            bool quieroBuscar = false;
            if (!String.IsNullOrEmpty(TxtBuscar))
            {
                quieroBuscar = true;
            }
            else
            {
                ListaAuxiliarParaBuscarPersonas = ListaDepersonas;
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
                if ((ListaDepersonas.ElementAt(i).nombre.ToLower().StartsWith(TxtBuscar)) || (ListaDepersonas.ElementAt(i).apellidos.ToLower().StartsWith(TxtBuscar)))
                {
                    ListaAuxiliarParaBuscarPersonas.Add(ListaDepersonas.ElementAt(i));
                }
            }
            NotifyPropertyChanged("mListaConBusqueda");
        }
/*
        public void Buscar()
        {
            ListaAuxiliarParaBuscarPersonas = new ObservableCollection<Persona>();
            var query = from persona in ListaAuxiliarParaBuscarPersonas
                        where (persona.nombre.ToLower().StartsWith(TxtBuscar) || (persona.apellidos.ToLower().StartsWith(TxtBuscar);
        }
        */

    }
}
