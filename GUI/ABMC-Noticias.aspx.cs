using BE;
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
            string FechaPub = row.Cells[4].Text.Trim();
            string FechaFin = row.Cells[5].Text.Trim();
            
            Server.Transfer($"/EditarNoticia.aspx?Id={Id}&Titulo1={Titulo1}&Texto1={Texto1}&" +
                $"Titulo2={Titulo2}&FechaPub={FechaPub}&FechaFin={FechaFin}");

        }


        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            Newsletter news = new Newsletter();
            news.Titulo1 = titulo1.Text.Trim();
            news.Texto1 = texto1.Text.Trim();
            news.Titulo2 = titulo2.Text.Trim();
            news.FechaPub = DateTime.Parse(fechaPub.Text.Trim());
            news.FechaFin = DateTime.Parse(fechaFin.Text.Trim());
            news.Img = nombreImg.Text.Trim();

            bool Insertado = GestorNewsletter.Agregar(news);

            if (Insertado)
            {
                //var ruta = @"/Imagenes/Catalogo/" + news.Img;
                //GestorNewsletter.AgregarRutaImagen(ruta, news.Img);
                var ruta = @"C:\Users\romina\source\repos\BuscaTuSonido\GUI\Imagenes\";
                GestorNewsletter.AgregarRutaImagen(ruta, FileUpload.FileName);
            }

            Response.Redirect("~/ABMC-Noticias");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Noticias");
        }

        //protected void UploadButton_Click(object sender, EventArgs e)
        //{
        //    var NombreImg = nombreImg.Text.Trim();
        //    string ruta;

        //    if (string.IsNullOrEmpty(NombreImg))
        //    {
        //        Response.Write("<script>alert('Debe completar el nombre de la imagen')</script>");
        //    }
        //    else
        //    {
        //        ruta = @"/Imagenes/Catalogo/" + NombreImg;
        //        FileUpload.SaveAs(Server.MapPath(".") + ruta);
        //        GestorNewsletter.AgregarRutaImagen(ruta, NombreImg);

        //    }

        //}
    }
}