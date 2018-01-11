using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _server: cadena 
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace CRUD_Personas_DAL.Conexion
{ public class clsMyConnection
    {
        //Atributos
        public Uri uri { get; set; }

        /**
         en la uri home es controlador 
            en caso de tener mas de  un controlador tendriasmos hasta https://sandrawebapi.azurewebsites.net/api
             
             */
        //Constructores
        public clsMyConnection()
        {          
            this.uri = new Uri("https://sandrawebapi.azurewebsites.net/api/Home");

        }
      
    }

}