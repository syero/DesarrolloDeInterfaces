using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_Entidades
{
   public class Mafioso
    {       
        public String fotoMafioso { get; set; }
        public int codigoMafioso { get; set; }
        public String nickMafioso { get; set; }
        public String nombreApellidosMafioso { get; set; }


        public Mafioso(String fotoMafioso, int codigoMafioso, String nickMafioso,String nombreApellidosMafioso)
        {
            this.fotoMafioso = fotoMafioso;
            this.codigoMafioso = codigoMafioso;
            this.nickMafioso = nickMafioso;
            this.nombreApellidosMafioso = nombreApellidosMafioso;
        }


        public Mafioso(int codigoMafioso,String nickMafioso,String nombreApellidosMafioso)
        {
            this.codigoMafioso = codigoMafioso;
            this.nickMafioso = nickMafioso;
            this.nombreApellidosMafioso = nombreApellidosMafioso;
        }

        public Mafioso()
        {
        }
    }
}
