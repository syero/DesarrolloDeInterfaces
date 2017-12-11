using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_HelloWorld_WebForms_ASP
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo para Hola mundo y se validan los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellidos = this.txtApellidos.Text;
            string error_name = this.lblErrorNombre.Text;
            string error_apellidos = this.lblErrorApellidos.Text;
            string all_ok = this.allOk.Text;


            if (String.IsNullOrWhiteSpace(nombre) || (String.IsNullOrWhiteSpace(apellidos)))
            {
                if (String.IsNullOrWhiteSpace(nombre))
                {
                    error_name = "No se puede dejar este campo vacío";
                    lblErrorNombre.Text = error_name;
                    allOk.Text = "";
                }
                else
                {
                    error_name = "";
                    lblErrorNombre.Text = error_name;
                    allOk.Text = "";
                }

                if (String.IsNullOrWhiteSpace(apellidos))
                {
                    error_apellidos = "No se puede dejar este campo vacío";
                    lblErrorApellidos.Text = error_apellidos;
                    allOk.Text = "";
                }

                else
                {
                    error_apellidos = "";
                    lblErrorApellidos.Text = error_apellidos;
                    allOk.Text = "";
                }

            }
            else
            {
                lblErrorNombre.Text = "";
                lblErrorApellidos.Text = "";
                all_ok = "Todos los campos han sido introducidos correctamente";
                allOk.Text = all_ok;
            }


        }
    }
}