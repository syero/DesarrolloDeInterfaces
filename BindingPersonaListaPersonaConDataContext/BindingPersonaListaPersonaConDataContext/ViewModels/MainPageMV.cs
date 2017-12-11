using BindingPersonaListaPersonaConDataContext.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPersonaListaPersonaConDataContext.ViewModels
{

    /**
     En este ViewModel  vamos a tener el listado de las personas que se mostara en el ListView(listado de personas) 
     y la personas seleccionada que se mostrara en el formulario(Grid) del MainPage.xaml 
    */

   public class MainPageMV : INotifyPropertyChanged
    {
        //abrimos  la region
        #region "Atributos"   
        private Persona _personaSeleccionada;
        private ObservableCollection<Persona> _listpersonas;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion   //cerramos la region


        #region "Constructor"
        public MainPageMV()
        {
             clsListadoPersonas personas = new clsListadoPersonas();
             _listpersonas = personas.ObtenerListado();
            
        }
        #endregion

        //getes y setes
        #region "GetesSetes"
        public ObservableCollection<Persona> ListaDepersonas
        {

            get { return _listpersonas; }
            set { this._listpersonas = value; }
        }

        //personaSeleccionada
        public Persona PersonaSeleccionada
        {
            get { return (_personaSeleccionada); }
            set {
                 this._personaSeleccionada = value;
                 //notificacion del cambio para la vista
                 OnPropertyChanged("PersonaSeleccionada");
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// 
      
        protected void OnPropertyChanged(string nombrePropiedad)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nombrePropiedad));
            }
        }
        #endregion

    }
}
