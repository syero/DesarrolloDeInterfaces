using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_Entidades
{ 

   public class PeliculaConNombreTrilogia
    {
        public String NombreTrilogia { get; set; }

        public PeliculaConNombreTrilogia(int idPelicula, int idTrilogia, String nombrePelicula,String NombreTrilogia)
            :base(idPelicula,idTrilogia, nombrePelicula)
        {

        }

    }
}
