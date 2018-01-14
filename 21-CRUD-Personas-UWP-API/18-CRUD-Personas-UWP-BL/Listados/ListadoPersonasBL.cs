using _18_CRUD_Personas_UWP_Entidades;
using _18_CRUD_Personas_UWP_UI.Listado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_CRUD_Personas_UWP_BL.Listados
{
    public class ListadoPersonasBL
    {
        public async Task<List<clsPersona>> getListadoBL()
        {
            ListadoPersonasDAL listadoPersonas = new ListadoPersonasDAL();
            List<clsPersona> listadoParaUI = await listadoPersonas.getPersonas();

            return listadoParaUI;
        }
    }
}
