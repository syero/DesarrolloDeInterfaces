using CosaNostra_BL.Gestionadora_BL;
using CosaNostra_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_UI.ViewModels
{
    public class ViewModelMafiosoMissiones
    {
        public String nick;
        public Mafioso mafiosoSeleccionado;
        private List<Mision> _misiones;
        private Mision _misionesSeleccionada;

        Gestionadora_BL gestionadora = new Gestionadora_BL();



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Mision> obtenerMisionesNoReservadasNiCumplidas()
        {
            List<Mision> misiones = gestionadora.obtenerMisionesNoReservadasNiCumplidasBL(mafiosoSeleccionado.codigoMafioso);
           return misiones;
         }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void validarNick()
        {
            mafiosoSeleccionado = gestionadora.validarMafiosoBL(nick);
        }

    }
}
