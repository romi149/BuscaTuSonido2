using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GlobalEnv.GetInstance.InicializarNavegacion)
                GlobalEnv.GetInstance.BorrarCarrito(Response);

            if (Session["usuarioCliente"] == null)
            {
                this.IdNombreUsuario.Visible = false;
                this.LogOut.Visible = false;
                this.MisCompras.Visible = false;
                this.LogIn.Visible = true;
            }
            else
            {

                this.IdNombreUsuario.InnerText = $"{((BE.Usuario)Session["usuarioCliente"])?.Nombre} {((BE.Usuario)Session["usuarioCliente"])?.Apellido}";
                this.IdNombreUsuario.Visible = true;
                this.LogOut.Visible = true;
                this.MisCompras.Visible = true;
                this.LogIn.Visible = false;
            }
            GlobalEnv.GetInstance.InicializarNavegacion = false;
        }

        protected void LogOut_ServerClick(object sender, EventArgs e)
        {
            Session["usuarioCliente"] = null;
            Response.Redirect("PaginaPrincipal");

        }
    }
}