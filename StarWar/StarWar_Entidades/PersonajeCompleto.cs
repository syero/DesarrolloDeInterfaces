using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_Entidades
{
   public class PersonajeCompleto:Personaje
    {
        public String NombreTrilogia { get; set; }
        public String NombrePelicula { get; set; }

        public PersonajeCompleto(){ }

        public PersonajeCompleto(int idPersonaje, String nombre, String titulo, String raza, String equipamiento, byte[] foto, String nombreTrilogia, String nombrePelicula)
        :base(idPersonaje,nombre,titulo,raza,equipamiento,foto)
        {
            this.NombreTrilogia = nombreTrilogia;
            this.NombrePelicula = nombrePelicula;
        }

        public PersonajeCompleto(String nombre, String titulo, String raza, String equipamiento, byte[] foto, String nombreTrilogia, String nombrePelicula)
          : base( nombre, titulo, raza, equipamiento, foto)
        {
            this.NombreTrilogia = nombreTrilogia;
            this.NombrePelicula = nombrePelicula;
        }

    }
}
