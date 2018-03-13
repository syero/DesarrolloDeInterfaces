using ExamenSandra_DAL.Conexion;
using ExamenSandra_Entidades;
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
        public List<LuchadorCompleto> getListadoLuchadores()
        {
            List<LuchadorCompleto> listaLuchadores = new List<LuchadorCompleto>();
            SqlDataReader miLector;
            LuchadorCompleto luchador;

            try
            {
                conexion = miConexion.getConnection();
                //Creamos comandos
                miComando.CommandText = "select l.idLuchador,l.nombreLuchador,l.idCasa,c.nombreCasa from luchadores as l inner join casas as c on l.idCasa=c.idCasa";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                while (miLector.Read())
                {
                    luchador = new LuchadorCompleto();
                    luchador.idLuchador = (Int32)miLector["idLuchador"];
                    luchador.nombre = (String)miLector["nombreLuchador"];
                    luchador.idCasa=(Int32)miLector["idCasa"];
                    luchador.nombreCasa = (String)miLector["nombreCasa"];

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
    }
}
