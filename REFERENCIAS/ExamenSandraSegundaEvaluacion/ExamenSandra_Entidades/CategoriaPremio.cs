using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_Entidades
{
   public class CategoriaPremio
    {
        public CategoriaPremio(int idCategoria, string nombreCategoriaPremio)
        {
            this.idCategoria = idCategoria;
            this.nombreCategoriaPremio = nombreCategoriaPremio;
        }

        public CategoriaPremio()
        {
            this.idCategoria = 0;
            this.nombreCategoriaPremio = " ";
        }

        public int idCategoria { get; set; }
        public String nombreCategoriaPremio { get; set; }



    }
}
