
using _18_CRUD_Personas_UWP_DAL.Conexion;
using _18_CRUD_Personas_UWP_Entidades;
using _18_CRUD_Personas_UWP_UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _18_CRUD_Personas_UWP_DAL.Manejadoras
{
    public class ManejadoraDAL
    {
        /// <summary>
        /// Eliminamos a una persona con el verbo delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> eliminarPersonaDALAsync(int id)
        {
            clsConnection mConexion = new clsConnection();
            int mResultado = 0;
            HttpClient client = new HttpClient();
            HttpResponseMessage respuesta;
            Uri mUri = new Uri(mConexion.uriBase + "/" + id);
            try
            {
                respuesta = await client.DeleteAsync(mUri);
                client.Dispose();

                if (respuesta.IsSuccessStatusCode)
                {
                    mResultado = 1;
                }
            }
            catch (Exception e) { throw e; }

            return mResultado;

        }

        /// <summary>
        /// Este metodo crea una nueva persona
        /// </summary>
        /// <param name="persona">Recibe un objeto persona</param>
        /// <returns>Devuelve un 1 si se ha creado correctamente. Un 0 si ha fallado.</returns>
        public async Task<int> crearPersonaDALAsync(clsPersona persona)
        {
            clsConnection miConexion = new clsConnection();
            int resultado = 0;
            HttpClient client = new HttpClient();
            String body;
            HttpStringContent mContenido;
            HttpResponseMessage mRespuesta;
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(persona);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                mRespuesta = await client.PostAsync(miConexion.uriBase, mContenido);

                if (mRespuesta.IsSuccessStatusCode)
                {
                    resultado = 1;
                }
            }
            catch (Exception e) { throw e; }


            return (resultado);
        }
        //fin crearPersonaDAL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> updatePersonaAsync(clsPersona persona)
        {
            clsConnection miConexion = new clsConnection();
            HttpClient client = new HttpClient();
            String body;
            HttpStringContent mContenido;
            HttpResponseMessage mRespuesta;
            Uri mUri = new Uri(miConexion.uriBaseCore + "/" + persona.IdPersona);
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(persona);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                mRespuesta = await client.PutAsync(mUri, mContenido);

            }
            catch (Exception e) { throw e; }

            return mRespuesta.StatusCode;

        }

        public async Task<clsPersona> getPersonaDAL(int id)
        {
            clsConnection mCon = new clsConnection();
            HttpClient client = new HttpClient();
            String resultadoJSON;
            Uri uri = new Uri(mCon.uriBase + "/" + id);
            clsPersona persona;

            try
            {
                resultadoJSON = await client.GetStringAsync(uri);
                client.Dispose();
                //JsonConvert
                persona = JsonConvert.DeserializeObject<clsPersona>(resultadoJSON);


            }
            catch (Exception e) { throw e; }
            return persona;

        }
    }
}
