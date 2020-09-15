using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendregistrarse_Click(object sender, EventArgs e)
        {
            //GestorCliente gestor = new GestorCliente();
            bool Insertado = GestorCliente.Agregar(
                                       nombre.Text.Trim(),
                                       apellido.Text.Trim(),
                                       email.Text.Trim(),
                                       telefono.Text.Trim(),
                                       domEntrega.Text.Trim(),
                                       domFactura.Text.Trim(),
                                       password.Text.Trim(),
                                       int.Parse(dni.Text.Trim()));
            if (Insertado)
            {
               EnvioEmails.EnviarMail("romi.caste@gmail.com",
                                    "Mail de Confirmacion",
                                    $"<h1>Codigo de Seguridad</h1>" +
                                    $"<p>{EnvioEmails.md5(this.password.Text.Trim())}</p>");
            }
        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}