﻿using SankeBL.Listados;
using Snake.ClasesDeDatos;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SnakeUI.ViewModels
{
   public class MapasViewModel :clsVMBase
    {
        private List<Mapa> _listaMapas;
        private Mapa _mapaSeleccionado;
        private bool _ordenarPorValoracion;
        private ConstantesImageSource constantes;

        public ObservableCollection<ObservableCollection<String>> sourceList { get; set; }

        ListadoMapasBL listadoMapasBL = new ListadoMapasBL();
        private int MAX_FILAS = 11;
        private int MAX_COLUMNAS = 20;

        public MapasViewModel()
        {
            constantes = new ConstantesImageSource();
            sourceList = new ObservableCollection<ObservableCollection<string>>();
            obtenerMapas();
            rellenarSourceListBlanco();  
        }


        private void rellenarSourceListBlanco()
        {
            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                sourceList.Add(new ObservableCollection<String>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    sourceList[i].Add(constantes.FONDO);
                }
            }
        }

        public List<Mapa> ListaMapas
        {
            get { return _listaMapas; }
            set { this._listaMapas = value; NotifyPropertyChanged("ListaMapas"); }
        }

        public Mapa MapaSeleccionado
        {
            get { return _mapaSeleccionado; }
            set { this._mapaSeleccionado = value;
                cargarVisualizacionMapaSeleccionado();
                NotifyPropertyChanged("MapaSeleccionado"); }
        }

        public bool OrdenarPorValoracion
        {
            get { return _ordenarPorValoracion; }
            set { this._ordenarPorValoracion = value; NotifyPropertyChanged("OrdenarPorValoracion"); }
        }      

        public async void obtenerMapas()
        {
            _listaMapas = await listadoMapasBL.getListadoBL(OrdenarPorValoracion);
            NotifyPropertyChanged("ListaMapas");
        }

        /// <summary>
        /// Cargar la previsualizacion del mapa seleccionado :)
        /// </summary>
        public void cargarVisualizacionMapaSeleccionado()
        {
            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                sourceList.Add(new ObservableCollection<String>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    if (_mapaSeleccionado.Casillas[i][j])
                    {
                        sourceList[i][j] = constantes.MURO;
                    }
                    else
                    {
                        sourceList[i][j] = constantes.FONDO;
                    }

                }
            }
        }

        //public async void MapasPorValoracion()
        //{
        //    ListaMapas = await listadoMapasBL.getListadoBL(OrdenarPorValoracion);
        //    NotifyPropertyChanged("ListaMapas");
        //}



    }
}
