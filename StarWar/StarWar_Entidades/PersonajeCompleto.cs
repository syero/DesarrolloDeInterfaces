﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

/**
https://stackoverflow.com/questions/35111635/how-can-i-convert-a-image-into-a-byte-array-in-uwp-platform
    este enlace es para convertir un array de byts en una imagen 
     me va a ahacer falta para poder mostra la imagen del personaje
     hare la conversion en la entidad PersonajeCompleto que extenderea de personaje

     https://stackoverflow.com/questions/47893713/no-bitmapimage-in-uwp?rq=1

*/

namespace StarWar_Entidades
{
    public class PersonajeCompleto : Personaje
    {
        public String NombreTrilogia { get; set; }
        public String NombrePelicula { get; set; }

        public PersonajeCompleto() { }

        public PersonajeCompleto(int idPersonaje, String nombre, String titulo, String raza, String equipamiento, byte[] foto, String nombreTrilogia, String nombrePelicula)
        : base(idPersonaje, nombre, titulo, raza, equipamiento, foto)
        {
            this.NombreTrilogia = nombreTrilogia;
            this.NombrePelicula = nombrePelicula;
        }

        public PersonajeCompleto(String nombre, String titulo, String raza, String equipamiento, byte[] foto, String nombreTrilogia, String nombrePelicula)
          : base(nombre, titulo, raza, equipamiento, foto)
        {
            this.NombreTrilogia = nombreTrilogia;
            this.NombrePelicula = nombrePelicula;
        }

    }
}
