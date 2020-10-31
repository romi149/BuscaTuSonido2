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
            //Response.Write("<script>window.close()</script>");
            Response.Redirect("~/");
        }

        protected void sendemail_Click(object sender, EventArgs e)
        {
            var Email = email.Text.Trim();

            if (!string.IsNullOrEmpty(Email))
            {
                var Existe = GestorCliente.ValidadMailCliente(Email);

                if(Existe != null)
                {
                    EnvioEmails.EnviarMailRecuperoPass(Email,"");
                    Response.Write("<script>alert('Se ha enviado un correo electronico a su casilla de email para que pueda recuperar su contraseña')</script>");
                    Email = "";
                }
                else
                {
                    Response.Write("<script>alert('El email ingresado no se encuentra registrado')</script>");
                    Email = "";
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar un email')</script>");
            }

        }


        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close()</script>");
            //Response.Redirect("~/");
        }
    }
    
}