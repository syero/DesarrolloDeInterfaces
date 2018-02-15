using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ClasesDeDatos
{
    class ConstantesImageSource
    {        
        public String CABEZA_IZQ { get; }
        public String CABEZA_ARR { get; }
        public String CABEZA_DER { get; }
        public String CABEZA_ABA { get; }

        public String CUERPO_HOR { get; }
        public String CUERPO_VER { get; }

        public String CURVA_ARR_DER { get; }
        public String CURVA_DER_ABA { get; }
        public String CURVA_IZQ_ABA { get; }
        public String CURVA_IZQ_ARR { get; }

        public String CULO_IZQ { get; }
        public String CULO_ARR { get; }
        public String CULO_DER { get; }
        public String CULO_ABA { get; }

        public String FONDO { get; }
        public String COMIDA { get; }
        public String MURO { get; }
        public ConstantesImageSource() {
            this.CABEZA_IZQ = "Assets/gato/cabeza-izq.png";
            this.CABEZA_ARR = "Assets/gato/cabeza-arr.png";
            this.CABEZA_DER = "Assets/gato/cabeza-der.png";
            this.CABEZA_ABA = "Assets/gato/cabeza-aba.png";

            this.CUERPO_HOR = "Assets/gato/cuerpo-hor.png";
            this.CUERPO_VER = "Assets/gato/cuerpo-ver.png";

            this.CURVA_ARR_DER = "Assets/gato/curva-arr-der.png";
            this.CURVA_DER_ABA = "Assets/gato/curva-der-aba.png";
            this.CURVA_IZQ_ABA = "Assets/gato/curva-izq-aba.png";
            this.CURVA_IZQ_ARR = "Assets/gato/curva-izq-arr.png";

            this.CULO_IZQ = "Assets/gato/culo-izq.png";
            this.CULO_ARR = "Assets/gato/culo-arr.png";
            this.CULO_DER = "Assets/gato/culo-der.png";
            this.CULO_ABA = "Assets/gato/culo-aba.png";

            this.FONDO = "Assets/transparente.png";
            this.COMIDA = "Assets/comida.png";
            this.MURO = "Assets/muro.png";
        }
    }
}
