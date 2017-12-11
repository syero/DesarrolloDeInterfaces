using BindingPersonaListaPersonaConDataContext.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BindingPersonaListaPersonaConDataContext.ViewModels
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
      //private int _indicePersonaseleccionada;

        //DelegateCommands privadas 
        private DelegateCommand _delegateCommandEliminarPersona;
        private DelegateCommand _delegateCommandGuardar;
        private DelegateCommand _delegateCommandAgregar;

        #endregion   //cerramos la region


        #region "Constructor"
        public MainPageMV()
        {

             clsListadoPersonas personas = new clsListadoPersonas();
             _listpersonas = personas.ObtenerListado();
            

            _delegateCommandEliminarPersona = new DelegateCommand(ExecuteEliminarPersona,CanExecuteEliminarPersona);
            _delegateCommandAgregar = new DelegateCommand(ExecuteAgregarPersona);
            _delegateCommandGuardar = new DelegateCommand(ExecuteGuardarPersona,CanExecuteGuardarPersona);
            
        }
        #endregion

        //getes y setes
        #region "GetesSetes"
        public ObservableCollection<Persona> ListaDepersonas
        {

            get { return _listpersonas; }
            set {

                this._listpersonas = value;
               
            }
        }

        /// <summary>
        /// get y set de la persona seleccionada
        /// </summary>
        public Persona PersonaSeleccionada
        {
            get { return (_personaSeleccionada); }
            set {
                 this._personaSeleccionada = value;

                /*este llama al CanExecuteEliminarPersona*/
                _delegateCommandEliminarPersona.RaiseCanExecuteChanged();
                 
                _delegateCommandAgregar.RaiseCanExecuteChanged();               

                _delegateCommandGuardar.RaiseCanExecuteChanged();

                //notificacion del cambio para la vista
                NotifyPropertyChanged("PersonaSeleccionada");

                //RaiseCanExecuteChanged mira el canExecute (a ver si se puede ejecutar o no )
                //delegateCommandEliminarPersona.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// get del delegate command para eliminar persona 
        /// </summary>
        public DelegateCommand delegateCommandEliminarPersona {
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
            
            if (_personaSeleccionada!=null && _personaSeleccionada.IDPersona<0)
            {
                _personaSeleccionada.IDPersona = ListaDepersonas.ElementAt(ListaDepersonas.Count - 1).IDPersona + 1;
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
            bool hayPersonaModificadaONueva=false;

            if (_personaSeleccionada != null &&  !String.IsNullOrWhiteSpace(_personaSeleccionada.Nombre) )
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
        ///este es el  CanExecute para Eliminar una Persona 
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteEliminarPersona() 
        {
            bool hayUnaPersonaSeleccionada = false;

            if (_personaSeleccionada !=null)
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

        }

    }
}
