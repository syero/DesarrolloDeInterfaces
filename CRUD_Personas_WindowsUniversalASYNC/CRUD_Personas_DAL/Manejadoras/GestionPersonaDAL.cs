using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace CRUD_Personas_DAL.Manejadoras
{
    public class GestionPersonaDAL
    {
        clsMyConnection miConexion = new clsMyConnection();
       
        HttpClient miCliente = new HttpClient();

        public Persona buscarPersonaDAl(int id)
        {
            Persona person = new Persona();

            try
            {
                
            }
            catch (Exception e) { throw e; }


            return (person);
        }//fin metodo buscarPersona

        /// <summary>
        /// este metodo esta guarda los cambios de la persona editada
        /// tengo que revisarlo
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        //public int guardarPersonaDAL(int id, Persona persona)
        //{
        //    int resultado = 0;
        //    String body="";

        //    try
        //    {
        //        body = JsonConvert.SerializeObject(persona); 

        //    }
        //    catch (Exception e) { throw e; }

        //    return (resultado);
        //}//fin guardarPersonaDAL


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> eliminarPersonaDAL(int id)
        {
            int codigoRespuesta=0;
           //Usamos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            Uri miUri = new Uri(miConexion.uri.ToString()+"/"+id);

            try
            {
                miRespuesta = await miCliente.DeleteAsync(miUri);
                miCliente.Dispose();

                if (miRespuesta.IsSuccessStatusCode)
                {
                    codigoRespuesta = (int)miRespuesta.StatusCode;

                }else {

                    codigoRespuesta = (int)miRespuesta.StatusCode;
                }

            }
            catch (Exception e) { throw e; }

            return codigoRespuesta;

        }

        /// <summary>
        /// este metodo inserta una nueva persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> crearPersonaDAL(Persona persona)
        {
            int resultado = 0;
            String body = "";
            HttpStringContent contenido;
          
            try
            {
                body = JsonConvert.SerializeObject(persona);

            }
            catch (Exception e) { throw e; }    
        }//fin guardarPersonaDAL

    }
}
