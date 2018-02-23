using ExamenSandra_DAL.Listado;
using ExamenSandra_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_BL.Listado
{
   public class ListadoBL
    {
        ListadoDAL listadoDAl = new ListadoDAL();

        /// <summary>
        /// Este metodo va a llamar el metodo  getListadoCombates de la capa DAL 
        /// Devuelve una lista de Combates
        /// </summary>
        /// <returns></returns>
        public List<Combate> getCombates()
        {
            List<Combate> listaCombates = listadoDAl.getListadoCombates();
            return listaCombates;

        }


        /// <summary>
        /// Este metodo va a llamar el metodo  getListadoLuchadores de la capa DAL 
        /// Devuelve una lista de Luchadores 
        /// </summary>
        /// <returns></returns>
        public List<Luchador> getLuchadores()
        {
            List<Luchador> listaLuchadores = listadoDAl.getListadoLuchadores();
            return listaLuchadores;

        }


        /// <summary>
        /// Este metodo va a llamar el metodo  getListadoCategoriasPremios de la capa DAL 
        /// Devuelve una lista de CategoriaPremio
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPremio> getCategoriasPremios()
        {
            List<CategoriaPremio> listaCategoriasPremios = listadoDAl.getListadoCategoriasPremios();
            return listaCategoriasPremios;

        }


        /// <summary>
        /// Este metodo va a llamar el metodo  getListadoCasas de la capa DAL 
        /// Devuelve una lista de Casa
        /// </summary>
        /// <returns></returns>
        public List<Casa> getCasa()
        {
            List<Casa> listaCasas = listadoDAl.getListadoCasas();
            return listaCasas;

        }


    }
}
