using SnakeDAL.Conexion;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SnakeDAL.Manejadoras
{
    public class PuntuacionManejadoraDAL
    {
        public async Task<Puntuacion> getPuntuacionDAL(int id)
        {
            clsConnection mCon = new clsConnection();
            HttpClient client = new HttpClient();
            String resultadoJSON;
            Uri uri = new Uri(mCon.uriBase + "/Puntuacion/" + id);
            Puntuacion puntuacion;

            try
            {
                resultadoJSON = await client.GetStringAsync(uri);
                client.Dispose();
                //JsonConvert
                puntuacion = JsonConvert.DeserializeObject<Puntuacion>(resultadoJSON);
            }
            catch (Exception e) { throw e; }
            return puntuacion;
        }

        /// <summary>
        /// Devuelve 1 si se ha realizado con exito y 0 si se ha fallado.
        /// </summary>
        /// <param name="puntuacion"></param>
        /// <returns></returns>
        public async Task<int> crearPuntuacionDAL(Puntuacion puntuacion)
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
                body = JsonConvert.SerializeObject(puntuacion);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                Uri uri = new Uri(miConexion.uriBase + "/Puntuacion");

                mRespuesta = await client.PostAsync(uri, mContenido);

                if (mRespuesta.IsSuccessStatusCode)
                {
                    resultado = 1;
                }
            }
            catch (Exception e) { throw e; }
            return (resultado);
        }




    }
}
