using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02_HelloWorld_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento dedicado a saludar por pantalla al texto introducido en el TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaludo_Click(object sender, RoutedEventArgs e)
        {
            String nombre = "";

            nombre = this.txtNombre.Text;

            if (String.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show ("OH NO YOU FUCKED UP", "FATAL ERROR SYSTEM WILL CRASH.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                MessageBox.Show ($"Hola {nombre}, makina.", "Hello World");
            }
        }
    }
}
