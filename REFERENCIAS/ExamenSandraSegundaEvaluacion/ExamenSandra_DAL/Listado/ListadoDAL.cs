using ExamenSandra_DAL.Conexion;
<<<<<<< HEAD
using ExamenSandra_Entidades;
=======
>>>>>>> master
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
<<<<<<< HEAD
        //Creamos el objeto de tipo conexion de mi conexion
        MiConexion miConexion = new MiConexion();
        //Creamos la sql Connection
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();


        /// <summary>
        /// método que nos devuelve un listado de Combates
        /// </summary>
        /// <returns>lista de personas</returns>
        public List<Combate> getListadoCombates()
        {
            List<Combate> listaCombates = new List<Combate>();
            SqlDataReader miLector;
            Combate combate;

            try
            {
                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "select idCombate,fechaCombate from combates";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    combate = new Combate();
                    combate.idCombate = (Int32)miLector["idCombate"];
                    combate.fechaCombate = (DateTime)miLector["fechaCombate"];

                    listaCombates.Add(combate);
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return listaCombates;
        }

        /// <summary>
        /// método que nos devuelve un listado de Luchadores
        /// </summary>
        /// <returns></returns>
        public List<Luchador> getListadoLuchadores()
        {
            List<Luchador> listaLuchadores = new List<Luchador>();
            SqlDataReader miLector;
            Luchador luchador;

            try
            {
                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "select idLuchador,nombreLuchador,idCasa from luchadores";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    luchador = new Luchador();
                    luchador.idLuchador = (Int32)miLector["idLuchador"];
                    luchador.nombre = (String)miLector["nombreLuchador"];

                    listaLuchadores.Add(luchador);
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return listaLuchadores;
        }

        /// <summary>
        /// método que nos devuelve un listado de Categorias premio
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPremio> getListadoCategoriasPremios()
        {
            List<CategoriaPremio> listaCategoriasPremios = new List<CategoriaPremio>();
            SqlDataReader miLector;
            CategoriaPremio categoriaPremio;

            try
            {
                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "select idCategoriaPremio, nombreCategoriaPremio from categoriasPremios";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    categoriaPremio = new CategoriaPremio();
                    categoriaPremio.idCategoria = (Int32)miLector["idCategoriaPremio"];
                    categoriaPremio.nombreCategoriaPremio = (String)miLector["nombreCategoriaPremio"];

                    listaCategoriasPremios.Add(categoriaPremio);
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return listaCategoriasPremios;
        }


        /// <summary>
        /// método que nos devuelve un listado de Casas
        /// </summary>
        /// <returns></returns>
        public List<Casa> getListadoCasas()
        {
            List<Casa> listaCasas = new List<Casa>();
            SqlDataReader miLector;
            Casa casa;

            try
            {
                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "select idCasa,nombreCasa from casas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    casa = new Casa();
                    casa.idCasa = (Int32)miLector["idCasa"];
                    casa.nombreCasa = (String)miLector["nombreCasa"];

                    listaCasas.Add(casa);
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return listaCasas;
        }
=======
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
>>>>>>> master


    }
}
