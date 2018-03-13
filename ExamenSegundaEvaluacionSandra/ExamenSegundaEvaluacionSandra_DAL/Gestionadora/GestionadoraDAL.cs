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
        public void insertarClasificacionesCombatesDAL(int idCombate, LuchadorCompleto luchadorUno, LuchadorCompleto luchadorDos)
        {          

            // miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
            miComando.Parameters.Add("@IdCombate", System.Data.SqlDbType.Int).Value = idCombate;

            miComando.Parameters.Add("@PuntosCombateSangrientoLuchadorUno", System.Data.SqlDbType.Int).Value = luchadorUno.puntosCombateSangriento;
            miComando.Parameters.Add("@PuntosCombateEspectacularLuchadorUno", System.Data.SqlDbType.Int).Value = luchadorUno.puntosCombateEspectacular;
            miComando.Parameters.Add("@puntosCombateVirtuosoLuchadorUno", System.Data.SqlDbType.Int).Value = luchadorUno.puntosCombateVirtuoso;

            miComando.Parameters.Add("@PuntosCombateSangrientoLuchadorDos", System.Data.SqlDbType.Int).Value = luchadorDos.puntosCombateSangriento;
            miComando.Parameters.Add("@PuntosCombateEspectacularLuchadorDos", System.Data.SqlDbType.Int).Value = luchadorDos.puntosCombateEspectacular;
            miComando.Parameters.Add("@PuntosCombateVirtuosoLuchadorDos", System.Data.SqlDbType.Int).Value = luchadorDos.puntosCombateVirtuoso;

            miComando.Parameters.Add("@IdCategoriaPremioSangriento", System.Data.SqlDbType.Int).Value = 1;
            miComando.Parameters.Add("@IdCategoriaPremioEspectacular", System.Data.SqlDbType.Int).Value = 2;
            miComando.Parameters.Add("@IdCategoriaPremioVirtuoso", System.Data.SqlDbType.Int).Value = 3;

            miComando.Parameters.Add("@IdLuchadorUno", System.Data.SqlDbType.Int).Value = luchadorUno.idLuchador;
            miComando.Parameters.Add("@IdLuchadorDos", System.Data.SqlDbType.Int).Value = luchadorDos.idLuchador;

            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "insert into clasificacionComabate(idCombate,puntos,idCategoriaPremio,idLuchador) " +
                                      " values(@IdCombate,@PuntosCombateSangrientoLuchadorUno,@IdCategoriaPremioSangriento,@IdLuchadorUno)" +                                           
                                            ",(@IdCombate,@PuntosCombateEspectacularLuchadorUno,@IdCategoriaPremioEspectacular,@IdLuchadorUno)" +
                                            ",(@IdCombate,@puntosCombateVirtuosoLuchadorUno,@IdCategoriaPremioSangriento,@IdLuchadorUno)" +
                                            ",(@IdCombate,@PuntosCombateSangrientoLuchadorDos, @IdCategoriaPremioSangriento, @IdLuchadorDos)" +
                                            ",(@IdCombate, @PuntosCombateEspectacularLuchadorDos, @IdCategoriaPremioEspectacular, @IdLuchadorDos)" +
                                            ",(@IdCombate,@puntosCombateVirtuosoLuchadorDos,@IdCategoriaPremioSangriento,@IdLuchadorDos)";

                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                miComando.ExecuteNonQuery();
            }
            catch (SqlException sql) { throw sql; }
            
        }//fin guardarPersonaDAL

    }
}
