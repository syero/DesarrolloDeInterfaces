using StarWar_DAL.Conexion;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWar_DAL.Gestionadora_DAL
{
    public class GestionadoraDAL
    {
        MiConexion miConexion = new MiConexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();
        SqlDataReader miLector;       

        /// <summary>
        /// Este metodo me permite obtener las peliculas con nombre de trilogia
        /// </summary>
        /// <param name="idTrilogia"></param>
        /// <returns></returns>
        public List<PeliculaConNombreTrilogia> obtenerPeliculasConNombreDeTrilogiaDAL(int idTrilogia)
        {
            List<PeliculaConNombreTrilogia> peliculas = new List<PeliculaConNombreTrilogia>();
            PeliculaConNombreTrilogia peliculaConNombreTrilogia;

            miComando.Parameters.Add("@idTrilogia", System.Data.SqlDbType.Int).Value = idTrilogia;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select idPelicula,p.idTrilogia,nombrePelicula,nombreTrilogia from peliculas as p inner join trilogias as t on p.idTrilogia=t.idTrilogia " +
                                         " where p.idTrilogia=@idTrilogia";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                
                while (miLector.Read())
                {
                    peliculaConNombreTrilogia = new PeliculaConNombreTrilogia();
                    peliculaConNombreTrilogia.IdPelicula = (Int32)miLector["idPelicula"];
                    peliculaConNombreTrilogia.IdTrilogia = (Int32)miLector["idTrilogia"];
                    peliculaConNombreTrilogia.NombrePelicula = (String)miLector["nombrePelicula"];
                    peliculaConNombreTrilogia.NombreTrilogia= (String)miLector["nombreTrilogia"];

                    peliculas.Add(peliculaConNombreTrilogia);
                }
                miComando.Parameters.Clear();
            }
            catch (SqlException sql) { throw sql; }
            return peliculas;
        }//fin obtenerPeliculasConNombreDeTrilogia

        /// <summary>
        /// Este metodo me permite obtener los personajes de con nombre de peliculas y nombre de trilogia
        /// segun la id de la pelicula de la id de la trilogia.
        /// Si el base de datos devuelve algun valor null , le pongo uno por defecto
        /// </summary>
        /// <param name="idTrilogia"></param>
        /// <param name="idPelicula"></param>
        /// <returns></returns>
        public List<PersonajeCompleto> obtenerPersonajeConNombreDePeliculaYTrilogiaDAL(int idTrilogia, int idPelicula)
        {
            List<PersonajeCompleto> personajes = new List<PersonajeCompleto>();
            PersonajeCompleto personajecompleto;

            miComando.Parameters.Add("@idTrilogia", System.Data.SqlDbType.Int).Value = idTrilogia;
            miComando.Parameters.Add("@idPelicula", System.Data.SqlDbType.Int).Value = idPelicula;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = " select p.idPersonaje,p.nombrePersonaje,p.tituloPersonaje,p.razaPersonaje,p.equipamientoPersonaje,p.fotoPersonaje,pl.nombrePelicula,t.nombreTrilogia" +
                                        " from peliculas as pl inner join trilogias as t on pl.idTrilogia = t.idTrilogia" +
                                        " inner join personajesPeliculas as pp on pl.idPelicula = pp.idPelicula" +
                                        " inner join personajes as p on pp.idPersonaje = p.idPersonaje" +
                                        " where t.idTrilogia = @idTrilogia and pl.idPelicula = @idPelicula";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                while (miLector.Read())
                {
                    personajecompleto = new PersonajeCompleto();
                    personajecompleto.IdPersonaje= (Int32)miLector["idPersonaje"];
                    personajecompleto.Nombre= (String)miLector["nombrePersonaje"];
                    personajecompleto.Titulo= (String)miLector["tituloPersonaje"];
                    personajecompleto.Raza= (String)miLector["razaPersonaje"];
                    personajecompleto.Equipamiento = (String)miLector["equipamientoPersonaje"];

                    if (miLector["fotoPersonaje"] == System.DBNull.Value)
                    {
                        personajecompleto.Foto =new Byte[0];
                    }
                    else
                    {
                        personajecompleto.Foto = (Byte[])miLector["fotoPersonaje"];
                    }                   
                    personajecompleto.NombrePelicula = (String)miLector["nombrePelicula"];
                    personajecompleto.NombreTrilogia = (String)miLector["nombreTrilogia"];

                    personajes.Add(personajecompleto);
                }
                miComando.Parameters.Clear();
            }
            catch (SqlException sql) { throw sql; }
            return personajes;
        }//fin obtenerPersonajeConNombreDePeliculaYTrilogia     


    }
}
