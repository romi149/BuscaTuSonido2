using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EditarEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string Id = Request.QueryString["Id"].ToString();
            string NombrePregunta = Request.QueryString["NombrePregunta"].ToString();
            string FechaInicio = Request.QueryString["FechaInicio"].ToString();
            string FechaFin = Request.QueryString["FechaFin"].ToString();
            string Opcion1 = Request.QueryString["Opcion1"].ToString();
            string Opcion2 = Request.QueryString["Opcion2"].ToString();
            string NombreImg1 = Request.QueryString["NombreImg1"].ToString();
            string NombreImg2 = Request.QueryString["NombreImg2"].ToString();

            id.Text = Id;
            nombrePregunta.Text = NombrePregunta;
            fechaInicio.Text = FechaInicio;
            fechaFin.Text = FechaFin;
            respuesta1.Text = Opcion1;
            respuesta2.Text = Opcion2;
            img1.Text = NombreImg1;
            img2.Text = NombreImg2;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorOpinion.ModificarEncuesta(
                                       int.Parse(id.Text.Trim()),
                                       nombrePregunta.Text.Trim(),
                                       fechaInicio.Text.Trim(),
                                       fechaFin.Text.Trim(),
                                       respuesta1.Text.Trim(),
                                       respuesta2.Text.Trim(),
                                       img1.Text.Trim(),
                                       img2.Text.Trim());

            if (Modificado)
            {
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Encuestas");
        }
    }
}