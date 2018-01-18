using SnakeWebAPI_BL.Listado;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnakeWebAPI.Controllers
{
    public class PuntuacionController : ApiController
    {
        //    // GET: api/Puntuacion
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }
        ListadoBL listados = new ListadoBL();

        // GET: api/Puntuacion
        public List<Puntuacion> Get()
        {
            List<Puntuacion> puntuaciones = listados.obtenerPuntuacion();
            return puntuaciones;
        }

        // POST: api/Puntuacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Puntuacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Puntuacion/5
        public void Delete(int id)
        {
        }
    }
}
