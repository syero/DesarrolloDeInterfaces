using CRUD_Personas_DAL.Manejadoras;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_BL.Manejadoras
{
   public class GestionadoraBL
    {
        GestionPersonaDAL gestionDal = new GestionPersonaDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Persona obtenerPersonaParaEditarBL(int id)
        //{
        //    Persona persona = new Persona();
        //    //Objeto de la gestionadora BAL
        //    GestionPersonaDAL gestionadoraDal = new GestionPersonaDAL();

        //    //llamar a buscar persona de DAL
        //    persona = gestionadoraDal.buscarPersonaDAl(id);

        //    return (persona);
        //}

        ///// <summary>
        ///// esta actualiza a la persona
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public int actualizarPersonaBL(int id,Persona person)
        //{
        //    int filasAfectadas = 0;
        //    GestionPersonaDAL gestionadoraDal = new GestionPersonaDAL();

        //    //llamar a actualizar de DAl
        //    filasAfectadas = gestionadoraDal.guardarPersonaDAL(id,person);

        //    return (filasAfectadas);
        //}

        ///// <summary>
        ///// metodo para eliminar personas de la bd
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        public async Task<int> eliminarPersona(int id)
        {
            int codigoRespuesta;
          
            codigoRespuesta = await gestionDal.eliminarPersonaDAL(id);

            return (codigoRespuesta);
        }

        ///// <summary>
        ///// para insertar una persona nueva
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>

        //public int insertarPersonaBL(Persona persona)
        //{
        //    int filasAfectadas;

        //    GestionPersonaDAL gestion = new GestionPersonaDAL();
        //    filasAfectadas = gestion.crearPersonaDAL(persona);

        //    return filasAfectadas;
        //}

    }
}
