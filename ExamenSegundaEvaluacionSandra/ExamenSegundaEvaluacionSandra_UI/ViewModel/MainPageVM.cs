using ExamenSandra_BL.Gestionadora;
using ExamenSandra_BL.Listado;
using ExamenSandra_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_UI.ViewModel
{
   public class MainPageVM : clsVMBase
    {
        #region "Atributos" 

        private ObservableCollection<Combate> _listaCombates;
        private ObservableCollection<LuchadorCompleto> _listaLuchadores;
        private ObservableCollection<CategoriaPremio> _listaCategoriasPremios;
      
        private Combate _combateSeleccionado;
        private Luchador _luchadorUno;
        private Luchador _luchadorDos;
        private CategoriaPremio _categoriaPremioSeleccionada;
 

        ListadoBL listadoBL = new ListadoBL();
        GestionadoraBL gestionadoraBL = new GestionadoraBL();

        #endregion


        public MainPageVM()
        {
            _listaCombates = new ObservableCollection<Combate>(listadoBL.getCombates());
            _listaLuchadores=new ObservableCollection<LuchadorCompleto>(listadoBL.getLuchadores());
            _listaCategoriasPremios= new ObservableCollection<CategoriaPremio>(listadoBL.getCategoriasPremios());

            //esto es solo para testear si se inserta algo o no ,descomentalo para testear
           // guardarClasificacionCombate();

        }


        #region "Getes y Setes" 

        //ListadoCombates
        public ObservableCollection<Combate> ListadoCombates
        {
            get { return _listaCombates; }
            set
            {
                this._listaCombates = value;
                NotifyPropertyChanged("ListadoCombates");
            }
        }

        //Combate seleccionado
        public Combate CombateSeleccionado
        {
            get { return (_combateSeleccionado); }
            set
            {
                this._combateSeleccionado = value;
                NotifyPropertyChanged("CombateSeleccionado");
            }
        }

        //ListadoLuchadores
        public ObservableCollection<LuchadorCompleto> ListadoLuchadores
        {
            get { return _listaLuchadores; }
            set
            {
                this._listaLuchadores = value;
                NotifyPropertyChanged("ListadoLuchadores");
            }
        }

        //LuchadorSeleccionado
        public Luchador LuchadorUno
        {
            get { return (_luchadorUno);   }
            set
            {
                this._luchadorUno = value;
                NotifyPropertyChanged("LuchadorUno");
            }
        }

        public Luchador LuchadorDos
        {
            get { return (_luchadorDos); }
            set
            {
                this._luchadorDos = value;
                NotifyPropertyChanged("LuchadorDos");
            }
        }

        //ListadoCombates
        public ObservableCollection<CategoriaPremio> ListaCategoriasPremios
        {
            get { return _listaCategoriasPremios; }
            set
            {
                this._listaCategoriasPremios = value;
                NotifyPropertyChanged("ListaCategoriasPremios");
            }
        }

        public CategoriaPremio CategoriaPremioSeleccionada
        {
            get { return (_categoriaPremioSeleccionada); }
            set
            {
                this._categoriaPremioSeleccionada = value;
                NotifyPropertyChanged("CategoriaPremioSeleccionada");
            }
        }


        #endregion


        #region"Metodos muy importantes "       

        /// <summary>
        /// Este metodo va a guardar las Clasificaciones del Combate
        /// Obtendremos la id del combate seleccionado 
        /// los punto dados al luchador
        /// la id de la categoria seleccionada 
        /// la id del luchador seleccionado
        /// 
        /// Este metodo funciona pero solo guarda de uno en uno :(
        /// 
        /// Debi guardar las puntuaciones y la id de la clasificacion en un array y haberlas recorrido a la hora de 
        /// meter las clasificaciones
        /// </summary>
        public void guardarClasificacionCombate(LuchadorCompleto luchador)
        { 
            clasificacion = new ClasificacionCombate(_combateSeleccionado.idCombate,luchador.idCategoria,luchador.idLuchador);
            gestionadoraBL.insertarClasificacionesCombatesBL(clasificacion);
        }

        #endregion
    }
}
