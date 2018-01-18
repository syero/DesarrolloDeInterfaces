using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeWebAPI_Entidades
{
    public class Mapa
    {
        public int IDMapa { get; set; }
        public String NombreMapa { get; set; }
        public String NombreUsuario { get; set; }
        public String MapaJson { get; set; }
        public int ValoracionMapa { get; set; }
        public DateTime FecharCreacion { get; set; }

        public Mapa()
        {
            NombreMapa = "";
            NombreUsuario = "";
            MapaJson = "";
            ValoracionMapa = 0;
            FecharCreacion = DateTime.Now;
        }

        public Mapa(String n_NombreMapa,String n_NombreUsuario,String n_MapaJson,int n_ValoracionMapa)
        {
            NombreMapa = n_NombreMapa;
            NombreUsuario = n_NombreUsuario;
            MapaJson = n_MapaJson;
            ValoracionMapa = n_ValoracionMapa;
            FecharCreacion = DateTime.Now;
        }

    }
}
