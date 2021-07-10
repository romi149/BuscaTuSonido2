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
    public partial class EditarPermiso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Id.Text = Request.QueryString["IdPermiso"].ToString();
            nombre.Text = Request.QueryString["Nombre"].ToString();
            descripcion.Text = Request.QueryString["Descripcion"].ToString();
            tipoPermiso.Text = Request.QueryString["TipoPermiso"].ToString();

        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Permiso per = new Permiso();
            per.IdPermiso = int.Parse(Id.Text.Trim());
            per.NombrePermiso = nombre.Text.Trim();
            per.Descripcion = descripcion.Text.Trim();
            per.TipoPermiso = tipoPermiso.Text.Trim();

            bool Modificado = GestorPermiso.Modificar(per);

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