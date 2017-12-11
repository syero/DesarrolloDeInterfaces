using SandraRepasoBindingNavegarEntrePaginasCommand.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandraRepasoBindingNavegarEntrePaginasCommand.Model
{
    public class Login : clsVMBase
    {
        #region "Atributos"
            private String _nombreUsuario;
            private String _password;
        #endregion

        #region "Contructores"
            public Login()
            {
                 _nombreUsuario=" ";
                 _password=" ";
            }

            public Login(String nNombreUsuario, String nPassword)
            {
                _nombreUsuario = nNombreUsuario;
                _password = nPassword;
            }

        #endregion

        #region "Gets y Sets"
            public String NombreUsuario {
                get { return _nombreUsuario; }
                set { this._password = value; NotifyPropertyChanged("NombreUsuario"); }

            }

            public String Password {
                get { return _password; }
                set { this._password = value; NotifyPropertyChanged("Password"); }
            }

        #endregion

    }
}
