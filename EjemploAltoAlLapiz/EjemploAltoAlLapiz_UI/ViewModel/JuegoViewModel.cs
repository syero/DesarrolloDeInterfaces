using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace EjemploAltoAlLapiz_UI.ViewModel
{
    public class JuegoViewModel : Base
    {       
        private String _letra;
        private ObservableCollection<String> _categoriasSeleccionadas;

        public JuegoViewModel() { }

       

        public String Letra
        {
            get { return _letra; }
            set { _letra = value; NotifyPropertyChanged("Letra"); }
        }


        public ObservableCollection<String> CategoriasSeleccionadas
        {
            get { return _categoriasSeleccionadas; }
            set { _categoriasSeleccionadas = value; NotifyPropertyChanged("CategoriasSeleccionadas"); }
        }


        /// <summary>
        /// Este metodo me da una letra del alfabeto de forma aleatoria
        /// </summary>
        /// <returns></returns>
        public void letraRandom()
        {
            String[] alfabeto = {"A","B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random rnd = new Random();
            int indexAleatorio = rnd.Next(0, alfabeto.Length);
            _letra= alfabeto[indexAleatorio];
        } 



    }
}
