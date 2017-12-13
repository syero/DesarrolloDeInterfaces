using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_BL.Manejadoras
{
   public  class ListadoPersonasBL
    {
        public List<Persona> getListaPersonaBL()
        { 
            ListadoPersona_DAL listadoDAl = new ListadoPersona_DAL();
            List<Persona> listaPersonas = listadoDAl.getListadoPersona();

            return (listaPersonas);
        }


    }
}
