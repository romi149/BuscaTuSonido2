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

            BE.Usuario usuario = null;
            usuario = GestorUsuario.ObtenerUsuario(username.Text.Trim(), pass);
            if (usuario != null)
            {
                var esCliente = GestorCliente.ValidadRolCliente(username.Text.Trim());
                
                if (esCliente != null)
                {
                    Session["usuarioCliente"] = usuario;
                    Response.Redirect("/PaginaPrincipal");
                }
                else
                {
                    Session["usuarioBackEnd"] = usuario;
                    Response.Redirect("/InicioBackend");
                }
                
            }else
            {
                Response.Write("<script>alert('Credenciales incorrectas')</script>");
            }

        }

        protected void sendvolver_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.close()</script>");
            Response.Redirect("/PaginaPrincipal");
        }

        protected void sendemail_Click(object sender, EventArgs e)
        {
            var Email = email.Text.Trim();

            if (!string.IsNullOrEmpty(Email))
            {
                var Existe = GestorCliente.ValidadMailCliente(Email);

                if(Existe != null)
                {
                    if (GestorUsuario.ObtenerHash(usuario.Text.Trim()))
                    {
                        EnvioEmails.EnviarMailRecuperoPass(Email,
                                                $"https://localhost:44328/RecuperoPass.aspx?clave={usuario.Text.Trim()}&hash={GestorUsuario.RecuperarHashUsuario(usuario.Text.Trim())}");
                        Response.Write("<script>alert('Se ha enviado un correo electronico a su casilla de email para que pueda recuperar su contraseña')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Ha ocurrido un error, vuelva a intentarlo')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('El email ingresado no se encuentra registrado')</script>");
                    
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