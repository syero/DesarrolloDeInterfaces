using ConsultarAPI_CRUD_Personas_DAL.Conexion;
using ConsultarAPI_CRUD_Personas_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace ConsultarAPI_CRUD_Personas_DAL.Listados
{
    public  class ListadoPersona_DAL
    {
        /// <summary>
        /// método que nos devuelve un listado de personas
        /// </summary>
        /// <returns>lista de personas</returns>
        public async Task<ObservableCollection<Persona>> getListadoPersona()
        {
            //Creamos el objeto de tipo conexion de mi conexion
            clsMyConnection miConexion = new clsMyConnection();

            //Listado de personas es para almacenar las personas que obtendremos cuando conenctemos con la bd
            ObservableCollection<Persona> listaPersonas=new ObservableCollection<Persona>();
            String resultado;

            HttpClient miCliente = new HttpClient();

            try{

                resultado =await miCliente.GetStringAsync(miConexion.uri);
                miCliente.Dispose();
                listaPersonas = JsonConvert.DeserializeObject<ObservableCollection<Persona>>(resultado);

            }catch(Exception e) {throw e; }


            return listaPersonas;
        }

    }//Fin clsListadoPersona
}

