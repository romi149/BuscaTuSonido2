using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Backend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioBackEnd"] == null)
            {
                Response.Redirect("PaginaPrincipal.aspx");
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session["usuarioBackEnd"] = null;
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void search_Click(object sender, EventArgs e)
        {

            var dato = search.Text.Trim();
            var listaDatos = GestorBusqueda.ListarPaginasBack(dato);

            if(listaDatos.Count != 0)
            {
                var url = listaDatos[0].UrlPagina;

                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("InicioBackend.aspx");
            }

        }
    }
}