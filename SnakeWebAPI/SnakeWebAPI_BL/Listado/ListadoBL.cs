using SnakeWebAPI_DAL.Listado;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWebAPI_BL.Listado
{
    public class ListadoBL
    {
        ListadoDAL gestionDAL = new ListadoDAL();

        /// <summary>
        /// Este metodo nos permite obtener una lista de mapas
        /// </summary>
        /// <returns></returns>
        public List<Mapa> obtenerMapas(bool ordenarPorValoracionMapa)
        {
            List<Mapa> mapas = gestionDAL.obtenerMapas(ordenarPorValoracionMapa);
            return mapas;
        }

        /// <summary>
        /// Este metodos nos permite obtener las puntuaciones
        /// </summary>
        /// <returns></returns>
        public List<Puntuacion> obtenerPuntuacion()
        {
            List<Puntuacion> puntuaciones = gestionDAL.obtenerPuntuaciones();
            return puntuaciones;

        }

        /// <summary>
        /// Este metodos nos permite obtener las primeras 50 puntuaciones
        /// </summary>
        /// <returns></returns>
        public List<Puntuacion> obtenerPrimerasCincuentaPuntuacion()
        {
            List<Puntuacion> puntuaciones = gestionDAL.obtenerPrimerasCincuentaPuntuaciones();
            return puntuaciones;

        }

    }
}
