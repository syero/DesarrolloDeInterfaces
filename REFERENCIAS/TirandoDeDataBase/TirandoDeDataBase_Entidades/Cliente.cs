using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirandoDeDataBase_Entidades
{
     public class Cliente
    {
        public int codigo { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String numeroCuenta { get; set; }
        public String telefono { get; set; }
        public String video { get; set; }

        public Cliente()
        {
            nombre = " ";
            direccion = " ";
            numeroCuenta = " ";
            telefono = " ";
            video = "";
        }

        public Cliente(int codigo,String telefono, String direccion, String numeroCuenta, String nombre,String video)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.direccion = direccion;
            this.numeroCuenta = numeroCuenta;
            this.telefono = telefono;
            this.video = video;
        }

    }
}
