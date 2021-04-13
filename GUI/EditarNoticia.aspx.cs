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

            string Id = Request.QueryString["Id"].ToString();
            string Titulo1 = Request.QueryString["Titulo1"].ToString();
            string Texto1 = Request.QueryString["Texto1"].ToString();
            string Titulo2 = Request.QueryString["Titulo2"].ToString();
            string Texto2 = Request.QueryString["Texto2"].ToString();
            string AltoImg = Request.QueryString["AltoImg"].ToString();
            string AnchoImg = Request.QueryString["AnchoImg"].ToString();
            string FechaPub = Request.QueryString["FechaPub"].ToString();
            string FechaFin = Request.QueryString["FechaFin"].ToString();

            id.Text = Id;
            titulo1.Text = Titulo1;
            texto1.Text = Texto1;
            titulo2.Text = Titulo2;
            texto2.Text = Texto2;
            altoImg.Text = AltoImg;
            anchoImg.Text = AnchoImg;
            fechaPub.Text = FechaPub;
            fechaFin.Text = FechaFin;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorNewsletter.ModificarNoticia(
                                       int.Parse(id.Text.Trim()),
                                       titulo1.Text.Trim(),
                                       texto1.Text.Trim(),
                                       titulo2.Text.Trim(),
                                       texto2.Text.Trim(),
                                       int.Parse(altoImg.Text.Trim()),
                                       int.Parse(anchoImg.Text.Trim()),
                                       fechaPub.Text.Trim(),
                                       fechaFin.Text.Trim());

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