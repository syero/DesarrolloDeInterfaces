using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TirandoDeDataBase_DAL.Listados;
using TirandoDeDataBase_Entidades;

namespace TirandoDeDataBase_BL.Listados
{
    public class ListadosBL
    {
        ListadoDAL listadoDAL = new ListadoDAL();

        public List<Cliente> getClientes()
        {
            List<Cliente> clientes = listadoDAL.getListadoClientes();
            return clientes;
        }


    }
}
