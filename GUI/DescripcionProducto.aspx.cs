using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class DescripcionProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string nombre = Request.QueryString["Nombre"].ToString();
                string modelo = Request.QueryString["Modelo"].ToString();
                var producto = GestorProducto.ListarDetalleProducto(nombre, modelo);
                HtmlGenericControl textoTitulo = new HtmlGenericControl("h1");
                HtmlGenericControl textoTitulo1 = new HtmlGenericControl("h2");
                HtmlGenericControl textoTitulo2 = new HtmlGenericControl("h3");
                HtmlGenericControl textoTitulo3 = new HtmlGenericControl("p");
                textoTitulo.InnerHtml = $"{producto.Nombre}";
                textoTitulo1.InnerHtml = $"{producto.Modelo}";
                textoTitulo2.InnerHtml = $"$ {producto.Precio}";
                textoTitulo3.InnerHtml = $"{producto.Descripcion}";
                TxtNombre.Controls.Add(textoTitulo);
                TxtModelo.Controls.Add(textoTitulo1);
                TxtPrecio.Controls.Add(textoTitulo2);
                TxtDescripcion.Controls.Add(textoTitulo3);
                this.ImagenProducto.ImageUrl = GestorProducto.GestionImagen(nombre, "sin categoria");

            }
            catch (Exception)
            {

                throw;
            }
            //Poner validacion de pagina externa
        }

        protected void sendPreguntar_Click(object sender, EventArgs e)
        {

            //
        }
    }
}