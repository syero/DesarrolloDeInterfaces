using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TirandoDeDataBase_Entidades;

namespace TirandoDeDataBase_DAL.Listados
{
    public class ListadoClientes
    {
        //Creamos el objeto de tipo conexion de mi conexion
        Conexion miConexion = new Conexion();
        //Creamos la sql Connection
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();


        /// <summary>
        /// método que nos devuelve un listado de Clientes
        /// </summary>
        /// <returns>lista de personas</returns>
        public List<Cliente> getListadoClientes()
        {
            //Listado de personas es para almacenar las personas que obtendremos cuando conenctemos con la bd
            List<Cliente> listaClientes = new List<Cliente>();
            SqlDataReader miLector;
            Cliente cliente;

            try
            {

                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "Select ID,Nombre,Apellidos,FechaNacimiento,Direccion,Telefono from Personas";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    cliente = new Cliente();
                    cliente.codigo = (Int32)miLector["ID"];
                    cliente.nombre = (String)miLector["Nombre"];
                    cliente.numeroCuenta = (String)miLector["Apellidos"];
                    person.direccion = (String)miLector["Direccion"];
                    person.telefono = (String)miLector["Telefono"];

                    listaPersonas.Add(person);
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return listaPersonas;
        }

    }
}
