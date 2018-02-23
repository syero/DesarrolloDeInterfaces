using _18_CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _18_CRUD_Personas_UWP_DAL.Manejadoras;
using Windows.Web.Http;

namespace _18_CRUD_Personas_UWP_BL.Manejadoras
{
    public class ManejadoraBL
    {
        /// <summary>
        /// Metodo que obtiene la persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<clsPersona> getPersona(int id)
        {
            clsPersona person = new clsPersona();
            ManejadoraBL manejadoraDAL = new ManejadoraBL();
            manejadoraDAL.getPersona(id);

            return person;
        }

        /// <summary>
        /// Metodo que actualiza la persona
        /// </summary>
        /// <param name="p">Recibe al objeto de persona</param>
        /// <returns>Retorna un entero que representa el numero de filas afectadas</returns>
        public async Task<HttpStatusCode> updatePersonaAsync(clsPersona p)
        {
            ManejadoraDAL manejadoraDAL = new ManejadoraDAL();
            return await manejadoraDAL.updatePersonaAsync(p);
        }
        
        /// <summary>
        /// Metodo que borra la persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> borrarPersonaAsync(int id)
        {
            int filasAfectadas = 0;
            ManejadoraDAL manejadora = new ManejadoraDAL();
            filasAfectadas = await manejadora.eliminarPersonaDALAsync(id);
            
            return filasAfectadas;
        }

        /// <summary>
        /// Metodo que añade la persona, la inserta a la BD
        /// </summary>
        /// <param name="p"></param>
        public async Task addPersonaAsync(clsPersona p)
        {
            ManejadoraDAL manejadora = new ManejadoraDAL();
            await manejadora.crearPersonaDALAsync(p);

        }
    }

}
