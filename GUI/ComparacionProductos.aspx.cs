using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ComparacionProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string parametros = string.Empty;
            for (int i = 0; i < Request.QueryString.Count; i++)
            {
                parametros = Request.QueryString[i].ToString().Replace("%20", " ");
                var item = GestorProducto.ListarProductosAComparar(parametros);
                if (item.Count > 0)
                    CargarComparador(item.FirstOrDefault()?.Nombre,
                                   item.FirstOrDefault()?.Modelo,
                                   item.FirstOrDefault()?.Precio,
                                   item.FirstOrDefault()?.Descripcion,
                                   item.FirstOrDefault()?.urlImg);
            }
            parametros.TrimEnd(',');
        }

        protected void CargarComparador(string nombre, string modelo, string precio, string desc, string url)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
            DivContenedor.InnerHtml = $"<div class='thumbnail'>" +
                $"<img src='{url}' alt=''><div class='caption'><h3>{nombre}</h3>" +
                $"<label >{modelo}</label><label>{precio}</label><label>{desc}</label>" +
                $"<div>" +
                $"<br></br><p><a href='/FormularioDeCompra' class='btn btn-success' role='button'>Comprar</a>" +
                $"<a href='/Default' class='btn btn-default' role='button'>Volver</a></p></div></div></div>";
            this.Productos.Controls.Add(DivContenedor);
        }

    }
}