using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoLapizService.DataObjects
{
    public class clsPalabra
    {
        //Atributos

        public int idCategoria { get; set; }
        public String palabra { get; set; }
        public int estado { get; set; }

        //Constructor por parámetros

        public clsPalabra(int idCategoria, string palabra, int estado)
        {
            this.idCategoria = idCategoria;
            this.palabra = palabra;
            this.estado = estado;
        }

        //Constructor por defecto

        public clsPalabra()
        {
            this.idCategoria = 0;
            this.palabra = "";
            this.estado = 0;
        }

    }
}
