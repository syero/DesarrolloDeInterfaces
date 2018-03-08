using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_DAL.Conexion
{
    public class MiConexion
    {
        //Atributos
        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public Uri uri { get; set; }

        //Constructores

        public MiConexion()
        {
            //DB en local
<<<<<<< HEAD
            this.server = "localhost";
            this.dataBase = "JuegoDeTronos";
            this.user = "prueba";
=======
            this.server = "DESKTOP-MG34IJD";
            this.dataBase = "Bichos";
            this.user = "sandra";
>>>>>>> master
            this.pass = "123";

            //Azure
            // this.server = "personasdbservers.database.windows.net";
            // this.dataBase = "Persona";
            // this.user = "syero";
            // this.pass = "Galadriel123";
            //  this.uri = new Uri("");

        }
        //Con parámetros por si quisiera cambiar las conexiones
        public MiConexion(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }


        //METODOS

        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión con la base de datso</returns>
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                //connection.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", server, dataBase, user, pass);
                connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }




        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>The connection is closed.</post>
        /// <param name="connection">La entrada es la conexión a cerrar
        /// </param>
        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
