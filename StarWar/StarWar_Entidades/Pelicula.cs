using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_Entidades
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public int IdTrilogia { get; set; }
        public String NombrePelicula{ get; set; }

        public Pelicula(){}

        public Pelicula(int idPelicula,int idTrilogia,String nombrePelicula)
        {
            this.IdPelicula = idPelicula;
            this.IdTrilogia = idTrilogia;
            this.NombrePelicula = nombrePelicula;
        }
    }
}
