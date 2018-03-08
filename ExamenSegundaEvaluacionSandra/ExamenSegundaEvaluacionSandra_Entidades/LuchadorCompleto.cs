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

        public String fotoLuchador { get; set; }
        public String fotoCasaLuchador { get; set; }
        public String nombreCasa { get; set; }
        public int idCategoria { get; set; }
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

        public LuchadorCompleto(int idLuchador, string nombre, int idCasa, String nombreCasa, int idCategoria
            , String nombreCategoriaPremio, int puntosCombateSangriento, int puntosCombateEspectacular, int puntosCombateVirtuoso) 
            : base(idLuchador, nombre, idCasa)
        {
            this.nombreCasa = nombreCasa;
            this.idCategoria = idCategoria;
            this.nombreCategoriaPremio = nombreCategoriaPremio;
            this.puntosCombateSangriento = puntosCombateSangriento;
            this.puntosCombateEspectacular = puntosCombateEspectacular;
            this.puntosCombateVirtuoso = puntosCombateVirtuoso;
        }


        /// <summary>
        /// Va a permitir mostra la fotos de la familia a la que pertenence ese luchador
        /// </summary>
        public void AsignarFotoCasaLuchador()
        {
            switch (idCasa)
            {
                case 1:
                    fotoCasaLuchador = "../Images/Casas/1.png";
                    break;
                case 2:
                    fotoCasaLuchador = "../Images/Casas/2.png";
                    break;
                case 3:
                    fotoCasaLuchador = "../Images/Casas/3.png";
                    break;
                case 4:
                    fotoCasaLuchador = "//Assets/Images/Casas/4.png";
                    break;
                case 5:
                    fotoCasaLuchador = "//Assets/Images/Casas/5.png";
                    break;
                case 6:
                    fotoCasaLuchador = "//Assets/Images/Casas/6.png";
                    break;
                case 7:
                    fotoCasaLuchador = "//Assets/Images/Casas/7.png";
                    break;
                case 8:
                    fotoCasaLuchador = "//Assets/Images/Casas/8.png";
                    break;
            }

        }

        /// <summary>
        /// Nos va a asignar a cada luchador la foto que le corresponde 
        /// </summary>
        public void AsignarFotoLuchador()
        {
            switch (idLuchador)
            {
                case 1:
                    fotoLuchador = "/Assets/Images/Luchadores/1.jpg";
                    break;
                case 2:
                    fotoLuchador = "/Assets/Images/Luchadores/2.jpg";
                    break;
                case 3:
                    fotoLuchador = "/Assets/Images/Luchadores/3.jpg";
                    break;
                case 4:
                    fotoLuchador = "/Assets/Images/Luchadores/4.jpg";
                    break;
                case 5:
                    fotoLuchador = "/Assets/Images/Luchadores/5.jpg";
                    break;
                case 6:
                    fotoLuchador = "/Assets/Images/Luchadores/6.jpg";
                    break;
                case 7:
                    fotoLuchador = "/Assets/Images/Luchadores/7.jpg";
                    break;
                case 8:
                    fotoLuchador = "/Assets/Images/Luchadores/8.jpg";
                    break;
            }

        }

    }
}
