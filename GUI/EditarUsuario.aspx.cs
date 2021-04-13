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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Id.Text = Request.QueryString["IdUsuario"].ToString();
            username.Text = Request.QueryString["Usuario"].ToString();
            nombre.Text = Request.QueryString["Nombre"].ToString();
            apellido.Text = Request.QueryString["Apellido"].ToString();
            password.Text = Request.QueryString["Password"].ToString();
            dni.Text = Request.QueryString["Dni"].ToString();
            estado.Text = Request.QueryString["Estado"].ToString();
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.IdUsuario = int.Parse(Id.Text.Trim());
            user.User = username.Text.Trim();
            user.Nombre = nombre.Text.Trim();
            user.Apellido = apellido.Text.Trim();
            user.Pass = EnvioEmails.md5(password.Text.Trim());
            user.Estado = estado.Text.Trim();
            user.IdIdioma = 1;
            user.Dni = int.Parse(dni.Text.Trim());

            bool Modificado = GestorUsuario.ModificarUsuario(user);

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "Admin", "Usuario");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

            protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Usuarios");
        }
    }
}