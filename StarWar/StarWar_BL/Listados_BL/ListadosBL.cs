using StarWar_DAL.Gestionadora_DAL;
using StarWar_DAL.Listados_DAL;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_BL.Listados_BL
{
    public class ListadosBL
    {
        ListadoDAL listadoDAL = new ListadoDAL();

        /// <summary>
        /// Este metodo llama al metodo de la DAL que obtiene la lista de las trilogias
        /// </summary>
        /// <returns></returns>
        public List<Trilogia> obtenerTrilogiaBL()
        {
            List<Trilogia> trilogias = listadoDAL.obtenerTrilogiaDAL();
            return trilogias;
        }



    }
}
