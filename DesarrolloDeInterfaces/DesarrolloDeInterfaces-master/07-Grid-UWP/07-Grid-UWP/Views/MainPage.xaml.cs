using _07_Grid_UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _07_Grid_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            TextBox txtBox1 = (TextBox) this.txtBox1;
            TextBox txtBox2 = (TextBox) this.txtBox2;
            TextBox txtBox3 = (TextBox) this.txtBox3;
            TextBlock txtBlock1 = (TextBlock) this.txtBlock1;
            TextBlock txtBlock2 = (TextBlock)this.txtBlock2;
            TextBlock txtBlock3 = (TextBlock)this.txtBlock3;

            clsPersona persona = new clsPersona();
            persona = (clsPersona) this.DataContext;

            if (String.IsNullOrWhiteSpace(txtBox1.Text))
            {
                txtBlock1.Text = ("El nombre no puede estar vacío");
                
            }

            else
            {
                txtBlock1.Text = "";
            }

            if (String.IsNullOrWhiteSpace(txtBox2.Text))
            {
                txtBlock2.Text = ("Los apellidos no pueden estar vacío");

            }

            else
            {
                txtBlock2.Text = "";
            }

            if (String.IsNullOrWhiteSpace(txtBox3.Text) || !validarFecha (txtBox3.Text))
            {
                txtBlock3.Text = ("Introducir fecha válida");

            }

            else
            {
                txtBlock3.Text = "";
            }

        }

        /// <summary>
        /// Resumen: Metodo dedicado a validar una fecha
        /// Entradas: Un String
        /// Salidas: Un boolean
        /// Postcondiciones: True si la fecha es válida, false sino.
        /// Formato MM/DD/YY
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>

        private bool validarFecha (string fecha)
        {
            bool resultado = true;
            DateTime testDate;

            try
            {
                string[] dateParts = fecha.Split('/');

                    testDate = new
                    DateTime(Convert.ToInt32(dateParts[2]),
                    Convert.ToInt32(dateParts[0]),
                    Convert.ToInt32(dateParts[1]));
            }
            catch
            {
                resultado = false;
            }

            return resultado;
        }
    }
}
