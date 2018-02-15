using SnakeDAL.Manejadoras;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeBL.Manejadoras
{
    public class PuntuacionManejadoraBL
    {

        public async Task<Puntuacion> getPuntuacionBL(int id)
        {
            Puntuacion puntuacion = new Puntuacion();
            PuntuacionManejadoraDAL manejadoraDAL = new PuntuacionManejadoraDAL();
            await manejadoraDAL.getPuntuacionDAL(id);

            return puntuacion;
        }

        public async Task crearPuntuacionBL(Puntuacion p)
        {
            PuntuacionManejadoraDAL manejadora = new PuntuacionManejadoraDAL();
            await manejadora.crearPuntuacionDAL(p);

        }

    }
}
