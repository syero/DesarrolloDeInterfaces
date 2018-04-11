using StarWar_DAL.Gestionadora_DAL;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_BL.Gestionadora_BL
{
    public class GestionadoraBL
    {
        GestionadoraDAL gestoraDAL = new GestionadoraDAL();



        public List<PeliculaConNombreTrilogia> obtenerPeliculasConNombreDeTrilogiaBL(int idTrilogia)
        {
            List<PeliculaConNombreTrilogia> peliculasConNombreTrilogia = gestoraDAL.obtenerPeliculasConNombreDeTrilogiaDAL(idTrilogia);
            return peliculasConNombreTrilogia;
        }



        public List<PersonajeCompleto> obtenerPersonajeConNombreDePeliculaYTrilogiaBL(int idTrilogia, int idPelicula)
        {
            List<PersonajeCompleto> Personajes = gestoraDAL.obtenerPersonajeConNombreDePeliculaYTrilogiaDAL(idTrilogia, idPelicula);
            return Personajes;
        }



    }
}
