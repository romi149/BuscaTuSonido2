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

            id.Text = Request.QueryString["Id"].ToString();
            nombre.Text = Request.QueryString["Nombre"].ToString();
            descripcion.Text = Request.QueryString["Descripcion"].ToString();
            ubicacion.Text = Request.QueryString["Ubicacion"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            BE.Menu menu = new BE.Menu();
            menu.IdMenu = int.Parse(id.Text.Trim());
            menu.NombreMenu = nombre.Text.Trim();
            menu.Descripcion = descripcion.Text.Trim();
            menu.UbicacionMenu = ubicacion.Text.Trim();


            bool Modificado = GestorMenu.Modificar(menu);

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