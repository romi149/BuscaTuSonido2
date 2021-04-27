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
    public partial class EditarEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            id.Text = Request.QueryString["Id"].ToString();
            nombrePregunta.Text = GestorOpinion.ObtenerPregunta(int.Parse(id.Text));
            var listaDatos = GestorOpinion.ObtenerFechaInicio(int.Parse(id.Text));
            fechaInicio.Text = listaDatos[0].fechaIni.ToString();
            fechaFin.Text = listaDatos[0].fechaFin.ToString();
            respuesta1.Text = Request.QueryString["Opcion1"].ToString();
            respuesta2.Text = Request.QueryString["Opcion2"].ToString();
            img1.Text = Request.QueryString["NombreImg1"].ToString();
            img2.Text = Request.QueryString["NombreImg2"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Opinion op = new Opinion();
            op.Id = int.Parse(id.Text.Trim());
            op.NombrePregunta = nombrePregunta.Text.Trim();
            op.FechaInicio = fechaInicio.Text.Trim();
            op.FechaFin = fechaFin.Text.Trim();
            op.Opcion1 = respuesta1.Text.Trim();
            op.Opcion2 = respuesta2.Text.Trim();
            op.UrlOpcion1 = img1.Text.Trim();
            op.UrlOpcion2 = img2.Text.Trim();


            bool Modificado = GestorOpinion.ModificarEncuesta(op);

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