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
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPaginaDinamica();
        }

        protected void CargarPaginaDinamica()
        {
            var titulo1 = "Proximos eventos";
            var titulo2 = "Otros eventos";
            var texto1 = "Hola mundoooooooooooooooooooooo";
            var texto2 = "Hola a todos";
            var img = "/imagenes/Portada/pexels.png";
            var altoimg = "300";
            var anchoimg = "400";
            
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml += $"<div>";
            DivContenedor.InnerHtml += "<div clas='row'>";
            
            DivContenedor.InnerHtml += "<div class='col-lg-6'>";
            DivContenedor.InnerHtml += "<div class='primero'>";
            DivContenedor.InnerHtml = $"<h2>{titulo1}";
            DivContenedor.InnerHtml += "</h2>";
            DivContenedor.InnerHtml += $"<p>{texto1}";
            DivContenedor.InnerHtml += "</p>";
            DivContenedor.InnerHtml += "</div>";
            //DivContenedor.InnerHtml += "<div class='segundo'>";
            //DivContenedor.InnerHtml = $"<h2>{titulo2}";
            //DivContenedor.InnerHtml += "</h2>";
            //DivContenedor.InnerHtml += $"<p>{texto2}";
            //DivContenedor.InnerHtml += "</p>";
            //DivContenedor.InnerHtml += "</div>";
            DivContenedor.InnerHtml += "</div>";

            DivContenedor.InnerHtml += "<div class='col-lg-6'>";
            DivContenedor.InnerHtml += $"<img src ={img} width='{anchoimg}' height='{altoimg}'";
            DivContenedor.InnerHtml += "</img>";
            DivContenedor.InnerHtml += "</div>";
            
            DivContenedor.InnerHtml += "</div>";
            DivContenedor.InnerHtml += "</div>";
            this.contenedorNews.Controls.Add(DivContenedor);
        }
    }
}