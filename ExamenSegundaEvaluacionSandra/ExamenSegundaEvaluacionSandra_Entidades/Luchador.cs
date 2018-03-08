using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_Entidades
{
   public class Luchador
    {
        public Luchador(int idLuchador, string nombre, int idCasa)
        {
            this.idLuchador = idLuchador;
            this.nombre = nombre;
            this.idCasa = idCasa;
        }

        public Luchador()
        {
            this.idLuchador = 0;
            this.nombre = " ";
            this.idCasa = 0;
        }

        public int idLuchador { get; set; }
        public String nombre { get; set; }
        public int idCasa { get; set; }

    }
}
