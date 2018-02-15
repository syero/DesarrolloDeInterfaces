using SnakeDAL.Manejadoras;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeBL.Manejadoras
{
    public class MapaManejadoraBL
    {

        public async Task<Mapa> getMapaBL(int id)
        {
            Mapa puntuacion = new Mapa();
            MapaManejadoraDAL manejadoraDAL = new MapaManejadoraDAL();
            await manejadoraDAL.getMapaDAL(id);

            return puntuacion;
        }

        public async Task crearMapaBL(Mapa p)
        {
            MapaManejadoraDAL manejadora = new MapaManejadoraDAL();
            await manejadora.crearMapaDAL(p);

        }


    }
}
