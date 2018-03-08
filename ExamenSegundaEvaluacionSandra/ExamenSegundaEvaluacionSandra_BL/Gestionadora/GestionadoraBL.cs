using ExamenSandra_DAL.Gestionadora;
using ExamenSandra_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_BL.Gestionadora
{
   public class GestionadoraBL
    {
        GestionadoraDAL gestionadoraDAL = new GestionadoraDAL();

        public int insertarClasificacionesCombatesBL(ClasificacionCombate clasificacionCombate)
        {
            int resultado = gestionadoraDAL.insertarClasificacionesCombatesDAL(clasificacionCombate);
            return (resultado);
        }

    }
}
