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
        String fotoCasa, fotoLuchador;

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

                    AsignarFotoCasaLuchador(luchador.idCasa);
                    luchador.fotoCasaLuchador = fotoCasa;

                    obtenerFotoLuchador(luchador.idLuchador);
                    luchador.fotoLuchador = fotoLuchador;

                   listaLuchadores.Add(luchador);
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return listaLuchadores;
        }



        /// <summary>
        /// Va a permitir mostra la fotos de la familia a la que pertenence ese luchador
        /// </summary>
        public void AsignarFotoCasaLuchador(int idCasa)
        {
            switch (idCasa)
            {
                case 1:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/1.png";
                    break;
                case 2:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/2.png";
                    break;
                case 3:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/3.png";
                    break;
                case 4:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/4.png";
                    break;
                case 5:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/5.png";
                    break;
                case 6:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/6.png";
                    break;
                case 7:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/7.png";
                    break;
                case 8:
                    fotoCasa = "ms-appx:///Assets/Images/Casas/8.png";
                    break;
            }
        }

      

        /// <summary>
        /// Nos va a asignar a cada luchador la foto que le corresponde 
        /// </summary>
        public void obtenerFotoLuchador(int idLuchador)
        {
            switch (idLuchador)
            {
                case 1:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/1.jpg";
                    break;
                case 2:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/2.jpg";
                    break;
                case 3:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/3.jpg";
                    break;
                case 4:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/4.jpg";
                    break;
                case 5:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/5.jpg";
                    break;
                case 6:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/6.jpg";
                    break;
                case 7:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/7.jpg";
                    break;
                case 8:
                    fotoLuchador = "ms-appx:///Assets/Images/Luchadores/8.jpg";
                    break;
            }
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
