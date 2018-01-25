using SnakeWebAPI_DAL.Manejadora;
using SnakeWebAPI_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            mapa.Casillas = rellenacasillas();

            gestionDAL.insertarMapa(mapa);

        }

        public ObservableCollection<ObservableCollection<bool>> rellenacasillas()
        {
            ObservableCollection<bool> arrayBool0 = new ObservableCollection<bool>() { true, false, true, true, false, true, true, false, true };
            ObservableCollection<bool> arrayBool1 = new ObservableCollection<bool>() { true, false, true, true, false, true, true, false, true };
            ObservableCollection<bool> arrayBool2 = new ObservableCollection<bool>() { true, false, true, true, false, true, true, false, true };
            ObservableCollection<bool> arrayBool3 = new ObservableCollection<bool>() { true, false, true, true, false, true, true, false, true };

            ObservableCollection<ObservableCollection<bool>> casillasMapa = new ObservableCollection<ObservableCollection<bool>>() { arrayBool0, arrayBool1, arrayBool2, arrayBool3 };

            return (casillasMapa);
        }

    }
}
