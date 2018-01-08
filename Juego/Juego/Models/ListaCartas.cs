using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego.Models
{
    class ListaCartas
    {
        ObservableCollection<Carta> cartas = new ObservableCollection<Carta>();

        /// <summary>
        /// este metodo nos da la lista de cartas que tendremos en el juego
        /// </summary>
        /// <returns> ObservableCollection de cartas </returns>
        public ObservableCollection<Carta> obtenerCartas()
        {
            Carta alicia = new Carta(0, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Alicia");
            Carta gato = new Carta(0, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Gato");
            Carta bellaybestia = new Carta(1, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "BellaYBestia");
            Carta lumiere = new Carta(1, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Lumiere");
            Carta cocodrilo = new Carta(2, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Cocodrilo");
            Carta mickey = new Carta(2, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Mickey");
            Carta damayvagabundo = new Carta(3, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "DamaYVagabundo");
            Carta familiadamayvagabundo = new Carta(3, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "FamiliaDamaYVagabundo");
            Carta garfio = new Carta(4, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Garfio");
            Carta peterpan = new Carta(4, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "PeterPan");
            Carta mapache = new Carta(5, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Mapache");
            Carta pocahontas = new Carta(5, new Uri("ms-appx://Juego/Imagenes/default.jpg", UriKind.Absolute), "Pocahontas");


            cartas.Add(alicia);
            cartas.Add(gato);
            cartas.Add(bellaybestia);
            cartas.Add(lumiere);
            cartas.Add(cocodrilo);
            cartas.Add(mickey);
            cartas.Add(damayvagabundo);
            cartas.Add(familiadamayvagabundo);
            cartas.Add(garfio);
            cartas.Add(peterpan);
            cartas.Add(mapache);
            cartas.Add(pocahontas);

            posicionAleatoria();

            return cartas;
        }

        /// <summary>
        /// este metodo va coloca las cartas en posiciones aleatorias 
        /// </summary>
        public void posicionAleatoria()
        {
            int pos1, pos2;
            Random aleatorio = new Random();

            for (int i = 0; i < 200; i++)
            {
                pos1 = aleatorio.Next(0, 12);
                pos2 = aleatorio.Next(0, 12);

                cartas.Move(pos1, pos2);
            }


        }

    }
}
