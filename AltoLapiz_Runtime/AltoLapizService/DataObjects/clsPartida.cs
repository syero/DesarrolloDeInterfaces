using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltoLapizService.DataObjects
{
    public class clsPartida
    {
   
        public int numeroRondas { get; set; }
        public String pais { get; set; }
        public String nombrePartida { get; set; }

        public clsPartida()
        {
            this.numeroRondas = 0;
            this.pais = " ";
            this.nombrePartida = " ";
        }


        public clsPartida(int numeroRondas, string pais, string nombrePartida)
        {
            this.numeroRondas = numeroRondas;
            this.pais = pais;
            this.nombrePartida = nombrePartida;
        }


    }
}