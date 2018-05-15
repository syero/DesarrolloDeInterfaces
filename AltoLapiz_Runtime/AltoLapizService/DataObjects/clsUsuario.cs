using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoLapizService.DataObjects
{
    public class clsUsuario
    {
        //Atributos

        public String nick { get; set; }
        public int idGrupo { get; set; }
        public ObservableCollection<clsPalabra> arrayPalabras { get; set; }


        //Constructor por parámetros

        public clsUsuario(string nick, int idGrupo, ObservableCollection<clsPalabra> arrayPalabras)
        {
            this.nick = nick;
            this.idGrupo = idGrupo;
            this.arrayPalabras = arrayPalabras;
        }

        //Constructor por defecto
        public clsUsuario()
        {
            this.nick = "";
            this.idGrupo = 0;
            this.arrayPalabras = null;
        }

    }
}
