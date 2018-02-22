using Newtonsoft.Json;
using SnakeWebAPI_DAL.Conexiones;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWebAPI_DAL.Manejadora
{
   public class ManejadoraDAL
    {
        Conexion miConexion = new Conexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();

        /// <summary>
        /// Este metodo va a insertar un objeto de tipo Puntuacion
        /// </summary>
        public void insertarPuntuacion(int idMapa, int valoracion,Puntuacion puntuacion)
        {
            miComando.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.NVarChar).Value = puntuacion.NombreUsuario;
            miComando.Parameters.Add("@Valor", System.Data.SqlDbType.Int).Value = puntuacion.Valor;

            //Valorar un mapa
            valorarMapa(idMapa, valoracion);

            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "Insert into SK_Puntuaciones (NombreUsuario,Valor)" +
                                      " values(@NombreUsuario,@Valor)";

                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                miComando.ExecuteNonQuery();

            }
            catch (SqlException sql) { throw sql; }

        }//insertarPuntuacion


        //Actualizar la valoracion de un mapa segun id
        public void valorarMapa(int idMapa,int valoracion)
        {

            miComando.Parameters.Add("@valoracion", System.Data.SqlDbType.Int).Value = valoracion;
            miComando.Parameters.Add("@idMapa", System.Data.SqlDbType.Int).Value = idMapa;

            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "Update SK_Mapas set ValoracionMapa=ValoracionMapa+@valoracion where IDMapa=@idMapa";

                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                miComando.ExecuteNonQuery();

            }
            catch (SqlException sql) { throw sql; }
        }//valorarMapa

        /// <summary>
        /// este metodo va a insertar un objeto de tipo Mapa
        /// </summary>
        public void insertarMapa(Mapa mapa)
        {
            miComando.Parameters.Add("@NombreMapa", System.Data.SqlDbType.NVarChar).Value = mapa.NombreMapa;
            miComando.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.NVarChar).Value = mapa.NombreUsuario;
            miComando.Parameters.Add("@MapaJson", System.Data.SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(mapa.Casillas);
            miComando.Parameters.Add("@ValoracionMapa", System.Data.SqlDbType.Int).Value = mapa.ValoracionMapa;
            miComando.Parameters.Add("@FecharCreacion", System.Data.SqlDbType.DateTime).Value= mapa.FecharCreacion;

            try{
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "Insert into SK_Mapas (NombreMapa,NombreUsuario,MapaJson,ValoracionMapa,FecharCreacion) values(@NombreMapa,@NombreUsuario,@MapaJson,@ValoracionMapa,@FecharCreacion)";

                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                miComando.ExecuteNonQuery();

            } catch (SqlException sql) { throw sql; }
        }//insertarMapa 

    }
}
