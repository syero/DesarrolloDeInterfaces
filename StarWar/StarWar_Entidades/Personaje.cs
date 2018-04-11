using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarWar_Entidades
{
   public class Personaje
    {
        public int IdPersonaje { get; set; }
        public String Nombre { get; set; }
        public String Titulo { get; set; }
        public String Raza { get; set; }
        public String Equipamiento { get; set; } 
        public byte[] Foto { get; set; }

        public Personaje(){}

        public Personaje(int idPersonaje, String nombre, String titulo, String raza, String equipamiento, byte[] foto)
        {
            this.IdPersonaje = idPersonaje;
            this.Nombre = nombre;
            this.Titulo = titulo;
            this.Raza = raza;
            this.Equipamiento = equipamiento;
            this.Foto = foto;
        }

        public Personaje( String nombre, String titulo, String raza, String equipamiento, byte[] foto)
        {
            this.Nombre = nombre;
            this.Titulo = titulo;
            this.Raza = raza;
            this.Equipamiento = equipamiento;
            this.Foto = foto;
        }


        public Personaje(String nombre, String titulo, String raza, String equipamiento)
        {
            this.Nombre = nombre;
            this.Titulo = titulo;
            this.Raza = raza;
            this.Equipamiento = equipamiento;
        }

    }
}
