using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_Entidades
{
   public class ClasificacionCombate
    {
        public ClasificacionCombate(int idCombate, int punto, int idCategoriaPremio, int idLuchador)
        {
            this.idCombate = idCombate;
            this.punto = punto;
            this.idCategoriaPremio = idCategoriaPremio;
            this.idLuchador = idLuchador;
        }

        public ClasificacionCombate()
        {
            this.idCombate = 0;
            this.punto = 0;
            this.idCategoriaPremio = 0;
            this.idLuchador = 0;
        }

        public int idCombate { get; set; }
        public int punto { get; set; }
        public int idCategoriaPremio { get; set; }
        public int idLuchador { get; set; }



    }
}
