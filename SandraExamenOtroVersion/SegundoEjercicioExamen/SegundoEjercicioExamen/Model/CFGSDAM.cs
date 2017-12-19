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
            private int _idCurso;
            private String _nombre;
            
        #endregion

        #region "Constructores"

        public CFGSDAM()
        {
            _idCurso = 0;
            _nombre = "";
          
        }

        public CFGSDAM(int nIdCurso,String nNombre)
            {
                _idCurso = nIdCurso;
                _nombre = nNombre;
            
            }


        #endregion


        #region "Gets y Sets"

        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value;  }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }

        }
        
        #endregion

        public String toString()
        {
            return (_nombre);
        }
    }
}
