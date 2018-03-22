using CosaNostra_DAL.Conexion;
using CosaNostra_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_DAL.Gestionadora_DAL 
{
    public class Gestionadora_DAL
    {
        MiConexion miConexion = new MiConexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();
        SqlDataReader miLector;

        /// <summary>
        /// Verifica si el mafioso existe en la base de datos segun su nick
        /// si existe devolvera el mafioso con todos sus datos , si no existe 
        /// devolvera el mafioso vacio;
        /// 
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public Mafioso validarMafiosoDAL(String nick)
        {
            Mafioso mafiosillo;
            miComando.Parameters.Add("@nickMafioso", System.Data.SqlDbType.NVarChar).Value = nick;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select codigoMafioso,nickMafioso,nombreYapellidosMafioso from mafiosos where nickMafioso=@nickMafioso";                 
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                mafiosillo = new Mafioso();
                mafiosillo.codigoMafioso=(Int32)miLector["codigoMafioso"];
                mafiosillo.nickMafioso = (String)miLector["nickMafioso"];
                mafiosillo.nombreApellidosMafioso = (String)miLector["nombreYapellidosMafioso"];   
                
            }
            catch (SqlException sql) { throw sql; }

            return mafiosillo;
        }

        /// <summary>
        /// Este metodos nos va a devolver todas las misiones no reservadas por nadie
        /// y las reservadas pero no cumplidas por un mafioso especifico
        /// </summary>
        /// <param name="codigoMafioso"></param>
        /// <returns></returns>
        public List<Mision> obtenerMisionesNoReservadasNiCumplidasDAL(int codigoMafioso)
        {
            List<Mision> misiones=new List<Mision>();
            Mision mision;
            miComando.Parameters.Add("@codeMafioso", System.Data.SqlDbType.Int).Value = codigoMafioso;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select codigoMision,tituloMision,reservada,codigoMafioso,cumplida,fechaCumplimiento,observaciones,descripcionMision" +
                    " from misiones where ((reservada = 1 and codigoMafioso = @codeMafioso ) or(reservada = 0 and codigoMafioso is null)) and cumplida = 0";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    mision = new Mision();
                    mision.CondigoMision = (Int32)miLector["codigoMision"];
                    mision.TituloMision = (String)miLector["tituloMision"];
                    mision.Reservada = (Boolean)miLector["reservada"];
                    mision.CodigoMafioso =(Int32)miLector["codigoMafioso"];
                    mision.Cumplida = (Boolean)miLector["cumplida"];
                    mision.FechaCumplimiento = (DateTime)miLector["fechaCumplimiento"];
                    mision.Observaciones = (String)miLector["observaciones"];
                    mision.DescripcionMision = (String)miLector["descripcionMision"];

                    misiones.Add(mision);
                }
            }
            catch (SqlException sql) { throw sql; }
            return misiones;
        }
        

    }
}
