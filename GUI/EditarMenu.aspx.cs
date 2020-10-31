using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EditarMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string Id = Request.QueryString["Id"].ToString();
            string Nombre = Request.QueryString["Nombre"].ToString();
            string Descripcion = Request.QueryString["Descripcion"].ToString();
            string Ubicacion = Request.QueryString["Ubicacion"].ToString();
            
            id.Text = Id;
            nombre.Text = Nombre;
            descripcion.Text = Descripcion;
            ubicacion.Text = Ubicacion;
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorMenu.Modificar(
                                       int.Parse(id.Text.Trim()),
                                       nombre.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       ubicacion.Text.Trim());

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "Admin", "Menu");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Menus");
        }
    }
}