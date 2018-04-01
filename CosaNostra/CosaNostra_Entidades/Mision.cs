using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaNostra_Entidades
{
    public class Mision
    {
        public int CondigoMision { get; set; }
        public String TituloMision { get;set;}
        public bool Reservada { get; set; }
        public int CodigoMafioso { get; set; }
        public bool Cumplida { get; set; }
        public DateTime FechaCumplimiento { get; set; }
        public String Observaciones { get; set; }
        public String DescripcionMision { get; set; }

       // private DateTime FechaCumplimiento;

        public Mision() { }

        public Mision(int condigoMision,String tituloMision, bool reservada, int codigoMafioso,bool cumplida
                     ,DateTime fechaCumplimiento, String observaciones, String descripcionMision )
        {
            this.CondigoMision = condigoMision;
            this.TituloMision = tituloMision;
            this.Reservada = reservada;
            this.CodigoMafioso = codigoMafioso;
            this.Cumplida = cumplida;
            this.FechaCumplimiento = fechaCumplimiento;
            this.Observaciones = observaciones;
            this.DescripcionMision = descripcionMision;
        }

        public Mision(int condigoMision, String tituloMision, bool reservada, bool cumplida, String observaciones, String descripcionMision)
        {
            this.CondigoMision = condigoMision;
            this.TituloMision = tituloMision;
            this.Reservada = reservada;
            this.Cumplida = cumplida;
            this.Observaciones = observaciones;
            this.DescripcionMision = descripcionMision;
        }
    }
}
