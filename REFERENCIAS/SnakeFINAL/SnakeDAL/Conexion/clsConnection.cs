using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDAL.Conexion
{
    public class clsConnection
    {

        public Uri uriBase { get; set; }
        public Uri uriBaseCore { get; set; }

        public clsConnection()
        {
            this.uriBase = new Uri("http://snakeapi.azurewebsites.net/api/");
        }
    }
}