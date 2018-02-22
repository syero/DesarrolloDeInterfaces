
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _18_CRUD_Personas_UWP_Entidades
{
    public class clsPersona : INotifyPropertyChanged
    {
        #region privados
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _direccion;

        public clsPersona()
        {
            FechaNac = DateTime.Now;
        }
        #endregion
        #region publicas
        public int IdPersona { get; set; }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }
        public string Apellido { get { return _apellido; } set { _apellido = value; NotifyPropertyChanged("Apellido"); } }

        public DateTime FechaNac { get; set; }

        public string Direccion { get { return _direccion; } set { _direccion = value; NotifyPropertyChanged("Direccion"); } }

        public string Telefono { get { return _telefono; } set { _telefono = value; NotifyPropertyChanged("Telefono"); } }
        public int idDepartamento { get; set; }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}