
using SegundoEjercicioExamen.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoEjercicioExamen.Model
{
     public class CFGSDAM:clsVMBase
    {
        #region "Atributos"
            private String _nombre;
            private ObservableCollection<Persona> _listadoAlumnos;
        #endregion

        #region "Constructores"

        public CFGSDAM()
        {
            Nombre = "";
            ListadoAlumnos = null;
        }

        public CFGSDAM(String nNombre, ObservableCollection<Persona> nListadoAlumnos)
            {
                Nombre = nNombre;
                ListadoAlumnos = nListadoAlumnos;
            }


        #endregion


        #region "Gets y Sets"


        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; NotifyPropertyChanged("Nombre"); }

        }
        public ObservableCollection<Persona> ListadoAlumnos
        {
            get { return _listadoAlumnos; }
            set { _listadoAlumnos = value; NotifyPropertyChanged("ListadoAlumnos"); }
        }
        #endregion

        public String toString()
        {
            return (_nombre);
        }
    }
}
