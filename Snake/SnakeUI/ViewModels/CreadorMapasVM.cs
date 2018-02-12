using SankeBL.Manejadoras;
using Snake.ClasesDeDatos;
using SnakeEntidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SnakeUI.ViewModels
{
    public class CreadorMapasVM : clsVMBase
    {
        private ObservableCollection<ObservableCollection<String>> _sourceList;
        private const int MAX_COLUMNAS = 20;
        private const int MAX_FILAS = 11;
        private ConstantesImageSource constantes;
        private String _nombreMapa;
        private String _nombreAutor;
        public String nombreMapa{
            get {
                return _nombreMapa;
            } set {
                _nombreMapa = value;
            }
        }

        public String nombreAutor{
            get{
                return _nombreAutor;
            } set{
                _nombreAutor = value;
            }
        }

        public CreadorMapasVM()
        {
            this.sourceList = new ObservableCollection<ObservableCollection<string>>();
            constantes = new ConstantesImageSource();
            rellenarSourceListBlanco();
        }

        public ObservableCollection<ObservableCollection<String>> sourceList
        {
            get
            {
                return _sourceList;
            }
            set
            {
                this._sourceList = value;
            }
        }

        private void rellenarSourceListBlanco()
        {
            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                sourceList.Add(new ObservableCollection<String>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    sourceList[i].Add(constantes.FONDO);
                }
            }
        }

        public void cambiarEstado(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Image img =(Image)btn.Content;

            String[] name = img.Name.Split("_");

            int i = Int32.Parse(name[1]);
            int j = Int32.Parse(name[2]);

            if(sourceList[i][j] == constantes.MURO)
            {
                sourceList[i][j] = constantes.FONDO;
            }
            else if(sourceList[i][j] == constantes.FONDO)
            {
                sourceList[i][j] = constantes.MURO;
            }   
        }

        public async void publicar()
        {

            ObservableCollection<ObservableCollection<bool>> mapaTraducido = traducirMapa();
            Mapa mapaEnviar = new Mapa(nombreMapa, nombreAutor, mapaTraducido, 0);
            MapaManejadoraBL manejadoraBL = new MapaManejadoraBL();
            int i = 1;
            if (String.IsNullOrWhiteSpace(nombreMapa))
            {
                nombreMapa = "Mapa sin nombre";
            }
            if (String.IsNullOrWhiteSpace(nombreAutor))
            {
                nombreAutor = "Anónimo";
            }
            await manejadoraBL.crearMapaBL(mapaEnviar);

        }

        private ObservableCollection<ObservableCollection<bool>> traducirMapa()
        {
            ObservableCollection<ObservableCollection<bool>> mapaBooleano = new ObservableCollection<ObservableCollection<bool>>();

            for (int i = 0; i < MAX_COLUMNAS; i++)
            {
                mapaBooleano.Add(new ObservableCollection<bool>());
                for (int j = 0; j < MAX_FILAS; j++)
                {
                    if(sourceList[i][j] == constantes.MURO)
                    {
                        mapaBooleano[i].Add(true);
                    }
                    else
                    {
                        mapaBooleano[i].Add(false);
                    }
                }
            }


            return mapaBooleano;
        }

    }
}
