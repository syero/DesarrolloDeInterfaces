﻿
using SegundoEjercicioExamen.ViewModel;
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
namespace SegundoEjercicioExamen.Model
{
    public class Persona : clsVMBase
    {

        //declaramos los atributos asi para en el set  poder notoficar si la propiedad cambia 
        
        private string _nombre;
        private string _apellidos;
       


        //Constructor por defecto
        public Persona()
        {
            
            _nombre = "";
            _apellidos = "";
          
        }

        //Constructor por ordinario
            public Persona(string nNombre, string nApelllidos)
        {
            _nombre = nNombre;
            _apellidos = nApelllidos;

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

      


    }
}