using System;
using System.Collections.ObjectModel;

namespace MostrarUnaListaPersonaConDataContext.Models
{
    public class clsListadoPersonas
    {

        /// <summary>
        /// método que nos devuelve un listado de personas
        /// </summary>
        /// <returns>lista de personas</returns>
        public  ObservableCollection<Persona> ObtenerListado()
        {
            ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();
            listaPersonas.Add(new Persona("Assets/Imagenes/img1.jpg","Pablo", "KIKOs",new DateTime(1992,06,26,0,0,0,0),"Lo que sea","954682745"));
            listaPersonas.Add(new Persona("Assets/Imagenes/img2.jpg","Marienda", "MuyCorta", new DateTime(1998,01,10, 0, 0, 0, 0), "En su casa", "963215478"));
            listaPersonas.Add(new Persona("Assets/Imagenes/img3.jpg","Alan", "BritoPrieto",new DateTime(1990,04,07, 0, 0, 0, 0), "Calle 12", "987542361"));
            listaPersonas.Add(new Persona("Assets/Imagenes/img4.jpg", "Max", "Pecos", new DateTime(1992, 06, 26, 0, 0, 0, 0), "Av la nata", "954682745"));
            listaPersonas.Add(new Persona("Assets/Imagenes/img5.jpg", "Grand", "Escubrimiento", new DateTime(1998, 01, 10, 0, 0, 0, 0), "Calle casa sola", "963215478"));
            listaPersonas.Add(new Persona("Assets/Imagenes/img6.jpg","Art", "Istafracasado", new DateTime(1990, 04, 07, 0, 0, 0, 0), "Calle 131", "987542361"));
            listaPersonas.Add(new Persona("Assets/Imagenes/img7.jpg", "Marin", "Ador", new DateTime(1990, 04, 07, 0, 0, 0, 0), "Av pradera", "987542361"));

            return listaPersonas;
        }

    }//Fin clsListadoPersona
}