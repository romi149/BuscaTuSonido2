using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendlogin_Click(object sender, EventArgs e)
        {
            var pass = EnvioEmails.md5(password.Text.Trim());
            
            if (GestorUsuario.ObtenerUsuario(username.Text.Trim(), pass) != null)
            {
                var esCliente = GestorCliente.ValidadRolCliente(username.Text.Trim());
                
                if (esCliente != null)
                {
                    Response.Write("<script>alert('Bienvenido')</script>");
                }else
                {
                    Response.Redirect("/InicioBackend");
                }
                
            }else
            {
                Response.Write("alert('Credenciales incorrectas')");
            }

        }

        protected void sendvolver_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close()</script>");
        }
    }
    
}