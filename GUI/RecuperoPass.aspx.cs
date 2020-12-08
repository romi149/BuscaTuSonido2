using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class NuevoRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendconfirmar_Click(object sender, EventArgs e)
        {
            var pass1 = password.Text.Trim();
            var pass2 = repetpass.Text.Trim();

            if(pass1 == pass2)
            {
                var password = EnvioEmails.md5(pass1);
                var usuario = Request.QueryString["clave"];
                var hash = Request.QueryString["hash"];
                var email = GestorCliente.ObtenerEmailCliente(usuario);

                bool Modificado = GestorUsuario.ConfirmacionCambioPassword(usuario, hash, password);

                if(Modificado)
                {
                    EnvioEmails.EnviarMailConfirmacionCambioPass(email.Email,"");
                    Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('La contraseña no coincide')</script>");
            }

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PaginaPrincipal.aspx");
        }
    }
}