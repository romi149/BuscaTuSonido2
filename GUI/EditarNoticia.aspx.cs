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
    public partial class EditarNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            id.Text = Request.QueryString["Id"].ToString();
            titulo1.Text = Request.QueryString["Titulo1"].ToString();
            texto1.Text = Request.QueryString["Texto1"].ToString();
            titulo2.Text = Request.QueryString["Titulo2"].ToString();
            fechaPub.Text = Request.QueryString["FechaPub"].ToString();
            fechaFin.Text = Request.QueryString["FechaFin"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Newsletter news = new Newsletter();
            news.Id = int.Parse(id.Text.Trim());
            news.Titulo1 = titulo1.Text.Trim();
            news.Texto1 = texto1.Text.Trim();
            news.Titulo2 = titulo2.Text.Trim();
            news.FechaPub = DateTime.Parse(fechaPub.Text.Trim());
            news.FechaFin = DateTime.Parse(fechaFin.Text.Trim());

            bool Modificado = GestorNewsletter.ModificarNoticia(news);

            if (Modificado)
            {
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Noticias");
        }
    }
}