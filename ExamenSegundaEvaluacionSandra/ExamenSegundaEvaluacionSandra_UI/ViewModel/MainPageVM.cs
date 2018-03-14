using ExamenSandra_BL.Gestionadora;
using ExamenSandra_BL.Listado;
using ExamenSandra_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ExamenSandra_UI.ViewModel
{
   public class MainPageVM : clsVMBase
    {
        #region "Atributos" 

        private ObservableCollection<Combate> _listaCombates;
        private ObservableCollection<LuchadorCompleto> _listaLuchadores;
      
        private Combate _combateSeleccionado;
        private LuchadorCompleto _luchadorUno;
        private LuchadorCompleto _luchadorDos;

        private ListadoBL listadoBL = new ListadoBL();
        private GestionadoraBL gestionadoraBL = new GestionadoraBL();
        public List<int> puntuacionesPermitidas = new List<int> { 5, 10 };

        #endregion


        public MainPageVM()
        {
            _listaCombates = new ObservableCollection<Combate>(listadoBL.getCombates());
            _listaLuchadores=new ObservableCollection<LuchadorCompleto>(listadoBL.getLuchadores());
          
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

     
        public LuchadorCompleto LuchadorUno
        {
            get { return (_luchadorUno);   }
            set
            {
                this._luchadorUno = value;
                NotifyPropertyChanged("LuchadorUno");
            }
        }

        public LuchadorCompleto LuchadorDos
        {
            get { return (_luchadorDos); }
            set
            {
                this._luchadorDos = value;
                NotifyPropertyChanged("LuchadorDos");
            }
        }

        #endregion


        #region"Metodos muy importantes "   
        /// <summary>
        /// este metodo me va a permitir seleccionar dos jugadores de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void luchadoresSeleccionados(object sender, SelectionChangedEventArgs e)
        {
            LuchadorUno = (sender as ListView).SelectedItems.First() as LuchadorCompleto;
            LuchadorDos = (sender as ListView).SelectedItems.Last() as LuchadorCompleto;

            NotifyPropertyChanged("LuchadorUno");
            NotifyPropertyChanged("LuchadorDos");          
            
        }


    /// <summary>
    /// Este metodo va a pasar 
    ///  el idCombate, el lucharoUno y el LuchadorDos
    /// la capa BL que a su ves pasara a la DAL para insertar la clasificacion de combate 
    /// </summary>
    public void guardarClasificacionCombate()
        { 
            gestionadoraBL.insertarClasificacionesCombatesBL(_combateSeleccionado.idCombate, _luchadorUno, _luchadorDos);
        }

        #endregion
    }
}
