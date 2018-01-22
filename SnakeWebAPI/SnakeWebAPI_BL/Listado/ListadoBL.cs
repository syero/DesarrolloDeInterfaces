using SnakeWebAPI_DAL.Listado;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWebAPI_BL.Listado
{
    public class ListadoBL
    {
        ListadoDAL gestionDAL = new ListadoDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Mapa> obtenerMapas(bool ordenarPorValoracionMapa)
        {
            bool ordenarPorValoracionMapA = true;

            List<Mapa> mapas = gestionDAL.obtenerMapas(ordenarPorValoracionMapA);
            return mapas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Puntuacion> obtenerPuntuacion()
        {
            List<Puntuacion> puntuaciones = gestionDAL.obtenerPuntuaciones();
            return puntuaciones;

        }



    }
}
