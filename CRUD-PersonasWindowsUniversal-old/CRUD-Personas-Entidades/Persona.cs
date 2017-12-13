using System;
using System.Collections.Generic;
using System.Linq;



/**nunca olvides cambiar el espacio de nombre si te llevas la clase a otro proyecto*/
namespace CRUD_Personas_Entidades
{
    public class Persona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int departamento { get; set; }


        //Constructor por defecto
        public Persona()
            {
                idPersona = 0;
                nombre = "";
                apellidos = "";
                fechaNac = DateTime.Now;
                direccion = " ";
                telefono = " ";
                departamento = 0;
        }

        //Constructor por ordinario
        public Persona(int id, string nNombre,string nApelllidos,DateTime nFechaNac
                        ,string nDireccio,string nTelefono)
        {
            idPersona =id;
            nombre = nNombre;
            apellidos = nApelllidos;
            fechaNac = nFechaNac;
            direccion = nDireccio;
            telefono = nTelefono;
        }

        public Persona(int id,string nNombre, string nApelllidos,int ndepartamento)
        {
            idPersona = id;
             nombre = nNombre;
             apellidos = nApelllidos;
            departamento = ndepartamento;   
        }
    }
}