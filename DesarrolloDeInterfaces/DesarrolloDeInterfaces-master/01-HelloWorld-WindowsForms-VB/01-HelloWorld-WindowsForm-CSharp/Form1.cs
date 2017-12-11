using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_HelloWorld_WindowsForm_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento producido por un click al botón dedicado a imprimir un saludo en pantalla. Teniendo en cuenta si el TextBox está vacío o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaludar_Click(object sender, EventArgs e)
        {
            String nombre = "";

            nombre = this.txtIngresar.Text;

            if (String.IsNullOrWhiteSpace (nombre))
            {
                MessageBox.Show("Tienes que introducir un nombre para poder ser saludado.", "Error 404 Hello World! Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                MessageBox.Show($"Hola {nombre}, makina.", "Jelou güorl"); //Utilizar este método con el $ siempre.
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
