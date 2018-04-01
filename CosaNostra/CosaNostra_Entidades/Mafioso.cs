using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_Entidades
{
   public class Mafioso : MafiosoOriginal
    {       
        public String fotoMafioso { get; set; }      


        public Mafioso(String fotoMafioso, int codigoMafioso, String nickMafioso,String nombreApellidosMafioso)
            :base(codigoMafioso, nickMafioso, nombreApellidosMafioso)
        {
            this.fotoMafioso = fotoMafioso;
        }

        public Mafioso():base() { }

    }
}
