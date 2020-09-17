using BLL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            bool Insertado = GestorUsuario.Agregar(
                                       username.Text.Trim(),
                                       nombre.Text.Trim(),
                                       apellido.Text.Trim(),
                                       EnvioEmails.md5(password.Text.Trim()),
                                       "Activo",
                                       1,
                                       int.Parse(dni.Text.Trim()));

            if(Insertado)
            {
                Response.Write("alert('El usuario se ha agregado correctamente')");
                //Response.Redirect("/ABMC-Usuarios");
            }
 
            Response.Redirect("~/ABMC-Usuarios");
    
        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Usuarios");
        }
    }
}