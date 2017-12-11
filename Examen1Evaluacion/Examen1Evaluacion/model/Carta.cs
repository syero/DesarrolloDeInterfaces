using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Evaluacion
{
    public class Carta:clsVMBase
    {
        private int _id;
        private Uri _uri;
        private String _nombre;
        

        public Carta(int id,Uri uri,String nombre)
        {
            this._id = id;
            this._uri = uri;
            this._nombre = nombre;
            
        }

        public String nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public int id
        {
            get
            {
                return this._id;
               
            }
            set
            {
                this._id = value;
            }
        }

        public Uri uri
        {
            get
            {
                return this._uri;
            }
            set
            {

                this._uri = value;
                NotifyPropertyChanged("uri");
            }
        }

       
    }
}
