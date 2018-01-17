using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace CRUD_Personas_DAL.Manejadoras
{
    public class GestionPersonaDAL
    {
        clsMyConnection miConexion = new clsMyConnection();       
        HttpClient miCliente = new HttpClient();

              /// <summary>
        /// Elimina a una persona de la api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> eliminarPersonaDAL(int id)
        {
            int codigoRespuesta=0;
           //Usamos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            Uri miUri = new Uri(miConexion.uri.ToString()+"/"+id);

            try
            {
                miRespuesta = await miCliente.DeleteAsync(miUri);
                miCliente.Dispose();

                if (miRespuesta.IsSuccessStatusCode)
                {
                    codigoRespuesta = (int)miRespuesta.StatusCode;

                }else {

                    codigoRespuesta = (int)miRespuesta.StatusCode;
                }

            }
            catch (Exception e) { throw e; }

            return codigoRespuesta;

        }

        /// <summary>
        /// este metodo inserta una nueva persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<int> insertarPersonaDAL(Persona persona)
        {
            int resultado = 0;
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            String body;
            HttpStringContent contenido;

            try
            {
                body = JsonConvert.SerializeObject(persona);
                contenido = new HttpStringContent(body,Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                miRespuesta = await miCliente.PostAsync(miConexion.uri,contenido);
               // miCliente.Dispose();

                if (miRespuesta.IsSuccessStatusCode)
                {
                    resultado = (int)miRespuesta.StatusCode;
                }
                else
                {
                    resultado = (int)miRespuesta.StatusCode;
                }
            }
            catch (Exception e) { throw e; }

            return (resultado);

        }//fin guardarPersonaDAL

        /// <summary>
        /// Va a buscar en la api a una persona segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Persona> buscarPersonaDAl(int id)
        {
            //Usamos el Status de la respuesta para comprobar si ha borrado
            String miRespuesta;
            Uri miUri = new Uri(miConexion.uri+ "/" + id);
            Persona person = new Persona();

            try
            {
                miRespuesta = await miCliente.GetStringAsync(miUri);
                miCliente.Dispose();
                person = JsonConvert.DeserializeObject<Persona>(miRespuesta);
                
            }catch (Exception e) { throw e; }

            return (person);
        }//fin metodo buscarPersona

        /// <summary>
        /// este metodo esta guarda los cambios de la persona editada
        /// tengo que revisarlo
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> guardarPersonaDAL(Persona persona)
        {
            String body = "";
            HttpStringContent mContenido;
            HttpResponseMessage respuesta;
            Uri miUri = new Uri(miConexion.uri + "/" + persona.idPersona);
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(persona);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                respuesta = await miCliente.PutAsync(miUri, mContenido);

            }
            catch (Exception e) { throw e; }

            return respuesta.StatusCode;
        }//fin guardarPersonaDAL

        
    }
}
