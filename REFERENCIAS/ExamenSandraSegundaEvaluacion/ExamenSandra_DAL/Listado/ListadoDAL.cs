using ExamenSandra_DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_DAL.Listado
{
    public class ListadoDAL
    {
        ////Creamos el objeto de tipo conexion de mi conexion
        //MiConexion miConexion = new MiConexion();
        ////Creamos la sql Connection
        //SqlConnection conexion = new SqlConnection();
        //SqlCommand miComando = new SqlCommand();


        ///// <summary>
        ///// método que nos devuelve un listado de Clientes
        ///// </summary>
        ///// <returns>lista de personas</returns>
        //public List<Cliente> getListadoClientes()
        //{
        //    //Listado de personas es para almacenar las personas que obtendremos cuando conenctemos con la bd
        //    List<Cliente> listaClientes = new List<Cliente>();
        //    SqlDataReader miLector;
        //    Cliente cliente;

        //    try
        //    {

        //        conexion = miConexion.getConnection();
        //        //Creamos comandos
        //        miComando.CommandText = "select Codigo,Telefono,Direccion,NumeroCuenta,Nombre,Video from BI_Clientes";
        //        miComando.Connection = conexion;
        //        miLector = miComando.ExecuteReader();

        //        //Si hay lineas en el Lector
        //        while (miLector.Read())
        //        {
        //            cliente = new Cliente();
        //            cliente.codigo = (Int32)miLector["Codigo"];
        //            cliente.telefono = (String)miLector["Telefono"];
        //            cliente.direccion = (String)miLector["Direccion"];
        //            cliente.numeroCuenta = (String)miLector["NumeroCuenta"];
        //            cliente.nombre = (String)miLector["Nombre"];
        //            cliente.video = (String)miLector["Video"];

        //            listaClientes.Add(cliente);
        //        }//fin while
        //    }
        //    catch (SqlException sql) { throw sql; }


        //    return listaClientes;
        //}


    }
}
