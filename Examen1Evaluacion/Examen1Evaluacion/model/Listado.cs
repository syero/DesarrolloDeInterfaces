using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Evaluacion
{
    public class Listado
    {
        public ObservableCollection<Carta> list { get; set; }

        public Listado()
        {
            int posicion1, posicion2;
            Random rdm = new Random();
            
            list = new ObservableCollection<Carta>();
            list.Add(new Carta(1, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png",UriKind.Absolute),"Ballesta"));
            list.Add(new Carta(1,new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Daryl"));
            list.Add(new Carta(2,new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Katana"));
            list.Add(new Carta(2,new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute), "Michonne"));
            list.Add(new Carta(3,new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute), "Martillo"));
            list.Add(new Carta(3,new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Tyreese"));
            list.Add(new Carta(4, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"AR-15"));
            list.Add(new Carta(4, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Sasha"));
            list.Add(new Carta(5, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Colt"));
            list.Add(new Carta(5, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Rick"));
            list.Add(new Carta(6, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Lucille"));
            list.Add(new Carta(6, new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute),"Negan"));

            for (int i = 0; i<200; i++)
            {
                posicion1 = rdm.Next(0, 12);
                posicion2 = rdm.Next(0, 12);
                
                list.Move(posicion1,posicion2);
            }

           


        }

    }
}
