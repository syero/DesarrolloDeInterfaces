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
        String superFotoMafioso;

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
            Mafioso mafiosillo=new Mafioso();

                miComando.Parameters.Add("@nickMafioso", System.Data.SqlDbType.VarChar).Value = nick;

                try
                {
                    conexion = miConexion.getConnection();
                    miComando.CommandText = "select codigoMafioso,nickMafioso,nombreYapellidosMafioso from mafiosos where nickMafioso=@nickMafioso";
                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        miLector.Read();
                        mafiosillo.codigoMafioso = (Int32)miLector["codigoMafioso"];
                        AsignarFoto(mafiosillo.codigoMafioso);
                        mafiosillo.fotoMafioso = superFotoMafioso;
                        mafiosillo.nickMafioso = (String)miLector["nickMafioso"];
                        mafiosillo.nombreApellidosMafioso = (String)miLector["nombreYapellidosMafioso"];
                    }

                    miComando.Parameters.Clear();
                }
                catch (SqlException sql) { throw sql; }
        
            return (mafiosillo);
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
                    " from misiones where ((reservada = 1 and codigoMafioso = @codeMafioso ) or (reservada = 0 and codigoMafioso is null)) and cumplida = 0";
                
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read()) 
                {
                    mision = new Mision();
                    mision.CondigoMision = (Int32)miLector["codigoMision"];
                    mision.TituloMision = (String)miLector["tituloMision"];
                    mision.Reservada = (Boolean)miLector["reservada"];

                    //esto es por que el codigo del mafioso puede ser null
                    if (miLector["codigoMafioso"] == System.DBNull.Value)
                    {
                        mision.CodigoMafioso = 0;
                    }
                    else
                    {
                        mision.CodigoMafioso = (Int32)miLector["codigoMafioso"];
                    }

                    mision.Cumplida = (Boolean)miLector["cumplida"];

                    //esto es por que la Fecha de Cumplimiento puede ser null
                    if (miLector["FechaCumplimiento"] == System.DBNull.Value)
                    {
                        mision.FechaCumplimiento=DateTime.Now;
                    }
                    else
                    {
                        mision.FechaCumplimiento=(DateTime)miLector["fechaCumplimiento"];
                    }                   

                    //esto es por que las Observaciones pueden ser null
                    if (miLector["observaciones"]==System.DBNull.Value)
                    {
                        mision.Observaciones = null;
                    }
                    else {
                        mision.Observaciones = (String)miLector["observaciones"];
                    }

                    //esto es por que las DescripcionMision puede ser null
                    if (miLector["descripcionMision"] == System.DBNull.Value)
                    {
                       mision.DescripcionMision = null;
                    }
                    else
                    {
                        mision.DescripcionMision = (String)miLector["descripcionMision"];
                    }
                   

                    misiones.Add(mision);
                }
                miComando.Parameters.Clear();
            }
            catch (SqlException sql) { throw sql; }
            return misiones;
        }

        /// <summary>
        /// este metodo asigna las fotos de los mafiosos
        /// </summary>
        /// <param name="idMafioso"></param>
        public void AsignarFoto(int idMafioso)
        {
            switch (idMafioso)
            {
                case 1:
                    superFotoMafioso = "ms-appx:///Assets/fotosMafiosos/1.jpg";
                    break;
                case 2:
                    superFotoMafioso = "ms-appx:///Assets/fotosMafiosos/2.jpg";
                    break;
                case 3:
                    superFotoMafioso = "ms-appx:///Assets/fotosMafiosos/3.jpg";
                    break;
                case 4:
                    superFotoMafioso = "ms-appx:///Assets/fotosMafiosos/4.jpg";
                    break;
                case 5:
                    superFotoMafioso = "ms-appx:///Assets/fotosMafiosos/5.jpg";
                    break;
                case 6:
                    superFotoMafioso = "ms-appx:///Assets/fotosMafiosos/6.jpg";
                    break;
            }
        }


        /// <summary>
        /// metodo para reservar la mision
        /// </summary>
        /// <param name="condigoMision"></param>
        public void reservarMisionDAL(int condigoMision,int codigoMafioso)
        {
            miComando.Parameters.Add("@condigoMision", System.Data.SqlDbType.Int).Value = condigoMision;
           // miComando.Parameters.Add("@codigoMafioso", System.Data.SqlDbType.Int).Value = codigoMafioso;
            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = " update misiones set reservada = 1 , codigoMafioso=" +codigoMafioso+ " where codigoMision = @condigoMision";

                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                miComando.ExecuteNonQuery();

            }catch (SqlException sql) { throw sql; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condigoMision"></param>
        /// <param name="codigoMafioso"></param>
        public void misionCumplidaDAL(int condigoMision, DateTime fechaCumplimiento,String Observaciones)
        {
            if (Observaciones == null)
            {
                Observaciones = "";
            }

            miComando.Parameters.Add("@condigoMision", System.Data.SqlDbType.Int).Value = condigoMision;
            miComando.Parameters.Add("@fechaCumplimiento", System.Data.SqlDbType.DateTime).Value = fechaCumplimiento;  
            miComando.Parameters.Add("@Observaciones", System.Data.SqlDbType.NVarChar).Value = Observaciones;

            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = " update misiones set fechaCumplimiento=@fechaCumplimiento , cumplida = 1 , observaciones=@Observaciones   where codigoMision = @condigoMision";

                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                miComando.ExecuteNonQuery();

            }
            catch (SqlException sql) { throw sql; }
        }

    }
}
