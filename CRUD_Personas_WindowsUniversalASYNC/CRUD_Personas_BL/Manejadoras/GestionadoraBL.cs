using CRUD_Personas_DAL.Manejadoras;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace CRUD_Personas_BL.Manejadoras
{
   public class GestionadoraBL
    {
        GestionPersonaDAL gestionDal = new GestionPersonaDAL();

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

        public async Task<int> insertarPersonaBL(Persona persona)
        {
            int codigoDeRespuesta;

              codigoDeRespuesta =await gestionDal.insertarPersonaDAL(persona);

            return codigoDeRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Persona> obtenerPersonaParaEditarBL(int id)
        {
            Persona persona = new Persona();

            //llamar a buscar persona de DAL
            persona = await gestionDal.buscarPersonaDAl(id);

            return (persona);
        }

        ///// <summary>
        ///// esta actualiza a la persona
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        public async Task<HttpStatusCode> actualizarPersonaBL( Persona person)
        {            
            return await gestionDal.guardarPersonaDAL(person);
        }

    }
}
