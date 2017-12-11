using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_DAL.Manejadoras
{
   public class GestionPersonaDAL
    {

        clsMyConnection miConexion = new clsMyConnection();
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();

        public Persona buscarPersonaDAl(int id)
        {
            //
            SqlDataReader miLector;
            //
            Persona person = new Persona();

            try
            {

                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "Select ID, Nombre,Apellidos,FechaNacimiento,Direccion,Telefono from Personas where ID=@id";
                /**creamos la variable que le pondremos en el where*/
                SqlParameter param;
                param = new SqlParameter();
                param.ParameterName ="@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                //Le damos al comando el paramentro
                miComando.Parameters.Add(param);

                /*aqui termina la declaracion de la variable */

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    person = new Persona();
                    person.idPersona = (Int32)miLector["ID"];
                    person.nombre = (String)miLector["Nombre"];
                    person.apellidos = (String)miLector["Apellidos"];
                    person.fechaNac = (DateTime)miLector["FechaNacimiento"];
                    person.direccion = (String)miLector["Direccion"];
                    person.telefono = (String)miLector["Telefono"];

                    
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return (person);
        }//fin metodo buscarPersona

        /// <summary>
        /// este metodo esta guarda los cambios de la persona editada
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int guardarPersonaDAL(Persona persona)
        {
            int resultado = 0;

            //
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.fechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

            try {
                conexion = miConexion.getConnection();
                //Actualizamos los datos de la persona en la base de datos
                miComando.CommandText = "Update Personas set Nombre=@nombre,Apellidos=@apellidos," +
                                        "FechaNacimiento=@fechaNacimiento,Direccion=@direccion,Telefono=@telefono " +
                                        "where ID=@id";
                //
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado= miComando.ExecuteNonQuery();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin guardarPersonaDAL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int eliminarPersonaDAL(int id)
        {
            int filasAfectadas=0;
            /*
                SqlParameter param;
                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;
                */

            //Le damos al comando el paramentro
            miComando.Parameters.Add("id",System.Data.SqlDbType.Int).Value= id;

            try {
                conexion = miConexion.getConnection();
                miComando.CommandText="Delete From Personas where ID=@id";
                miComando.Connection = conexion; //no olvides esto
                filasAfectadas = miComando.ExecuteNonQuery();

            }catch (Exception e) { throw e; }


            return filasAfectadas;

        }

        /// <summary>
        /// este metodo inserta una nueva persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int crearPersonaDAL(Persona persona)
        {           
            int resultado = 0;

           // miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.fechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

            try
            {
                conexion = miConexion.getConnection();
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "Insert into Personas set Nombre=@nombre,Apellidos=@apellidos," +
                                        "FechaNacimiento=@fechaNacimiento,Direccion=@direccion,Telefono=@telefono ";
                //
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado = miComando.ExecuteNonQuery();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin guardarPersonaDAL

    }
}
