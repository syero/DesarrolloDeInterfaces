
using SankeBL.Manejadoras;
using Snake.ClasesDeDatos;
using SnakeEntidades;
using SnakeUI.ViewModels;
using System;
using System.Collections.ObjectModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Snake.ViewModels
{
    public class JugarVM : clsVMBase
    {
        public Serpiente serpiente { get; set; }
        private ObservableCollection<ObservableCollection<String>> _sourceList;
        private DispatcherTimer timer;

        private int _puntuacion;
        private bool jugando;

        private const int MAX_COLUMNAS = 20;
        private const int MAX_FILAS = 11;
        private ConstantesImageSource constantes = new ConstantesImageSource();

        public JugarVM() {
            this.sourceList = new ObservableCollection<ObservableCollection<string>>();
            serpiente = new Serpiente(ref _sourceList);
            this.timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timer.Tick += timerTick;
            timer.Start();
            jugando = false;
            if (sourceList.Count < MAX_COLUMNAS)
            {
                rellenarSourceListBlanco();
            }
        }

        public ObservableCollection<ObservableCollection<String>> sourceList {
            get {
                return _sourceList;
            }
            set{
                this._sourceList = value;
            }
        }

        public int puntuacion {
            get {
                return this._puntuacion;
            }
            set {
                this._puntuacion = value;
                NotifyPropertyChanged("puntuacion");
            }
        }

        

        private void timerTick(Object sender, Object e) {
            if (jugando) {
                if (serpiente.vivo)
                {
                    serpiente.darPaso();
                    puntuacion = serpiente.puntuacion;
                }
                else
                {
                    jugando = false;
                    mostrarPopup();
                }
            }
        }

        public void teclaPulsada(object sender, KeyRoutedEventArgs e){
            VirtualKey tecla = e.Key;
            if (serpiente.vivo){
                jugando = true;
            }
            switch (tecla) {
                case VirtualKey.Up:
                    serpiente.girarArriba();
                    break;
                case VirtualKey.Down:
                    serpiente.girarAbajo();
                    break;
                case VirtualKey.Left:
                    serpiente.girarIzquierda();
                    break;
                case VirtualKey.Right:
                    serpiente.girarDerecha();
                    break;
            }
        }

        private async void mostrarPopup(){
            ContentDialog popup = new ContentDialog();
            ContentDialogResult resultado;
            StackPanel sp = new StackPanel();
            TextBlock texto = new TextBlock();
            TextBox edit = new TextBox();

            texto.Text = "Has conseguido " + serpiente.puntuacion + " puntos";

            edit.PlaceholderText = "Nombre";

            sp.Children.Add(texto);
            sp.Children.Add(edit);

            popup.Title = "¡Has perdido! :(";
            popup.Content = sp;
            popup.PrimaryButtonText = "Enviar";
            popup.PrimaryButtonClick += enviarPuntuacion;

            resultado = await popup.ShowAsync();
        }

        private async void enviarPuntuacion(ContentDialog sender, ContentDialogButtonClickEventArgs e){
            StackPanel sp = (StackPanel)sender.Content;
            TextBox edit = (TextBox)sp.Children[1];
            String nombre = edit.Text;

            if (String.IsNullOrEmpty(nombre))
            {
                nombre = "Anónimo";
            }

            //Enviar puntación al server
            PuntuacionManejadoraBL puntuacionManejadora = new PuntuacionManejadoraBL();
            Puntuacion puntuacion = new Puntuacion(nombre, serpiente.puntuacion);
            if(serpiente.puntuacion > 0)
            {
                await puntuacionManejadora.crearPuntuacionBL(puntuacion);
            }
            
            reiniciarJuego();
        }

        private void reiniciarJuego() {
            Page page = (Page)((Frame)Window.Current.Content).Content;
            Frame contentFrame = (Frame)page.FindName("ContentFrame");
            contentFrame.Navigate(typeof(Jugar));
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
    }
}
