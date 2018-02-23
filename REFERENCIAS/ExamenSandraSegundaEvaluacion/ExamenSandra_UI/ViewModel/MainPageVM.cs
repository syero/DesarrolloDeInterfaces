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
        private ObservableCollection<Luchador> _listaLuchadores;
        private ObservableCollection<CategoriaPremio> _listaCategoriasPremios;
        private ObservableCollection<Casa> _listaCasas;

        private Combate _combateSeleccionado;
        private Luchador _luchadorSeleccionado;
        private CategoriaPremio _categoriaPremioSeleccionada;
        private Casa _casaSeleccionada;

        public int puntosDados;
        public Uri fotoLuchador, fotoCasaLuchador;

        ListadoBL listadoBL = new ListadoBL();
        GestionadoraBL gestionadoraBL = new GestionadoraBL();

        #endregion


        public MainPageVM()
        {
            _listaCombates = new ObservableCollection<Combate>(listadoBL.getCombates());
            _listaLuchadores=new ObservableCollection<Luchador>(listadoBL.getLuchadores());
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
        public ObservableCollection<Luchador> ListadoLuchadores
        {
            get { return _listaLuchadores; }
            set
            {
                this._listaLuchadores = value;
                NotifyPropertyChanged("ListadoLuchadores");
            }
        }

        //LuchadorSeleccionado
        public Luchador LuchadorSeleccionado
        {
            get { return (_luchadorSeleccionado);   }
            set
            {
                this._luchadorSeleccionado = value;
                AsignarFotoLuchador();
                AsignarFotoCasaLuchador();
                NotifyPropertyChanged("LuchadorSeleccionado");
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
        /// Va a permitir mostra la fotos de la familia a la que pertenence ese luchador
        /// </summary>
        public void AsignarFotoCasaLuchador()
        {
            switch (_luchadorSeleccionado.idCasa)
            {
               //  Hice la prueba de cargar las imagenes pero no las cargaba, por lo tanto no segui haciendo el switch
                 case 1:
                     fotoCasaLuchador = new Uri("ms-appx://Juego/Imagenes/Casa/1.png", UriKind.Absolute);
                     NotifyPropertyChanged("LuchadorSeleccionado");
                    break;
            }

        }

        /// <summary>
        /// Nos va a asignar a cada luchador la foto que le corresponde
        /// 
        /// </summary>
        public void AsignarFotoLuchador()
        {
            switch (_luchadorSeleccionado.idLuchador)
            {
                case 1:
                     fotoLuchador = new Uri("ms-appx://Juego/Imagenes/Luchador/1.jpg", UriKind.Absolute) ;
                    NotifyPropertyChanged("LuchadorSeleccionado");
                    break;
            }

        }

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
        public void guardarClasificacionCombate()
        {
            int idCombateSeleccionado = _combateSeleccionado.idCombate;
            int puntos = puntosDados;
            int idCategoriaPremio = _categoriaPremioSeleccionada.idCategoria;
            int idLuchador = _luchadorSeleccionado.idLuchador;
            ClasificacionCombate clasificacion;

            //Descomenta esto para poder testear
            //int idCombateSeleccionado = 1;
            //int puntos = 10;
            //int idCategoriaPremio = 1;
            //int idLuchador = 2;

                clasificacion = new ClasificacionCombate(idCombateSeleccionado, puntos, idCategoriaPremio, idLuchador);
                gestionadoraBL.insertarClasificacionesCombatesBL(clasificacion);
         
                      
        }

        #endregion
    }
}
