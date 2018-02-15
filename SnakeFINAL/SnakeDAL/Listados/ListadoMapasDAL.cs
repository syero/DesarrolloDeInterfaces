using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeEntidades;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SnakeDAL.Conexion;
using System.Net.Http;

namespace SnakeDAL.Listados
{
    public class ListadoMapasDAL
    {
        public List<Mapa> listado { get; set; }

        public ListadoMapasDAL()
        {
            this.listado = new List<Mapa>();
        }


        public async Task<List<Mapa>> getMapas(bool ordenarMapasPorValoracion)
        {
            clsConnection miConexion = new clsConnection();
            HttpClient miCliente = new HttpClient();
            String resultadoJSON;
            Uri uri = new Uri(miConexion.uriBase + "Mapa?ordenarPorValoracionMapa="+ ordenarMapasPorValoracion);
            try
            {
                resultadoJSON = await miCliente.GetStringAsync(uri);
                miCliente.Dispose();
                listado = JsonConvert.DeserializeObject<List<Mapa>>(resultadoJSON);
             
            }
            catch (SqlException e)
            {
                throw e;
            }

            return listado;
        }
    }
}
