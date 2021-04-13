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

            Id.Text = Request.QueryString["IdMarca"].ToString();
            nombre.Text = Request.QueryString["Nombre"].ToString();
            descripcion.Text = Request.QueryString["Descripcion"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            BE.Marca marca = new BE.Marca();
            marca.IdMarca = int.Parse(Id.Text.Trim());
            marca.Nombre = nombre.Text.Trim();
            marca.Descripcion = descripcion.Text.Trim();

            bool Modificado = GestorMarca.Modificar(marca);

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