using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoLapizService.DataObjects
{
    public class clsGrupo : clsPartida
    {
        //Atributos
        public int numeroParticipantes { get; set; }
        public bool estadoAbierto { get; set; }

        //Constructor por parametros
        public clsGrupo(int numeroRondas, string pais, string nombrePartida , int numeroParticipantes, bool estadoAbierto)
        :base(numeroRondas, pais, nombrePartida)
        {
            this.numeroParticipantes = numeroParticipantes;
            this.estadoAbierto = estadoAbierto;
        }


        //Constructor por defecto
        public clsGrupo()
        : base()
        {
            this.numeroParticipantes = 0;
            this.estadoAbierto = true;
        }

    }
}
