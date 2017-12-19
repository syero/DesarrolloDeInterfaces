using SegundoEjercicioExamen.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SegundoEjercicioExamen.Model
{
    public class GestionTodosLosListados
    {
        public ObservableCollection<CFGSDAM> cursosCiclo;
        public ObservableCollection<Alumno> listaPersonas = new ObservableCollection<Alumno>();
        public ObservableCollection<Alumno> listadoClase;

        /// <summary>
        /// método que nos devuelve los cursos de los que se compone en ciclo
        /// no tiene entradas y devulve una lista de cursos
        /// </summary>
        /// <returns>listado de cursos de ciclo</returns>

        public ObservableCollection<CFGSDAM> ObtenerCursosCiclo()
        {
            cursosCiclo = new ObservableCollection<CFGSDAM>();

            CFGSDAM primerCurso = new CFGSDAM(1,"Primero CFGS");
            CFGSDAM segundoCurso = new CFGSDAM(2,"Segundo CFGS");

            cursosCiclo.Add(primerCurso);
            cursosCiclo.Add(segundoCurso);

            return cursosCiclo;

        }



            /// <summary>
            /// método que nos devuelve un listado de todos los alumnos del primer curso del ciclo
            /// no tiene entradas y devuelve una lista de alumnos
            /// </summary>
            /// <returns>lista de personas</returns>
        //    public ObservableCollection<Alumno> ObtenerListadoAlumnosPrimerCurso()
        //    {
        //        listaPersonas = new ObservableCollection<Alumno>();

        //        Alumno David = new Alumno("David Abraham", "Aguilar Martín",1);
        //        Alumno Carlos = new Alumno("Carlos", "Alberto Vadillo", 1);
        //        Alumno Manuel = new Alumno("Manuel", "Bancalero Carretero", 1);
        //        Alumno Yeray = new Alumno("Yeray Manuel", "Campanario Fernández", 1);
        //        Alumno Oscar = new Alumno("Óscar", "Funes Trigo", 1);
        //        Alumno Sergio = new Alumno("Sergio", " Gamero Cañete", 1);
        //        Alumno Abraham = new Alumno("Abraham", " Gómez Reyes", 1);
        //        Alumno Raquel = new Alumno("Raquel", "González Trujill", 1);

        //        listaPersonas.Add(David);
        //        listaPersonas.Add(Carlos);
        //        listaPersonas.Add(Manuel);
        //        listaPersonas.Add(Yeray);
        //        listaPersonas.Add(Oscar);
        //        listaPersonas.Add(Sergio);
        //        listaPersonas.Add(Abraham);
        //        listaPersonas.Add(Raquel);


        //    return listaPersonas;
        //}


        ///// <summary>
        ///// método que nos devuelve un listado de todos los alumnos del segundo curso del ciclo
        ///// no tiene entradas y devuelve una lista de alumnos
        ///// </summary>
        ///// <returns>lista de personas</returns>
        //public ObservableCollection<Alumno> ObtenerListadoAlumnosSegundo()
        //{
        //    listaPersonas = new ObservableCollection<Alumno>();

        //    Alumno Daniel = new Alumno("Daniel", "Gordillo Rodríguez", 2);
        //    Alumno Ivan = new Alumno("Iván", "Leo Morilla", 2);
        //    Alumno Rafael = new Alumno("Rafael", "Manzano Medina", 2);
        //    Alumno Ezequiel = new Alumno("Ezequiel", "Martínez Vicente", 2);
        //    Alumno Pablo = new Alumno("Pablo", "Prat Jiménez", 2);
        //    Alumno Genaro = new Alumno("Genaro", " Rodríguez Seda", 2);

        //    listaPersonas.Add(Daniel);
        //    listaPersonas.Add(Ivan);
        //    listaPersonas.Add(Rafael);
        //    listaPersonas.Add(Ezequiel);
        //    listaPersonas.Add(Pablo);
        //    listaPersonas.Add(Genaro);

        //    return listaPersonas;
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Alumno> ObtenerListadoAlumnos()
        {
            

            Alumno David = new Alumno("David Abraham", "Aguilar Martín", 1);
            Alumno Carlos = new Alumno("Carlos", "Alberto Vadillo", 1);
            Alumno Manuel = new Alumno("Manuel", "Bancalero Carretero", 1);
            Alumno Yeray = new Alumno("Yeray Manuel", "Campanario Fernández", 1);
            Alumno Oscar = new Alumno("Óscar", "Funes Trigo", 1);
            Alumno Sergio = new Alumno("Sergio", " Gamero Cañete", 1);
            Alumno Abraham = new Alumno("Abraham", " Gómez Reyes", 1);
            Alumno Raquel = new Alumno("Raquel", "González Trujill", 1);


            Alumno Daniel = new Alumno("Daniel", "Gordillo Rodríguez", 2);
            Alumno Ivan = new Alumno("Iván", "Leo Morilla", 2);
            Alumno Rafael = new Alumno("Rafael", "Manzano Medina", 2);
            Alumno Ezequiel = new Alumno("Ezequiel", "Martínez Vicente", 2);
            Alumno Pablo = new Alumno("Pablo", "Prat Jiménez", 2);
            Alumno Genaro = new Alumno("Genaro", " Rodríguez Seda", 2);

            listaPersonas.Add(David);
            listaPersonas.Add(Carlos);
            listaPersonas.Add(Manuel);
            listaPersonas.Add(Yeray);
            listaPersonas.Add(Oscar);
            listaPersonas.Add(Sergio);
            listaPersonas.Add(Abraham);
            listaPersonas.Add(Raquel);       

            listaPersonas.Add(Daniel);
            listaPersonas.Add(Ivan);
            listaPersonas.Add(Rafael);
            listaPersonas.Add(Ezequiel);
            listaPersonas.Add(Pablo);
            listaPersonas.Add(Genaro);

            return listaPersonas;
        }

        /// <summary>
        /// este metodo va a devolver los alumnos de un curso
        /// entradas: la id del curso
        /// salidas: la lista de los alumnos que cursan  ese curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public ObservableCollection<Alumno> ObtenerAlumnosPorIdCurso(int idCurso)
        {
           listadoClase = new ObservableCollection<Alumno>();


            for (int i = 0; i < this.listaPersonas.Count(); i++)
            {
                if (listaPersonas.ElementAt(i).IdCurso == idCurso)
                {
                    listadoClase.Add(listaPersonas.ElementAt(i));
                }
            }

            return listadoClase;
        }
    }
}

