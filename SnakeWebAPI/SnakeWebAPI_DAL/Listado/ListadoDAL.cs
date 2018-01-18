using SnakeWebAPI_DAL.Conexiones;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWebAPI_DAL.Listado
{
   public class ListadoDAL
    {
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();
        SqlDataReader miLector ;

        /// <summary>
        /// Con este metodo vamos a obtener una lista de Mapas
        /// </summary>
        /// <returns></returns>
        public List<Mapa> obtenerMapas()
        {
            List<Mapa> listadoMapas=new List<Mapa>();
            Mapa mapa;

            try {
                conexion = miConexion.getConnection();
                miComando.CommandText = "Select IDMapa,NombreMapa,NombreUsuario,MapaJson,ValoracionMapa,FecharCreacion from SK_Mapas order by ValoracionMapa desc";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    mapa = new Mapa();
                    mapa.IDMapa =(Int32)miLector["IDMapa"];
                    mapa.NombreMapa =(String) miLector["NombreMapa"];
                    mapa.NombreUsuario = (String)miLector["NombreUsuario"];
                    mapa.MapaJson = (String)miLector["MapaJson"];
                    mapa.ValoracionMapa = (Int32)miLector["ValoracionMapa"];
                    mapa.FecharCreacion = (DateTime)miLector["FecharCreacion"];

                    listadoMapas.Add(mapa);
                }
               } catch (SqlException sql) { throw sql; }

            return listadoMapas;
        }//Fin de obtenerMapas

        /// <summary>
        /// Con este metodo vamos a obtener una lista de Puntuaciones
        /// </summary>
        /// <returns></returns>
        public List<Puntuacion> obtenerPuntuaciones()
        {
            List<Puntuacion> listadoPuntuacion = new List<Puntuacion>();
            Puntuacion puntuacion;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "Select IDRanking,NombreUsuario,Valor from SK_Puntuaciones order by Valor desc";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    puntuacion = new Puntuacion();
                    puntuacion.IDPuntuacion = (Int32)miLector["IDRanking"];
                    puntuacion.NombreUsuario = (String)miLector["NombreUsuario"];
                    puntuacion.Valor = (Int32)miLector["Valor"];

                    listadoPuntuacion.Add(puntuacion);
                }
            }
            catch (SqlException sql) { throw sql; }

            return listadoPuntuacion;
        }//Fin de obtenerMapas


    }
}
