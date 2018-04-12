using StarWar_BL.Gestionadora_BL;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StarWar_UI.ViewModels
{
    public class ViewModelPersonajes : Base
    {
        #region "Atributos"
        private ObservableCollection<PersonajeCompleto> _listadoPersonajes;
        private PersonajeCompleto _personajeSeleccionado;
        private GestionadoraBL gestoraBL = new GestionadoraBL();
        public Pelicula peliculaSeleccionada;

        public ViewModelPersonajes() { }

        #endregion

        #region "Gets y Sets"
        public ObservableCollection<PersonajeCompleto> ListadoPersonajes
        {
            get
            {
                _listadoPersonajes = new ObservableCollection<PersonajeCompleto>(gestoraBL.obtenerPersonajeConNombreDePeliculaYTrilogiaBL(peliculaSeleccionada.IdTrilogia, peliculaSeleccionada.IdPelicula));
                return (_listadoPersonajes);
            }
            set { this._listadoPersonajes = value; NotifyPropertyChanged("ListadoPersonajes"); }
        }

        public PersonajeCompleto PersonajeSeleccionado
        {
            get { return (_personajeSeleccionado); }
            set { this._personajeSeleccionado = value; NotifyPropertyChanged("PersonajeSeleccionado"); }
        }


        #endregion

        #region "Metodos"    
        #endregion

    }
}
