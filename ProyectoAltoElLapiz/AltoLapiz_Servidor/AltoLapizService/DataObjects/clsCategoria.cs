using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoLapizService.DataObjects
{
    public class clsCategoria
    {
        //Atributos
        private static int idCategoriaAutoincrementada=0; //para que la id de la categoria se autoincremente
        public int idCategoria { get; set; }
        public String nombreCategoria { get; set; }
        
        //Constructor por parámetros

        public clsCategoria( string nombreCategoria)
        {
            this.idCategoria = idCategoriaAutoincrementada;
                               idCategoriaAutoincrementada++;
            this.nombreCategoria = nombreCategoria;
        }

        //Constructor por defecto

        public clsCategoria()
        {
            this.idCategoria = idCategoriaAutoincrementada;
                               idCategoriaAutoincrementada++;
            this.nombreCategoria = "";
        }
    }
}
