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

namespace EjemploFormularioGrid
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

        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            //nombre
            TextBox txtBoxNombre = (TextBox)txbx_Nombre;
            TextBlock txtBlockNombre = (TextBlock)txbl_textoNombre;


            //apellidos
            TextBox txtBoxApellidos = (TextBox)txbx_Apellidos;
            TextBlock txtBlockApellidos = (TextBlock)txbl_textoApellidos;


            //fecha
            TextBox txtBoxFecha = (TextBox)txbx_Fecha; //este textBox vincula el TextBox del xaml con mi textBox txtBoxFecha
            String valortxtBFecha = txtBoxFecha.Text;  //asignamos el valor del textBox a un String que sera el que pasaremos para validar la fecha
            TextBlock txtBlockFecha = (TextBlock)txbl_textoFecha; //este es el textBlock que va a mostrar un mensaje si la fecha no es valida

            //Variable que almacena el valor que devuelve el metodo que valida la fecha
            bool fechaCorrecta;

            //variables donde voy a almacenar el resultado final
            TextBlock mostrarNombre =(TextBlock)txbl_mostrarNombre;
            TextBlock mostrarApellidos =(TextBlock)txbl_mostrarApellidos;
            TextBlock mostraFecha = (TextBlock)txbl_mostrarFecha;


            //llamada al metodo ValidarFecha
            fechaCorrecta = FechaValida(valortxtBFecha);

            if (String.IsNullOrEmpty(txtBoxNombre.Text)==true)
            {
                txtBlockNombre.Text = "Rellene el nombre ";
            }else {
                   mostrarNombre.Text = txtBoxNombre.Text;
            }

            if (String.IsNullOrEmpty(txtBoxApellidos.Text)==true)
            {
                txtBlockApellidos.Text = "Rellene los apellidos";
            }else {
                    mostrarApellidos.Text = txtBoxApellidos.Text;
            }

             if(fechaCorrecta==false) //if (Boolean.TryParse(valortxtBFecha, out fechaCorrecta) == false)
                {
                    txtBlockFecha.Text = "la fecha no es valida";
            }else
            {            
                mostraFecha.Text = txtBoxFecha.Text;
            }
        }


        /* Este metodo me sirve para saber si una fecha es Valida o no  */
        
                private bool FechaValida(String fechaString)
                       {
                         bool fechaValida;
                            try
                            {
                                DateTime dt = DateTime.Parse(fechaString);
                                fechaValida= true;
                            }
                            catch
                            {
                                fechaValida = false;
                    }
                    return (fechaValida);
                }

        /** para validar si el formulario tiene campos vacios
                public bool ValidaTextBoxVacios(Form formulario)
                {
                     bool camposVacios;

                    foreach (Control control in formulario.Controls)
                    {

                        if (control.GetType().Equals(typeof(TextBox)))
                        {

                            if (control.Text.Equals(""))
                            {

                                camposVacios=false;
                            }
                        }
                    }

                    camposVacios=true;
                    return camposVacios;


                }
            */

    }
}
