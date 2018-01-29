using SnakeDAL.Listados;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeBL.Listados
{
    public class ListadoMapasBL
    {

        public async Task<List<Mapa>> getListadoBL(bool ordenarMapasPorValoracion)
        {
            ListadoMapasDAL listadoMapasDAL = new ListadoMapasDAL();
            List<Mapa> listadoParaUI = await listadoMapasDAL.getMapas(ordenarMapasPorValoracion);

            return listadoParaUI;
        }

    }
}
