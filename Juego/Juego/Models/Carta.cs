using Juego.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego.Models
{
         public class Carta : clsVMBase
        {
            private int _idCarta;
            private Uri _uri;
            private String _nombreCarta;


            public Carta(int _nIdCarta, Uri uri, String nNombreCarta)
            {
                this._idCarta = _nIdCarta;
                this._uri = uri;
                this._nombreCarta = nNombreCarta;

            }

            public String nombre
            {
                get
                {
                    return this._nombreCarta;
                }
                set
                {
                    this._nombreCarta = value;
                }
            }

            public int idCarta
            {
                get
                {
                    return this._idCarta;

                }
                set
                {
                    this._idCarta = value;
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

