using SegundoEjercicioExamen.Model;
using System;
using System.Collections.ObjectModel;

namespace SegundoEjercicioExamen.Model
{
    public class GestionTodosLosListados
    {
        /// <summary>
        /// método que nos devuelve los dos cursos del ciclo
        /// </summary>
        /// <returns>listado de cursos de ciclo</returns>

        public ObservableCollection<CFGSDAM> ObtenerCursosCiclo()
        {
            ObservableCollection<CFGSDAM> cursosCiclo = new ObservableCollection<CFGSDAM>();

            ObservableCollection<Persona> alumnosPrimero =  ObtenerListadoAlumnosPrimero();
            ObservableCollection<Persona> alumnosSegundo = ObtenerListadoAlumnosSegundo();

            CFGSDAM primerCurso = new CFGSDAM("Primero CFGS", alumnosPrimero);
            CFGSDAM segundoCurso = new CFGSDAM("Segundo CFGS", alumnosSegundo);

            cursosCiclo.Add(primerCurso);
            cursosCiclo.Add(segundoCurso);


            return cursosCiclo;

        }



            /// <summary>
            /// método que nos devuelve un listado de personas que estan en el primero curso del ciclo
            /// </summary>
            /// <returns>lista de personas</returns>
            public ObservableCollection<Persona> ObtenerListadoAlumnosPrimero()
        {
            ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();

            Persona David = new Persona("David Abraham", "Aguilar Martín");
            Persona Carlos = new Persona("Carlos", "Alberto Vadillo");

            /*
             Aguilar Martín, David Abraham
            Alberto Vadillo, Carlos
            Bancalero Carretero, Manuel
            Campanario Fernández, Yeray Manuel
            Echarri Morejón, Carlos
            Funes Trigo, Óscar
            Galván Ferrero, David
            Gamero Cañete, Sergio
            García Núñez, José Ángel
            Gómez Reyes, Abraham
            González Trujillo, Raquel
            */

            listaPersonas.Add(David);
            listaPersonas.Add(Carlos);


            return listaPersonas;
        }


        /// <summary>
        /// método que nos devuelve un listado de personas que estan en el segundo curso del ciclo
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Persona> ObtenerListadoAlumnosSegundo()
    {
        ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();

        Persona Daniel = new Persona("Daniel", "Gordillo Rodríguez");
        Persona Iván = new Persona("Iván", "Leo Morilla");

            /*
                Gordillo Rodríguez, Daniel
                Leo Morilla, Iván
                Manzano Medina, Rafael
                Martínez Vicente, Ezequiel
                Mejías Dorado, Ricardo
                Pérez Lobato, Víctor Manuel
                Prat Jiménez, Pablo
                Rodríguez Seda, Genaro
                Van Loy Estero, Ignacio
                Yélamo Jiménez, Sergio*/


            listaPersonas.Add(Daniel);
            listaPersonas.Add(Iván);

            return listaPersonas;
    }

    }
}

