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

            DivContenedor.InnerHtml = $"<div class='col-lg-4 col-md-6 mb-4 d-flex'>";
            foreach (var item in GestorProducto.ObtenerProductos())
            {

                //DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Precio.ToString(), item.Categoria, "http://placehold.it/700x400");
                DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Categoria, "http://placehold.it/700x400");
            }
            DivContenedor.InnerHtml += "</div>";
            this.contenedor.Controls.Add(DivContenedor);
        }


        public string CrearCardProducto(string NombreProducto,
                                        string Categoria,
                                        string urlImagen)
        {
            return
                $" <div class='card h-100'> <a href='#'><img class='card-img-top' src='{urlImagen}' alt='' /></a> <div class='card-body'>" +
                $" <h4 class='card-title'>" +
                $" <a href='#'> {NombreProducto}</a> </h4> " +
                $"<p class='card-text'>{Categoria}</p> </div> <div class='card-footer'> " +
                $"</div> </div> </div>  ";

            //return @"<div class='panel panel-default'> <div class='panel-heading'>Panel Heading</div> <div class='panel-body'>Panel Content</div> <div class='panel-footer'>Panel Footer</div> </div>";
        }

    }
}