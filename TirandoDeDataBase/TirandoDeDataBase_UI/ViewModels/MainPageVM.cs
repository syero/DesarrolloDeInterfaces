using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TirandoDeDataBase_BL.Listados;
using TirandoDeDataBase_Entidades;

namespace TirandoDeDatabase_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        private Cliente _clienteSeleccionado;
        private ObservableCollection<Cliente> _listaClientes;

        private ListadosBL listados;

        public MainPageVM()
        {
             listados = new ListadosBL();
            _listaClientes = new ObservableCollection<Cliente>(listados.getClientes());

        }

        //getes y setes
        public ObservableCollection<Cliente> ListaClientes
        {
            get { return _listaClientes; }
            set
            {
                this._listaClientes = value;
                NotifyPropertyChanged("ListaClientes");
            }
        }

        public Cliente ClienteSeleccionado
        {
            get { return (_clienteSeleccionado); }
            set
            {
                this._clienteSeleccionado = value;

                //notificacion del cambio para la vista
                NotifyPropertyChanged("ClienteSeleccionado");
            }
        }




    }
}