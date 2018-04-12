using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_Entidades
{    

   public class PeliculaConNombreTrilogia:Pelicula
    {
        public String NombreTrilogia { get; set; }

        public PeliculaConNombreTrilogia(): base(){}

        public PeliculaConNombreTrilogia(int idPelicula, int idTrilogia, String nombrePelicula,String nombreTrilogia)
            :base(idPelicula,idTrilogia, nombrePelicula)
        {
            this.NombreTrilogia = nombrePelicula;
        }

    }
}
