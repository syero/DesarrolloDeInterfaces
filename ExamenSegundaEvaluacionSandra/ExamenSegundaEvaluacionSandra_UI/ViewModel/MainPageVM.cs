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
        private LuchadorCompleto _luchadorSeleccionado;

        private ListadoBL listadoBL = new ListadoBL();
        private GestionadoraBL gestionadoraBL = new GestionadoraBL();

        public List<int> puntuacionesPermitidas;
        public static String nombreGanador;
        public static String nombrePerdedor;
        #endregion


        public MainPageVM()
        {
            _listaCombates = new ObservableCollection<Combate>(listadoBL.getCombates());
            _listaLuchadores=new ObservableCollection<LuchadorCompleto>(listadoBL.getLuchadores());
            puntuacionesPermitidas = new List<int> { 5, 10 };
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


        public LuchadorCompleto LuchadorSeleccionado
        {
            get { return (_luchadorSeleccionado); }
            set
            {
                this._luchadorSeleccionado = value;
                //asigamos el luchadorSeleccionado al luchador que esté a null 
                if (LuchadorUno == null )
                {
                    LuchadorUno = _luchadorSeleccionado;              
                }
                else
                {
                    if (LuchadorUno != _luchadorSeleccionado && LuchadorDos!=LuchadorUno )
                    {
                        LuchadorDos = LuchadorUno;
                        LuchadorUno= _luchadorSeleccionado;
                    }                                   
                }
                NotifyPropertyChanged("LuchadorUno");
                NotifyPropertyChanged("LuchadorDos");
                NotifyPropertyChanged("LuchadorSeleccionado");
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
        /// Este metodo va a pasar 
        ///  el idCombate, el lucharoUno y el LuchadorDos
        /// la capa BL que a su ves pasara a la DAL para insertar la clasificacion de combate 
        /// </summary>
        public void guardarClasificacionCombate()
        {

            if (LuchadorUno.puntosCombateSangriento != LuchadorDos.puntosCombateSangriento
                && LuchadorUno.puntosCombateEspectacular != LuchadorDos.puntosCombateEspectacular
                && LuchadorUno.puntosCombateVirtuoso != LuchadorDos.puntosCombateVirtuoso)
            {
                gestionadoraBL.insertarClasificacionesCombatesBL(CombateSeleccionado.idCombate, LuchadorUno, LuchadorDos);
                resultadoBatalla(); //comprobar resultados de batalla
                CombateSeleccionado.idCombate = 0;
                LuchadorUno = null;
                LuchadorDos = null;
            }
            else {
                DisplayScoreDialog();                
            }
        }

        /// <summary>
        /// Este metodo solo sirve para mostrar los nombre del 
        /// ganador y el perdedor del la batalla
        /// </summary>
        public void resultadoBatalla()
        {
            if (LuchadorUno.puntosCombateSangriento > LuchadorDos.puntosCombateSangriento
                && LuchadorUno.puntosCombateEspectacular > LuchadorDos.puntosCombateEspectacular
                && LuchadorUno.puntosCombateVirtuoso > LuchadorDos.puntosCombateVirtuoso)
            {
                nombreGanador = LuchadorUno.nombre;
                nombrePerdedor = LuchadorDos.nombre;
            }
            else {
                nombreGanador = LuchadorDos.nombre;
                nombrePerdedor = LuchadorUno.nombre;
            }
            ResultadosDialog(); //dialogo de resultados
        }

        /// <summary>
        /// Este es el dialogo que aparecera cuando demos a los luchadores putuaciones
        /// iguales en la misma catagoria.
        /// Bajo ningun concepto los luchadores deben empatar,puesto que el que pierda debe morir
        /// </summary>
        public async void DisplayScoreDialog()
        {
            ContentDialog puntosIncorrectosDialog = new ContentDialog
            {
                Title = "Puntos Incorrectos",
                Content = "Los luchadores deben tener puntuaciones diferentes en cada categoria",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await puntosIncorrectosDialog.ShowAsync();
        }

        /// <summary>
        /// Este dialogo va a mostrar los resulados de la batalla
        /// o sea quien gana y quien muere
        /// </summary>
        public async void ResultadosDialog()
        {
            ContentDialog resultadosDialog = new ContentDialog
            {
                Title = "Resultados de Batalla ",
                Content = " El luchador ganador es " + nombreGanador + " , muere " + nombrePerdedor + " ",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await resultadosDialog.ShowAsync();
        }
        #endregion
    }
}
