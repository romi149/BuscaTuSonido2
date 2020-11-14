using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EditarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string IdMarca = Request.QueryString["IdMarca"].ToString();
            string Nombre = Request.QueryString["Nombre"].ToString();
            string Descripcion = Request.QueryString["Descripcion"].ToString();
            
            Id.Text = IdMarca;
            nombre.Text = Nombre;
            descripcion.Text = Descripcion;
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorMarca.Modificar(
                                       int.Parse(Id.Text.Trim()),
                                       nombre.Text.Trim(),
                                       descripcion.Text.Trim());

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "Admin", "Marca");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Marcas");
        }
    }
}