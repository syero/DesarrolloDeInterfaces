using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Snake.ClasesDeDatos
{
    public class Serpiente
    {
   
        private ConstantesImageSource constantes;
        private ObservableCollection<ObservableCollection<String>> sourceList;
        private List<TrozoCuerpo> cuerpo;

        private Direccion direccionActual;
        private Direccion direccionNueva;

        private const int MAX_COLUMNAS = 20;
        private const int MAX_FILAS = 11;

        public bool vivo { get; set; }

        public int puntuacion { get; set; }


        public Serpiente(ref ObservableCollection<ObservableCollection<String>> sourceList)
        {
            this.sourceList = sourceList;
            constantes = new ConstantesImageSource();
            cuerpo = new List<TrozoCuerpo>();
            if (sourceList.Count < MAX_COLUMNAS) {
                rellenarSourceListBlanco();
            }
            nacer();
        }

        private void rellenarSourceListBlanco() {
            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                sourceList.Add(new ObservableCollection<String>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    sourceList[i].Add(constantes.FONDO);
                }
            }
        }

        private TrozoCuerpo cabeza() {
            return cuerpo[0];
        }
        private TrozoCuerpo cola() {
            return cuerpo[cuerpo.Count - 1];
        }

        public void darPaso() {
            bool crece = false;
            if (vivo) {
                direccionActual = direccionNueva;
                switch (direccionActual)
                {
                    case Direccion.IZQUIERDA:
                        if (cabeza().x == 0 || (sourceList[cabeza().x - 1][cabeza().y] != constantes.FONDO && sourceList[cabeza().x - 1][cabeza().y] != constantes.COMIDA))
                        {
                            vivo = false;
                        }
                        else
                        {
                            if (sourceList[cabeza().x - 1][cabeza().y] == constantes.COMIDA)
                            {
                                puntuacion++;
                                crece = true;
                            }
                            cuerpo.Insert(0, new TrozoCuerpo(cabeza().x - 1, cabeza().y, Direccion.IZQUIERDA));
                            sourceList[cabeza().x][cabeza().y] = constantes.CABEZA_IZQ;
                            switch (cuerpo[2].direccion) {
                                case Direccion.IZQUIERDA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CUERPO_HOR;
                                    break;
                                case Direccion.ARRIBA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_IZQ_ABA;
                                    cuerpo[1].direccion = Direccion.IZQUIERDA;
                                    break;
                                case Direccion.ABAJO:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_IZQ_ARR;
                                    cuerpo[1].direccion = Direccion.IZQUIERDA;
                                    break;
                            }
                        }
                        break;
                    case Direccion.DERECHA:
                        if (cabeza().x == MAX_COLUMNAS-1 || (sourceList[cabeza().x + 1][cabeza().y] != constantes.FONDO && sourceList[cabeza().x + 1][cabeza().y] != constantes.COMIDA))
                        {
                            vivo = false;
                        }
                        else
                        {
                            if (sourceList[cabeza().x + 1][cabeza().y] == constantes.COMIDA)
                            {
                                puntuacion++;
                                crece = true;
                            }
                            cuerpo.Insert(0, new TrozoCuerpo(cabeza().x + 1, cabeza().y, Direccion.DERECHA));
                            sourceList[cabeza().x][cabeza().y] = constantes.CABEZA_DER;
                            switch (cuerpo[2].direccion)
                            {
                                case Direccion.DERECHA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CUERPO_HOR;
                                    break;
                                case Direccion.ARRIBA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_DER_ABA;
                                    cuerpo[1].direccion = Direccion.DERECHA;
                                    break;
                                case Direccion.ABAJO:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_ARR_DER;
                                    cuerpo[1].direccion = Direccion.DERECHA;
                                    break;
                            }
                        }
                        break;
                    case Direccion.ARRIBA:
                        if (cabeza().y == 0 || (sourceList[cabeza().x][cabeza().y-1] != constantes.FONDO && sourceList[cabeza().x][cabeza().y - 1] != constantes.COMIDA))
                        {
                            vivo = false;                            
                        }
                        else
                        {
                            if (sourceList[cabeza().x][cabeza().y - 1] == constantes.COMIDA)
                            {
                                puntuacion++;
                                crece = true;
                            }
                            cuerpo.Insert(0, new TrozoCuerpo(cabeza().x, cabeza().y - 1, Direccion.ARRIBA));
                            sourceList[cabeza().x][cabeza().y] = constantes.CABEZA_ARR;
                            switch (cuerpo[2].direccion)
                            {
                                case Direccion.ARRIBA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CUERPO_VER;
                                    break;
                                case Direccion.IZQUIERDA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_ARR_DER;
                                    cuerpo[1].direccion = Direccion.ARRIBA;
                                    break;
                                case Direccion.DERECHA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_IZQ_ARR;
                                    cuerpo[1].direccion = Direccion.ARRIBA;
                                    break;

                            }
                        }
                        break;
                    case Direccion.ABAJO:
                        if (cabeza().y == MAX_FILAS-1 || (sourceList[cabeza().x][cabeza().y + 1] != constantes.FONDO && sourceList[cabeza().x][cabeza().y + 1] != constantes.COMIDA))
                        {
                            vivo = false;
                        }
                        else
                        {                            
                            if (sourceList[cabeza().x][cabeza().y + 1] == constantes.COMIDA)
                            {
                                puntuacion++;
                                crece = true;
                            }
                            cuerpo.Insert(0, new TrozoCuerpo(cabeza().x, cabeza().y + 1, Direccion.ABAJO));
                            sourceList[cabeza().x][cabeza().y] = constantes.CABEZA_ABA;
                            switch (cuerpo[2].direccion)
                            {
                                case Direccion.ABAJO:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CUERPO_VER;
                                    break;
                                case Direccion.IZQUIERDA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_DER_ABA;
                                    cuerpo[1].direccion = Direccion.ABAJO;
                                    break;
                                case Direccion.DERECHA:
                                    sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CURVA_IZQ_ABA;
                                    cuerpo[1].direccion = Direccion.ABAJO;
                                    break;
                            }
                        }
                        break;
                }
                if (vivo) {
                    sourceList[cola().x][cola().y] = constantes.FONDO;
                    if (crece) {
                        generarComida();
                    }
                    else{
                        cuerpo.Remove(cola());
                        switch (cola().direccion)
                        {
                            case Direccion.ARRIBA:
                                sourceList[cola().x][cola().y] = constantes.CULO_ARR;
                                break;
                            case Direccion.ABAJO:
                                sourceList[cola().x][cola().y] = constantes.CULO_ABA;
                                break;
                            case Direccion.IZQUIERDA:
                                sourceList[cola().x][cola().y] = constantes.CULO_IZQ;
                                break;
                            case Direccion.DERECHA:
                                sourceList[cola().x][cola().y] = constantes.CULO_DER;
                                break;
                        }
                    }
                }
            }
        }

        
        private void nacer(){
            int x = MAX_COLUMNAS - 3;
            int y = 0;

            cuerpo.Add(new TrozoCuerpo(x, y, Direccion.IZQUIERDA));
            cuerpo.Add(new TrozoCuerpo(x + 1, y, Direccion.IZQUIERDA));
            cuerpo.Add(new TrozoCuerpo(x + 2, y, Direccion.IZQUIERDA));
            direccionActual = Direccion.IZQUIERDA;
            direccionNueva = direccionActual;
            sourceList[cuerpo[0].x][cuerpo[0].y] = constantes.CABEZA_IZQ;
            sourceList[cuerpo[1].x][cuerpo[1].y] = constantes.CUERPO_HOR;
            sourceList[cuerpo[2].x][cuerpo[2].y] = constantes.CULO_IZQ;
            vivo = true;
            generarComida();
        }

        public void girarArriba()
        {
            if (direccionActual != Direccion.ABAJO) {
                this.direccionNueva = Direccion.ARRIBA;
            }
        }

        public void girarAbajo() {
            if (direccionActual != Direccion.ARRIBA)
            {
                this.direccionNueva = Direccion.ABAJO;
            }
        }
        public void girarIzquierda()
        {
            if (direccionActual != Direccion.DERECHA)
            {
                this.direccionNueva = Direccion.IZQUIERDA;
            }
        }
        public void girarDerecha()
        {
            if (direccionActual != Direccion.IZQUIERDA)
            {
                this.direccionNueva = Direccion.DERECHA;
            }
        }

        private void generarComida() {
            Random random = new Random();
            int x;
            int y;

            do {
                x = random.Next(0, MAX_COLUMNAS);
                y = random.Next(0, MAX_FILAS);
            } while (sourceList[x][y] != constantes.FONDO);

            sourceList[x][y] = constantes.COMIDA;
        }

    }
}