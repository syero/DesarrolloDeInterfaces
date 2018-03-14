using ExamenSandra_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSandra_Entidades
{
   public class LuchadorCompleto:Luchador
    {
        public String fotoCasaLuchador { get; set; }
        public String fotoLuchador { get; set; }
        public String nombreCasa { get; set; }
        public String nombreCategoriaPremio { get; set; }
        public int puntosCombateSangriento { get; set; }
        public int puntosCombateEspectacular { get; set; }
        public int puntosCombateVirtuoso { get; set; }

        public LuchadorCompleto(){}

        public LuchadorCompleto(int idLuchador, string nombre, int idCasa, String nombreCasa)
          : base(idLuchador, nombre, idCasa)
        {
            this.nombreCasa = nombreCasa;
        }

        public LuchadorCompleto(int idLuchador, string nombre, int idCasa, String nombreCasa, String nombreCategoriaPremio
            , int puntosCombateSangriento, int puntosCombateEspectacular, int puntosCombateVirtuoso) 
            : base(idLuchador, nombre, idCasa)
        {
            this.nombreCasa = nombreCasa;
            this.nombreCategoriaPremio = nombreCategoriaPremio;
            this.puntosCombateSangriento = puntosCombateSangriento;
            this.puntosCombateEspectacular = puntosCombateEspectacular;
            this.puntosCombateVirtuoso = puntosCombateVirtuoso;            
        }

    }
}
