using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

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
        public async Task<List<Persona>> getListadoPersona()
        {
           //Listado de personas es para almacenar las personas que obtendremos cuando conenctemos con la bd
            List<Persona> listaPersonas=new List<Persona>();
            String resultado;

            HttpClient miCliente = new HttpClient();

            try{
                resultado =await miCliente.GetStringAsync(miConexion.uri);
                listaPersonas.JsonConvert
            }catch(SqlException sql) {throw sql; }


            return listaPersonas;
        }

    }//Fin clsListadoPersona
}

