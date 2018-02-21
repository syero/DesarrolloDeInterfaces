using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasAWebApi.DAL
{
    class MiConexion
    {

        //Atributos
        public Uri uri { get; set; }

        /**
         en la uri home es controlador 
            en caso de tener mas de  un controlador tendriasmos hasta https://sandrawebapi.azurewebsites.net/api
             
             */
        //Constructores
        public MiConexion()
        {
            this.uri = new Uri("https://sandrawebapi.azurewebsites.net/api/Home");

        }

    }
}
