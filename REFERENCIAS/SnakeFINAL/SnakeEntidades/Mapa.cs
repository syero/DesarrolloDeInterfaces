﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEntidades
{
    public class Mapa
    {
        public int IDMapa { get; set; }
        public String NombreMapa { get; set; }
        public String NombreUsuario { get; set; }
        public ObservableCollection<ObservableCollection<bool>> Casillas { get; set; }
        public int ValoracionMapa { get; set; }
        public DateTime FecharCreacion { get; set; }

        public Mapa()
        {
            NombreMapa = "";
            NombreUsuario = "";
            Casillas = new ObservableCollection<ObservableCollection<bool>>();
            ValoracionMapa = 0;
            FecharCreacion = DateTime.Now;
        }

        public Mapa(String n_NombreMapa, String n_NombreUsuario, ObservableCollection<ObservableCollection<bool>> n_Casillas, int n_ValoracionMapa)
        {
            NombreMapa = n_NombreMapa;
            NombreUsuario = n_NombreUsuario;
            Casillas = n_Casillas;
            ValoracionMapa = n_ValoracionMapa;
            FecharCreacion = DateTime.Now;
        }

    }

}