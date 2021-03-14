using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ABMC_Noticias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Noticias.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            if (!IsPostBack)
            {
                var listaDatos = CargarDatos();
                this.gvNoticias.DataSource = listaDatos;
                this.gvNoticias.DataBind();
                
            }
        }

        public DataSet CargarDatos()
        {
            return GestorNewsletter.ListarNoticias();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorNewsletter.Eliminar(int.Parse(Id));

            Response.Redirect("/ABMC-Noticias.aspx");

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string Titulo1 = row.Cells[1].Text.Trim();
            string Texto1 = row.Cells[2].Text.Trim();
            string Titulo2 = row.Cells[3].Text.Trim();
            string Texto2 = row.Cells[4].Text.Trim();
            string AltoImg = row.Cells[6].Text.Trim();
            string AnchoImg = row.Cells[7].Text.Trim();
            string FechaPub = row.Cells[8].Text.Trim();
            string FechaFin = row.Cells[8].Text.Trim();
            
            Response.Redirect($"/EditarNoticia.aspx?Id={Id}&Titulo1={Titulo1}&Texto1={Texto1}" +
                $"&Titulo2={Titulo2}&Texto2={Texto2}&AltoImg={AltoImg}&AnchoImg={AnchoImg}&" +
                $"FechaPub={FechaPub}&FechaFin={FechaFin}");
        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            var Titulo1 = titulo1.Text.Trim();
            var Texto1 = texto1.Text.Trim();
            var Titulo2 = titulo2.Text.Trim();
            var Texto2 = texto2.Text.Trim();
            var FechaPub = fechaPub.Text.Trim();
            var FechaFin = fechaFin.Text.Trim();
            var AltoImg = altoImg.Text.Trim();
            var AnchoImg = anchoImg.Text.Trim();
            
            bool Insertado = GestorNewsletter.Agregar(
                                       Titulo1,
                                       Texto1,
                                       Titulo2,
                                       Texto2,
                                       int.Parse(AltoImg),
                                       int.Parse(AnchoImg),
                                       FechaPub,
                                       FechaFin);

            Response.Redirect("~/ABMC-Noticias");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Noticias");
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var NombreImg = nombreImg.Text.Trim();
            string ruta;

            if (string.IsNullOrEmpty(NombreImg))
            {
                Response.Write("<script>alert('Debe completar el nombre de la imagen')</script>");
            }
            else
            {
                ruta = @"/Imagenes/Catalogo/"+ NombreImg;
                FileUpload.SaveAs(Server.MapPath(".") + ruta);
                //GestorNewsletter.AgregarImg(ruta);
                
            }

        }
    }
}