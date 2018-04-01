using CosaNostra_DAL.Gestionadora_DAL;
using CosaNostra_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_BL.Gestionadora_BL
{
    public class Gestionadora_BL
    {
        Gestionadora_DAL gestion = new Gestionadora_DAL();

        /// <summary>
        /// Este metodo llama al metodo de la dal 
        /// que nos permite obtener un mafioso segun su nick
        /// este metodo me servira para validar si existe un mafioso y 
        /// para mostrar sus datos una ves validada su existencia
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public Mafioso validarMafiosoBL(String nick)
        {
            Mafioso masMafia = gestion.validarMafiosoDAL(nick);
            return masMafia;
        }

        /// <summary>
        /// Este metodo llama al metodo de la DAL que nos permite 
        /// obtener la lista de todas las misiones no disponibles para ser realizadas
        /// y las reservadas por un mafioso
        /// </summary>
        /// <param name="codigoMafioso"></param>
        /// <returns></returns>
        public List<Mision> obtenerMisionesNoReservadasNiCumplidasBL(int codigoMafioso)
        {
            List<Mision> misiones = gestion.obtenerMisionesNoReservadasNiCumplidasDAL(codigoMafioso);
            return misiones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condigoMision"></param>
        /// <param name="codigoMafioso"></param>
        public void reservarMisionBL(int condigoMision, int codigoMafioso)
        {
            gestion.reservarMisionDAL(condigoMision, codigoMafioso);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condigoMision"></param>
        /// <param name="fechaMisionCumplida"></param>
        public void misionCumplidaBL(int condigoMision,DateTime fechaMisionCumplida, String Observaciones)
        {
            gestion.misionCumplidaDAL(condigoMision, fechaMisionCumplida, Observaciones);
        }
    }
}
