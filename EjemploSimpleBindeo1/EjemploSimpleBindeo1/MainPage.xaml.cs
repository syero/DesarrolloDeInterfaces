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

namespace EjemploSimpleBindeo1
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
        /*
                private void textNumero_TextChanged(object sender, TextChangedEventArgs e)
                {
                    //.Text = Server.HtmlEncode(TextBox1.Text);
                }
        */

        private void textNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), pattern: "[0-9]"))
            {
                e.Handled = true;

            }
            else { e.Handled = false; }
        }
    }
}
/*
 *   private void textNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
   if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            {
                textBox1.Text = "";
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
    {
        e.Handled = true;
    }
}
*/
