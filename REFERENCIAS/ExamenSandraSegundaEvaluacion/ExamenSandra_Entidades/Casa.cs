using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_Entidades
{
   public class Casa
    {
        public Casa(int idCasa, string nombreCasa)
        {
            this.idCasa = idCasa;
            this.nombreCasa = nombreCasa;
        }

        public Casa()
        {
            this.idCasa = 0;
            this.nombreCasa = " " ;
        }

        public int idCasa { get; set; }
        public String nombreCasa { get; set; }



    }
}
