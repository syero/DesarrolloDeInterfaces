
using System;
using System.Collections.Generic;
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
namespace MostrarUnaListaPersonaConDataContext.Models
{
    public class Persona
    {
        public int idPersona { get; set; }

        public string imagen { get; set; }

        public string nombre { get; set; }

        
        public string apellidos { get; set; }
        //me falta hacer que la fecha se muestre en formato corto correctamente
       
        public DateTime fechaNac { get; set; }

        
        public string direccion { get; set; }

        
        public string telefono { get; set; }

        private static int idP=0;

        //Constructor por defecto
        public Persona()
            {
                idPersona = idP;
                        idP++;
                imagen = "";
                nombre ="";
                apellidos ="";
                fechaNac = DateTime.Now;
                direccion = "";
                telefono = "";
        }

        //Constructor por ordinario
        public Persona(string nImagen, string nNombre,string nApelllidos,DateTime nFechaNac
                        ,string nDireccio,string nTelefono)
        {
            idPersona = idP;
                    idP++;
            imagen = nImagen;
            nombre = nNombre;
            apellidos = nApelllidos;
            fechaNac = nFechaNac;
            direccion = nDireccio;
            telefono = nTelefono;
        }

        public Persona(string nNombre, string nApelllidos)
        {
             nombre = nNombre;
            apellidos = nApelllidos;
                
        }

    }
}