using ConsultarAPI_CRUD_Personas_DAL.Conexion;
using ConsultarAPI_CRUD_Personas_Entidades;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace ConsultarAPI_CRUD_Personas_DAL.Manejadoras
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
        public async Task<int> crearPersonaDAL(Persona persona)
        {
            int resultado = 0;
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            Uri miUri;
            String body = "";
            HttpStringContent contenido;

            try
            {
                body = JsonConvert.SerializeObject(persona);
                contenido = new HttpStringContent(body,encoding:Windows.Storage.Streams.UnicodeEncoding.Utf8);
                miUri = new Uri(miConexion.uri.ToString());
                miRespuesta = await miCliente.PostAsync(miUri,contenido);
                miCliente.Dispose();

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
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            Uri miUri = new Uri(miConexion.uri.ToString() + "/" + id);
            Persona person = new Persona();

            try
            {
                miRespuesta = await miCliente.GetAsync(miUri);
                if (miRespuesta.IsSuccessStatusCode)
                {
                  //  person = miRespuesta.Content.ReadAsStringAsync().;
                    miCliente.Dispose();
                }
            }catch (Exception e) { throw e; }

            return (person);
        }//fin metodo buscarPersona

        /// <summary>
        /// este metodo esta guarda los cambios de la persona editada
        /// tengo que revisarlo
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        //public int guardarPersonaDAL(int id, Persona persona)
        //{
        //    int resultado = 0;
        //    String body="";

        //    try
        //    {
        //        body = JsonConvert.SerializeObject(persona); 

        //    }
        //    catch (Exception e) { throw e; }

        //    return (resultado);
        //}//fin guardarPersonaDAL


    }
}
