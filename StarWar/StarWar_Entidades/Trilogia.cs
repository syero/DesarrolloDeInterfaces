using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_Entidades
{
    public class Trilogia
    {
        public int IdTrilogia { get; set; }
        public string NombreTrilogia { get; set; }

        public Trilogia(int idTrilogia,string nombreTrilogia)
        {
            this.IdTrilogia = idTrilogia;
            this.NombreTrilogia = nombreTrilogia;
        }

        public Trilogia( string nombreTrilogia)
        {
            this.NombreTrilogia = nombreTrilogia;
        }

    }
}
