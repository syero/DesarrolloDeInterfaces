using SandraRepasoBindingNavegarEntrePaginasCommand.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandraRepasoBindingNavegarEntrePaginasCommand.Model
{
    public class Pelicula: clsVMBase
    {
        //Atributos
        private int _idPelicula;
        // private String fotoPelicula ;
        private Uri _fotoPelicula;
        private String _nombre;
        private double _duracion;
        private int _fechaEstreno; // es solo el anio por eso lo he puesto como entero
        private String _director;
        private String _descripcion;
        private ObservableCollection<Persona> _reparto;


        //contructor por defecto
        public Pelicula()
        {
            _idPelicula = 0;
            _fotoPelicula = new Uri("");
            _nombre = "";
            _duracion = 0.0;
            _fechaEstreno = 0;
            _director = "";
            _descripcion = "";
            ObservableCollection<Persona> _reparto=null;
        }


        //contructor ordinario
        public Pelicula(int nIDPelicula, Uri nFotoPelicula, String nNombre, double nDuracion, int nFechaEstreno, String nDirector, String nDescripcion, ObservableCollection<Persona> nReparto)
        {
            _idPelicula = nIDPelicula;
            _fotoPelicula = nFotoPelicula;
            _nombre = nNombre;
            _duracion = nDuracion;
            _fechaEstreno = nFechaEstreno;
            _director = nDirector;
            _descripcion = nDescripcion;
            _reparto=nReparto;
        }


        //contructor ordinario
        public Pelicula(int nIDPelicula, String nNombre,double nDuracion ,int nFechaEstreno, String nDirector, String nDescripcion)
        {
            _idPelicula = nIDPelicula;
            _nombre = nNombre;
            _duracion = nDuracion;
            _fechaEstreno = nFechaEstreno;
            _director = nDirector;
            _descripcion = nDescripcion;

        }


        //contructor copia
        public Pelicula(Pelicula p)
        {
            _idPelicula = p._idPelicula;
            _fotoPelicula =p._fotoPelicula;
            _nombre = p._nombre;
            _duracion = p._duracion;
            _fechaEstreno = p._fechaEstreno;
            _director = p._director;
            _descripcion = p._descripcion;
            _reparto=p._reparto;
        }


        // IdPelicula
        public int IDPelicula
        {
           get{ return _idPelicula; }
            set{
                this._idPelicula = value;   NotifyPropertyChanged("IDPelicula");
            }
        }

        // FotoPelicula
        public Uri FotoPelicula
        {
          get { return _fotoPelicula; }
          set { this._fotoPelicula = value; NotifyPropertyChanged("FotoPelicula"); }
        }


        // Nombre
        public String Nombre
        {
           get{ return (_nombre); }
           set{ this._nombre = value; NotifyPropertyChanged("Nombre"); }
        }
       

        // Duracion
        public double Duracion
        {
            get { return (_duracion); }
            set { this._duracion = value; NotifyPropertyChanged("Duracion"); }

        }

        //FechaEstreno
        public int FechaEstreno
        {
           get { return (_fechaEstreno); }
           set { this._fechaEstreno = value; }
        }
        

        // Director(en el futuro sera un objeto de tipo Persona)
        public String Director
        {
           get { return (_director); }
            set { this._director = value; NotifyPropertyChanged("Director"); }

        }
      

        //Descripcion
        public String Descripcion {
            get { return _descripcion; }
            set { this._descripcion = value; NotifyPropertyChanged("Descripcion"); }

            }
     
        //Reparto
        public ObservableCollection<Persona> Reparto {
            get { return _reparto; }
            set { this._reparto = value; }
        }

        /**toString*/
        public String toString()
        {
            String str = ("IDPelicula"+ "FotoPelicula"+ "Nombre");
            return (str);

        }


    }
}
