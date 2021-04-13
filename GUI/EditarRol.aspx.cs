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
    public partial class EditarRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            
            Id.Text = Request.QueryString["IdRol"].ToString();
            nombre.Text = Request.QueryString["Nombre"].ToString();
            descripcion.Text = Request.QueryString["Descripcion"].ToString();
            tipoRol.Text = Request.QueryString["TipoRol"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Rol oRol = new Rol();
            oRol.IdRol = int.Parse(Id.Text.Trim());
            oRol.NombreRol = nombre.Text.Trim();
            oRol.Descripcion = descripcion.Text.Trim();
            oRol.TipoRol = tipoRol.Text.Trim();

            bool Modificado = GestorRol.Modificar(oRol);

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un rol", "Admin", "Rol");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Rol");
        }
    }
}