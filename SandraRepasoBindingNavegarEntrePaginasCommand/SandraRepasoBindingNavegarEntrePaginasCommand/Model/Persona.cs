
using SandraRepasoBindingNavegarEntrePaginasCommand.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

/**
 * Añadir las siguientes validaciones a la clase clsPersona:
idPersona debe ser un campo oculto.
Nombre debe ser obligatorio.
Apellidos debe ser obligatorio y menor a 40 caracteres.
fechaNac debe mostrarse en formato fecha corta.
La dirección no debe ser mayor de 200 caracteres.
El teléfono debe cumplir una expresión regular de teléfono español.
Que estas validaciones se vean en la vista.

     
     
     */
/**nunca olvides cambiar el espacio de nombre si te llevas la clase a otro proyecto*/
namespace SandraRepasoBindingNavegarEntrePaginasCommand.Model
{
    public class Persona : clsVMBase
    {

        //declaramos los atributos asi para en el set  poder notoficar si la propiedad cambia 
        private int _idPersona;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNac;
        private string _direccion;
        private string _telefono;  


        //Constructor por defecto
        public Persona()
        {
            _idPersona=-1;
            _nombre = "";
            _apellidos = "";
            _fechaNac =new DateTime();
            _direccion = "";
            _telefono = "";
          
        }

        //Constructor por ordinario
        public Persona(int idPersona, string nNombre, string nApelllidos, DateTime nFechaNac
                        , string nDireccio, string nTelefono)
        {
            _idPersona = idPersona;
            _nombre = nNombre;
            _apellidos = nApelllidos;
            _fechaNac = nFechaNac;
            _direccion = nDireccio;
            _telefono = nTelefono;
        }

        public Persona(string nNombre, string nApelllidos)
        {
            _nombre = nNombre;
            _apellidos = nApelllidos;

        }

        public int IDPersona{
            get { return _idPersona; }
            set {
                this._idPersona = value;
                NotifyPropertyChanged("IDPersona");
            }

        }

        public string Nombre {
            get { return _nombre; }
            set {
                this._nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }
        public string Apellidos {
            get { return _apellidos; }
            set
            {
                this._apellidos = value;
                NotifyPropertyChanged("Apellidos");
            }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNac; }
            set
            {
                this._fechaNac =value;
                NotifyPropertyChanged("FechaNacimiento");
            }
        }


        public string Direccion
        {
            get { return _direccion; }
            set
            {
                this._direccion = value;
                NotifyPropertyChanged("Direccion");
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set {
                this._telefono = value;
                NotifyPropertyChanged("Telefono");
            }          

        }


    }
}