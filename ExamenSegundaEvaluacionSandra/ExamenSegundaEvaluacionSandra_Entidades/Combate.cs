using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_Entidades
{
   public class Combate
    {      

        public int idCombate { get; set; } 
        public DateTime fechaCombate { get; set; }

        public Combate()
        {
            this.idCombate = 0;
            this.fechaCombate =new DateTime() ;
        }


        public Combate(int idCombate, DateTime fechaCombate)
        {
            this.idCombate = idCombate;
            this.fechaCombate = fechaCombate;
        }




    }
}
