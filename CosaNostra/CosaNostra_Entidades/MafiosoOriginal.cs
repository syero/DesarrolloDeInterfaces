using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_Entidades
{
    public class MafiosoOriginal
    {
        public int codigoMafioso { get; set; }
        public String nickMafioso { get; set; }
        public String nombreApellidosMafioso { get; set; }


        public MafiosoOriginal( int codigoMafioso, String nickMafioso, String nombreApellidosMafioso)
        {
            this.codigoMafioso = codigoMafioso;
            this.nickMafioso = nickMafioso;
            this.nombreApellidosMafioso = nombreApellidosMafioso;
        }

        public MafiosoOriginal(String nickMafioso)
        {
            this.nickMafioso = nickMafioso;
        }

        public MafiosoOriginal()
        {
            this.codigoMafioso = 0;
            this.nickMafioso = null;
            this.nombreApellidosMafioso = null;
        }

    }
}
