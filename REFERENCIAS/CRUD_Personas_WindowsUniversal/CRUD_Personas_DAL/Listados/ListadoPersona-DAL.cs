using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_DAL.Listados
{
    public  class ListadoPersona_DAL
    {
        //Creamos el objeto de tipo conexion de mi conexion
        clsMyConnection miConexion = new clsMyConnection();
        //Creamos la sql Connection
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();


        /// <summary>
        /// método que nos devuelve un listado de personas
        /// </summary>
        /// <returns>lista de personas</returns>
        public List<Persona> getListadoPersona()
        {
           //Listado de personas es para almacenar las personas que obtendremos cuando conenctemos con la bd
            List<Persona> listaPersonas=new List<Persona>();
            SqlDataReader miLector;
            Persona person;

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
                    person = new Persona();
                    person.idPersona =(Int32)miLector["ID"];
                    person.nombre = (String)miLector["Nombre"];
                    person.apellidos = (String)miLector["Apellidos"];
                    person.fechaNac =(DateTime)miLector["FechaNacimiento"];
                    person.direccion =(String)miLector["Direccion"];
                    person.telefono=(String)miLector["Telefono"];

                    listaPersonas.Add(person);
                }//fin while
            }
            catch(SqlException sql) {throw sql; }


            return listaPersonas;
        }

    }//Fin clsListadoPersona
}

