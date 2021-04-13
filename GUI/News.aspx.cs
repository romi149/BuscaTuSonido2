using BLL;
using Newtonsoft.Json;
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
            //CargarImagen();
        }

        protected void CargarPaginaDinamica()
        {
            var listaDatos = GestorNewsletter.ListarNoticiaParaPublicar();
            var titulo1 = listaDatos[0].Titulo1;
            var titulo2 = listaDatos[0].Titulo2;
            var texto1 = listaDatos[0].Texto1;
            var texto2 = listaDatos[0].Texto2;
            var img = listaDatos[0].Img;
            //var altoimg = listaDatos[0].AltoImg;
            //var anchoimg = listaDatos[0].AnchoImg;

            HtmlGenericControl textoTitulo1 = new HtmlGenericControl("h1");
            HtmlGenericControl textoTitulo2 = new HtmlGenericControl("h2");
            HtmlGenericControl texto = new HtmlGenericControl("p");
            textoTitulo1.InnerHtml = $"{titulo1}";
            textoTitulo2.InnerHtml = $"{titulo2}";
            texto.InnerHtml = $"{texto1}";
            TxtTitulo1.Controls.Add(textoTitulo1);
            TxtTitulo2.Controls.Add(textoTitulo2);
            TxtTexto1.Controls.Add(texto);
            this.ImagenNoticia.ImageUrl = img;
        }

        protected void CargarImagen()
        {
            var listaDatos = GestorNewsletter.ListarNoticiaParaPublicar();
            var img = listaDatos[0].Img;
            var altoimg = listaDatos[0].AltoImg;
            var anchoimg = listaDatos[0].AnchoImg;

            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
            DivContenedor.InnerHtml += $"<img src={img} width='{anchoimg}' height='{altoimg}'>";
            DivContenedor.InnerHtml += $"</img>";
            DivContenedor.InnerHtml += "</div>";
            this.contenedorImagen.Controls.Add(DivContenedor);
            
        }
    }
}