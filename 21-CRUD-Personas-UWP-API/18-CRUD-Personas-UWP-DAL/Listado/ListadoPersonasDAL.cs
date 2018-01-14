using _18_CRUD_Personas_UWP_DAL.Conexion;
using _18_CRUD_Personas_UWP_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;

namespace _18_CRUD_Personas_UWP_UI.Listado
{
    public class ListadoPersonasDAL
    {
        public List<clsPersona> listado { get; set; }

        public ListadoPersonasDAL()
        {
            this.listado = new List<clsPersona>();
        }

        //Siempre se devuelva una tarea y no un void
        /// <summary>
        /// Metodo asincrono
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPersona>> getPersonas()
        {
            clsConnection mCon = new clsConnection();
            //List<clsPersona> listaPersonas = new List<clsPersona>();
            HttpClient client = new HttpClient();
            String resultadoJSON;

            try
            {
                resultadoJSON = await client.GetStringAsync(mCon.uriBase);
                client.Dispose();
                //JsonConvert
                listado = JsonConvert.DeserializeObject<List<clsPersona>>(resultadoJSON);

            }
            catch (SqlException e)
            {
                throw e;
            }

            return listado;
        }
    }
}