using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_DataContext.Models
{
    /// <summary>
    /// 
    /// </summary>

    public class clsPersona : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _nombre;
        //Constructor por defecto
        public clsPersona()
        {
            id = 0;
            nombre = "";
            apellidos = "";
            fechaNac = new DateTime();
            direccion = "";
            telefono = "";

        }

        //Constructor por parametros

        public clsPersona(int parId, String parNombre, String parApellidos, DateTime parFechaNac, string parDireccion, string parTelefono)
        {

            this.id = parId;
            this.nombre = parNombre;
            this.apellidos = parApellidos;
            this.fechaNac = parFechaNac;
            this.direccion = parDireccion;
            this.telefono = parTelefono;
        }

        public int id { get; set; }
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged("nombre");
            }
        }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }


        //  Metodo para lanzar el evento
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}