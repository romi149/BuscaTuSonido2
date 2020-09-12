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
            GestorUsuario.ObtenerUsuario(username.Text.Trim(), password.Text.Trim());
           
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }

        protected void registrarse_Click(object sender, EventArgs e)
        {
            //bool Insertado = mapper.InsertarUsuario(new DAL.Usuario
            //{
            //    Nombre = this.Nombre.Text.Trim(),
            //    Apellido = this.Apellido.Text.Trim(),
            //    Dni = int.Parse(this.dni.Text.Trim()),
            //    Pass = this.Password.Text.Trim(),
            //    Usuario1 = this.Usuario.Text.Trim()
            //});
            //if (Insertado)
            //{
            //    Helpers.EnviarMail("romi.caste@gmail.com",
            //                        "Mail de Confirmacion",
            //                        $"<h1>Codigo de Seguridad</h1>" +
            //                        $"<p>{Helpers.md5(this.Password.Text.Trim())}</p>");
            //}
        }

        
    }
    
}