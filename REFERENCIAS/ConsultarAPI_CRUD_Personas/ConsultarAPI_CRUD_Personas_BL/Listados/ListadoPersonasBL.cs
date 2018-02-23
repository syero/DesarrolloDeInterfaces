using ConsultarAPI_CRUD_Personas_DAL.Listados;
using ConsultarAPI_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultarAPI_CRUD_Personas_BL.Listados
{
   public  class ListadoPersonasBL
    {
        public async Task<ObservableCollection<Persona>> getListaPersonaBL()
        { 
            ListadoPersona_DAL listadoDAl = new ListadoPersona_DAL();
            ObservableCollection<Persona> listaPersonas = await listadoDAl.getListadoPersona();

            return (listaPersonas);
        }


    }
}
