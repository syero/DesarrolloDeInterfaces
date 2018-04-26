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


        /// <summary>
        /// Este metodo llama al metodo de la DAL que obtiene las peliculas con nombre de la trilogia
        /// </summary>
        /// <param name="idTrilogia"></param>
        /// <returns></returns>
        public List<PeliculaConNombreTrilogia> obtenerPeliculasConNombreDeTrilogiaBL(int idTrilogia)
        {
            List<PeliculaConNombreTrilogia> peliculasConNombreTrilogia = gestoraDAL.obtenerPeliculasConNombreDeTrilogiaDAL(idTrilogia);
            return peliculasConNombreTrilogia;
        }


        /// <summary>
        /// Este metodo llama al metodo de la DAL que obtiene los personajes con nombre de trilogia y pelicula
        /// segun la id de la pelicula y la id de la trilogia.
        /// </summary>
        /// <param name="idTrilogia"></param>
        /// <param name="idPelicula"></param>
        /// <returns></returns>
        public List<PersonajeCompleto> obtenerPersonajeConNombreDePeliculaYTrilogiaBL(int idTrilogia, int idPelicula)
        {
            List<PersonajeCompleto> Personajes = gestoraDAL.obtenerPersonajeConNombreDePeliculaYTrilogiaDAL(idTrilogia, idPelicula);
            return Personajes;
        }



    }
}
