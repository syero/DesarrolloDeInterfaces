
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
        private CFGSDAM _cursoSeleccionado;
        #endregion


        #region "Constructores"
        public MainPageVM()
        {
            GestionTodosLosListados gestionlistados = new GestionTodosLosListados();
            
            _cursosCiclo = gestionlistados.ObtenerCursosCiclo();
            _cursoSeleccionado = null;
        }

        public MainPageVM(ObservableCollection<CFGSDAM> nCursosCiclo, CFGSDAM nCursoSeleccionado)
        {

            _cursosCiclo = nCursosCiclo;
            _cursoSeleccionado = nCursoSeleccionado;

        }
        #endregion


        #region "Gets y Sets"
            public ObservableCollection<CFGSDAM> CursosCiclo
            {
                get { return _cursosCiclo; }
                set { this._cursosCiclo = value; NotifyPropertyChanged("CursosCiclo"); }
            }

            public CFGSDAM CursoSeleccionado
            {
                get { return _cursoSeleccionado; }
                set { this._cursoSeleccionado = value; NotifyPropertyChanged("CursoSeleccionado"); }

            }
        #endregion


    }
}
