using ExamenSandra_DAL.Conexion;
using ExamenSandra_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_DAL.Gestionadora
{
   public class GestionadoraDAL
    {
        //Creamos el objeto de tipo conexion de mi conexion
        MiConexion miConexion = new MiConexion();
        //Creamos la sql Connection
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();



        /// <summary>
        /// Este metodo va a guardar en la base de datos las clasificaciones de los combates de cada jugador
        /// </summary>
        /// <param name="clasificacionCombate"></param>
        /// <returns></returns>
        public int insertarClasificacionesCombatesDAL(ClasificacionCombate clasificacionCombate)
        {
            int resultado = 0;

            // miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
            miComando.Parameters.Add("@IdCombate", System.Data.SqlDbType.Int).Value = clasificacionCombate.idCombate;
            miComando.Parameters.Add("@Puntos", System.Data.SqlDbType.Int).Value = clasificacionCombate.punto;
            miComando.Parameters.Add("@IdCategoriaPremio", System.Data.SqlDbType.Int).Value = clasificacionCombate.idCategoriaPremio;
            miComando.Parameters.Add("@IdLuchador", System.Data.SqlDbType.Int).Value = clasificacionCombate.idLuchador;

            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "insert into clasificacionComabate(idCombate,puntos,idCategoriaPremio,idLuchador) " +
                                      " values(@IdCombate,@Puntos,@IdCategoriaPremio,@IdLuchador)";
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado = miComando.ExecuteNonQuery();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin guardarPersonaDAL

    }
}
