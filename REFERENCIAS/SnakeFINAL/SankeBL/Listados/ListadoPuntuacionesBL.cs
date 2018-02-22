using SnakeDAL.Listados;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeBL.Listados
{
    public class ListadoPuntuacionesBL
    {
        public async Task<List<Puntuacion>> getListadoBL()
        {
            ListadoPuntuacionesDAL listadoPuntuacionesDAL = new ListadoPuntuacionesDAL();
            List<Puntuacion> listadoParaUI = await listadoPuntuacionesDAL.getPuntuaciones();

            return listadoParaUI;
        }
    }
}
