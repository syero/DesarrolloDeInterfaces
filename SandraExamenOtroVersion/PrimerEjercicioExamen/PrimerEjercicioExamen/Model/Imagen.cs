using PrimerEjercicioExamen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicioExamen.Model
{
    public class Imagen:clsVMBase
    {
        private String _nombre;
        private Uri _localizacion;

        public Imagen()
        {
            Nombre = "";
            Localizacion=null;
        }

        public Imagen(String Nnombre, Uri nLocalizacion)
        {
            Nombre = Nnombre;
            Localizacion = nLocalizacion;
        }

        public string Nombre
        { get { return _nombre; } set { _nombre = value; NotifyPropertyChanged("Nombre"); } }

        public Uri Localizacion
        {
            get { return _localizacion; }
            set { _localizacion = value; NotifyPropertyChanged("Localizacion"); }
        }
        
    }
}
