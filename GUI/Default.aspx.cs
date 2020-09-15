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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ObtenerCatalogo())
            {
                if (cont == 0)
                    DivContenedor.InnerHtml += "<div clas='row'>";
                if (cont < 3)
                {
                    DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Precio.ToString(), item.Categoria, "http://placehold.it/700x400");
                }
                else
                {
                    DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Precio.ToString(), item.Categoria, "http://placehold.it/700x400") + "</div>";
                    cont = 0;
                }
                cont++;
            }
            DivContenedor.InnerHtml += "</div>";
            this.contenedor.Controls.Add(DivContenedor);
        }


        public string CrearCardProducto(string NombreProducto,
                                          string PrecioProducto,
                                          string Descripcion,
                                          string urlImagen)
        {
            return
            $"<div class='col-md-4 col-sm-4'><div class='card'><a href='#'><img class='card-img-top' src='http://placehold.it/700x400' alt='' /></a><div class='card-body'><h4 class='card-title'><a href='#'>NombreProducto</a></h4><h5>0</h5><p class='card-text'>Descripcion</p></div><div class='card-footer'></div></div></div>";

        }

    }
}