using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoLapizService.DataObjects
{
    public class clsMensajeChat
    {
        //Atributos
        public String nick { get; set; }
        public String mensaje { get; set; }
        public string nombreGrupo { get; set; }

        //Constructor por parámetros

        public clsMensajeChat(String nombreGrupo, String nick, string mensaje)
        {
            this.nombreGrupo = nombreGrupo;
            this.nick = nick;
            this.mensaje = mensaje;          
        }

        //Constructor por defecto
        public clsMensajeChat()
        {
            this.nombreGrupo = " ";
            this.nick = " ";
            this.mensaje = " ";           
        }

    }
}
