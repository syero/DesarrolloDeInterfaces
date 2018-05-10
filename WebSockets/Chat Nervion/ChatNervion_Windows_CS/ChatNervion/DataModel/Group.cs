using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatNervion.DataModel
{
    public class Group
    {
        public Group(string nombreGrupo, string nick, string message)
        {
            this.nombreGrupo = nombreGrupo;
            Nick = nick;
            Message = message;
        }

        public Group() {
            this.nombreGrupo = "";
            Nick = "";
            Message = "";
        }

        public string nombreGrupo { get; set; }
        public string Nick { get; set; }
        public string Message { get; set; }
    }
}
