using SnakeWebAPI_DAL.Manejadora;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWebAPI_BL.Manejadora
{
    public class ManejadoraBL
    {
        ManejadoraDAL gestionDAL = new ManejadoraDAL();

        public void insertarPuntuacion(Puntuacion puntuacion)
        {
            gestionDAL.insertarPuntuacion(puntuacion);
        }

        public void insertarMapa(Mapa mapa)
        {
            gestionDAL.insertarMapa(mapa);

        }


    }
}
