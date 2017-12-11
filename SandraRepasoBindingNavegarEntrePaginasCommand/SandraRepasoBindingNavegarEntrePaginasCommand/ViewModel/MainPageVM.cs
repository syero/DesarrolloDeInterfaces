using SandraRepasoBindingNavegarEntrePaginasCommand.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandraRepasoBindingNavegarEntrePaginasCommand.ViewModel
{
   public class MainPageVM:clsVMBase
    {

        #region "Atributos"
        private ObservableCollection<Login> _listaUsuarios;
        private Login _usuarioSeleccionado;

        //delegate commad para guardar un nuevo suaurio y contraseña
        private DelegateCommand _delegateCommandGuardar;
        

        #endregion

        #region "Constructores"

        public MainPageVM()
        {
            Gestionadora gestion = new Gestionadora();

            //relleno la lista de peliculas
            _listaUsuarios = gestion.usuariosPassword();
            _usuarioSeleccionado = null;

            //delegate command guardar
           // _delegateCommandGuardar = new DelegateCommand();

        }

        public MainPageVM(ObservableCollection<Login> nListaUsuarios, Login nUsuarioSeleccionado)
        {
           
            //relleno la lista de peliculas
            _listaUsuarios = nListaUsuarios;
            _usuarioSeleccionado = nUsuarioSeleccionado;
        }
        #endregion

        

        #region "Gets y Sets"
        public ObservableCollection<Login> ListaUsuarios
        {
            get { return _listaUsuarios; }
            set { this._listaUsuarios = value; NotifyPropertyChanged("ListaUsuarios"); }
        }

        public Login UsuarioSeleccionado
        {
            get { return _usuarioSeleccionado; }
            set { this._usuarioSeleccionado = value; NotifyPropertyChanged("UsuarioSeleccionado"); }

        }


        #endregion


        #region "Metodos"

        public void ExecuteCommadGuardarUsuario()
        {

           
        }


        #endregion

    
    }
}
