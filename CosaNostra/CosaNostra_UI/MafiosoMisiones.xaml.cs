using CosaNostra_Entidades;
using CosaNostra_UI.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CosaNostra_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MafiosoMisiones : Page
    {
        public ViewModelMafiosoMisiones viewModel{get;set;}
       
        public MafiosoMisiones()
        {           
            this.InitializeComponent();
            viewModel = (ViewModelMafiosoMisiones)this.DataContext;
        }

        /// <summary>
        /// Este metodo me sirve para obtener el mafioso que se ha logueado en el viewModel del login
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                viewModel.Mafioso = (Mafioso)e.Parameter;
            }
        }

        private void btn_Reservar_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            btn_Reservar.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            btn_Reservar.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 145, 8, 8));
        }

        private void btn_Reservar_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            btn_Reservar.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 145, 8, 8));
            btn_Reservar.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
        }


        private void btn_Completar_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            btn_Completar.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            btn_Completar.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 145, 8, 8));
        }

        private void btn_Completar_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            btn_Completar.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 145, 8, 8));
            btn_Completar.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
        }
        
    }
}
