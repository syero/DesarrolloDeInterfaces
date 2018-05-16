using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace _13_DataContext.Models
{
    class clsManejadoraPersona
    {
        private Uri miUrl = new Uri("http://webapipersonas.azurewebsites.net/api/personas");


        /// <summary>
        /// Función que borra una persona de la base de datos.
        /// </summary>
        /// <param name="id">Como entrada recibe el id de la persona a borrar</param>
        /// <returns>Devuelve el resultado que corresponde a las filas afectadas</returns>
        public async Task<HttpStatusCode> deletePersonaDAL(int id)
        {
            HttpClient mihttpClient = new HttpClient();
            //Usaremos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
               miRespuesta= await mihttpClient.DeleteAsync(new Uri(miUrl + "/" + id));
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }


        /// <summary>
        /// Función que inserta una persona de la base de datos.
        /// </summary>
        /// <param name="id">Como entrada recibe la persona a insertar</param>
        /// <returns>Devuelve el resultado del servidor</returns>
        public async Task<HttpStatusCode> insertaPersonaDAL(clsPersona persona)
        {
            HttpClient mihttpClient = new HttpClient();
            string body = "";
            HttpStringContent contenido;
            //Usaremos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                body = JsonConvert.SerializeObject(persona);
                
                contenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUrl, contenido);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }



        /// <summary>
        /// Función que actualiza una persona de la base de datos.
        /// </summary>
        /// <param name="id">Como entrada recibe la persona a insertar</param>
        /// <returns>Devuelve el resultado del servidor</returns>
        public async Task<HttpStatusCode> actualizaPersonaDAL(int id, clsPersona persona)
        {
            HttpClient mihttpClient = new HttpClient();
            string body = "";
            HttpStringContent contenido;
            //Usaremos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                body = JsonConvert.SerializeObject(persona);
                //Añadimos el id a la URI
               
                contenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                miRespuesta = await mihttpClient.PutAsync(new Uri(miUrl + "/" + id), contenido);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }


    }
}
