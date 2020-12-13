using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EditarPermiso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string IdPermiso = Request.QueryString["IdPermiso"].ToString();
            string Nombre = Request.QueryString["Nombre"].ToString();
            string Descripcion = Request.QueryString["Descripcion"].ToString();
            string TipoPermiso = Request.QueryString["TipoPermiso"].ToString();

            Id.Text = IdPermiso;
            nombre.Text = Nombre;
            descripcion.Text = Descripcion;
            tipoPermiso.Text = TipoPermiso;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorPermiso.Modificar(
                                       int.Parse(Id.Text.Trim()),
                                       nombre.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       tipoPermiso.Text.Trim());

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un permiso", "Admin", "Permiso");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;

            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Permiso");
        }
    }
}