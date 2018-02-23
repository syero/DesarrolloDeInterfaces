using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeWebAPI_Entidades
{
    public class Puntuacion
    {
        public int IDPuntuacion { get; set; }
        public String NombreUsuario { get; set;}
        public int Valor { get; set; }

        public Puntuacion()
        {
            NombreUsuario = "";
            Valor = 0;
        }

        public Puntuacion(String n_NombreUsuario,int n_Valor)
        {
            NombreUsuario = n_NombreUsuario;
            Valor = n_Valor;
        }
    }
}
