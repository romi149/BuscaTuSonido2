using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            bool Insertado = GestorProducto.Agregar(
                                       upc.Text.Trim(),
                                       nombre.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       categoria.Text.Trim(),
                                       tipoInstrumento.Text.Trim(),
                                       int.Parse(idMarca.Text.Trim()),
                                       modelo.Text.Trim(),
                                       codProv.Text.Trim(),
                                       int.Parse(idProv.Text.Trim()),
                                       color.Text.Trim(),
                                       estado.Text.Trim(),
                                       precio.Text.Trim()
                                        ) ;

            if (Insertado)
            {
                Response.Write("<script>alert('El producto se ha agregado correctamente')</script>");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Productos");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Productos");
        }
    }
}