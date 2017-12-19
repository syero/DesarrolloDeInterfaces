
using SegundoEjercicioExamen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoEjercicioExamen.ViewModel
{
   public class MainPageVM:clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<CFGSDAM> _cursosCiclo;
        private ObservableCollection<Alumno> _alumnosDeUnCurso;
        private CFGSDAM _cursoSeleccionado;

        GestionTodosLosListados gestionadora = new GestionTodosLosListados();

        #endregion


        #region "Constructores"
        public MainPageVM()
        {            
            _cursosCiclo = gestionadora.ObtenerCursosCiclo();
            _alumnosDeUnCurso = gestionadora.ObtenerAlumnosPorIdCurso(_cursoSeleccionado.IdCurso);
        }

        #endregion


        #region "Gets y Sets"
        public ObservableCollection<CFGSDAM> CursosCiclo
            {
                get { return _cursosCiclo; }
                set { this._cursosCiclo = value; }
            }

        public ObservableCollection<Alumno> AlumnosDeUnCurso
        {
            get { return _alumnosDeUnCurso; }
            set { this._alumnosDeUnCurso = value;  }
        }
        
        public CFGSDAM CursoSeleccionado
            {
                get { return _cursoSeleccionado; }
                set {  this._cursoSeleccionado = value; NotifyPropertyChanged("CursoSeleccionado"); }

            }

        
        #endregion


    }
}
