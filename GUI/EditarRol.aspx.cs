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

            string IdRol = Request.QueryString["IdRol"].ToString();
            string Nombre = Request.QueryString["Nombre"].ToString();
            string Descripcion = Request.QueryString["Descripcion"].ToString();
            string TipoRol = Request.QueryString["TipoRol"].ToString();
            
            Id.Text = IdRol;
            nombre.Text = Nombre;
            descripcion.Text = Descripcion;
            tipoRol.Text = TipoRol;
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorRol.Modificar(
                                       int.Parse(Id.Text.Trim()),
                                       nombre.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       tipoRol.Text.Trim());

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