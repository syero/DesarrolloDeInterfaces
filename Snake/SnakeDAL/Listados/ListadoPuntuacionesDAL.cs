using Newtonsoft.Json;
using SnakeDAL.Conexion;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDAL.Listados
{
    public class ListadoPuntuacionesDAL
    {
        public List<Puntuacion> listado { get; set; }

        public ListadoPuntuacionesDAL()
        {
            this.listado = new List<Puntuacion>();
        }


        public async Task<List<Puntuacion>> getPuntuaciones()
        {
            clsConnection mCon = new clsConnection();
            HttpClient client = new HttpClient();
            String resultadoJSON;
            Uri uri = new Uri(mCon.uriBase + "/Puntuacion");
            try
            {
                resultadoJSON = await client.GetStringAsync(uri);
                client.Dispose();
                listado = JsonConvert.DeserializeObject<List<Puntuacion>>(resultadoJSON);

            }
            catch (SqlException e)
            {
                throw e;
            }

            return listado;
        }

    }
}
