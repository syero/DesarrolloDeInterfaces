using SnakeWebAPI_BL.Listado;
using SnakeWebAPI_BL.Manejadora;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnakeWebAPI.Controllers
{
    public class MapaController : ApiController
    {
        ListadoBL listados = new ListadoBL();
        ManejadoraBL gestionadora = new ManejadoraBL();

        // GET: api/Mapa/5
        public List<Mapa> Get()
        {
            List<Mapa> listadoMapas =listados.obtenerMapas();
            return listadoMapas;
        }

        // POST: api/Mapa
        public void Post([FromBody]Mapa value)
        {
            gestionadora.insertarMapa(value);
        }

        // PUT: api/Mapa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mapa/5
        public void Delete(int id)
        {
        }
    }
}
