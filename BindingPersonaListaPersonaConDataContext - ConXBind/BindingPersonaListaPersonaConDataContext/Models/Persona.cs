﻿
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
namespace BindingPersonaListaPersonaConDataContext.Models
{
    public class Persona : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /* 
         *Si no usamos el INotifyPropertyChanged no podemos poner las declareacion es de las veriables,getes y setes asi
         public int idPersona { get; set; }


          public string nombre { get; set; }


          public string apellidos { get; set; }
          //me falta hacer que la fecha se muestre en formato corto correctamente

          public DateTime fechaNac { get; set; }
          
          public string telefono { get; set; }

          public string direccion { get; set; }
*/



        //declaramos los atributos asi para en el set  poder notoficar si la propiedad cambia 
        private static int _idP=0;
        private int _idPersona;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNac;
        private string _direccion;
        private string _telefono;


        //Constructor por defecto
        public Persona()
            {
                _idPersona = _idP;
                        _idP++;
                _nombre = "Sandra";
                _apellidos = "Yero Nevares";
                _fechaNac = DateTime.Now;
                _direccion = "Calle 102 ";
                _telefono = "685597423 ";
        }

        //Constructor por ordinario
        public Persona( string nNombre,string nApelllidos,DateTime nFechaNac
                        ,string nDireccio,string nTelefono)
        {
            _idPersona =_idP;
                    _idP++;
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

        public string Nombre {
            get { return _nombre; }
            set {
                this._nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Apellidos {
            get { return _apellidos; }
            set
            {
                this._apellidos = value;
                OnPropertyChanged("Apellidos");
            }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNac; }
            set
            {
                this._fechaNac = value;
                OnPropertyChanged("FechaNacimiento");
            }
        }


        public string Direccion
        {
            get { return _direccion; }
            set
            {
                this._direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set {
                this._telefono = value;
                OnPropertyChanged("Telefono");
            }          

        }


        protected void OnPropertyChanged(string nombrePropiedad)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nombrePropiedad));
            }
        }
    }
}