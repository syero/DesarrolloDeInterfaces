using System;

namespace _07_Grid_UWP.Models
{
    public class clsPersona
    {
       
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime? fechaNac { get; set; } //Nullable <DateTime>
        public string direccion { get; set; }
        public string telefono { get; set; }

        //Constructor por defecto
        public clsPersona()
        {
            this.idPersona = 0;
            this.nombre = "Alejandro";
            this.apellidos = "Gómez";
            this.fechaNac = null;
            this.direccion = "El kelo";
            this.telefono = "954224444";
        }

        //Constructor por parametros
        public clsPersona(int idPersona, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}