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
            var cont = 0;
            for (int i = 0; i < Request.QueryString.Count; i++)
            {
                parametros += Request.QueryString[i].ToString().Replace("%20", " ") + ',';

                foreach (var item in GestorProducto.ListarProductosAComparar(parametros))
                {
                    if (cont <= i)
                    {
                        CargarComparador(item.Nombre, item.Modelo, item.Precio, item.Descripcion, item.urlImg);
                    }
                    cont++;
                }

            }
            parametros.TrimEnd(',');
        }

        protected void CargarComparador(string nombre, string modelo, string precio, string desc, string url)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
            DivContenedor.InnerHtml = $"<div id='productos'><div class='thumbnail'>" +
                $"<img src='{url}' alt=''><div class='caption'><h3>{nombre}</h3>" +
                $"<label >{modelo}</label><label>{precio}</label><label>{desc}</label>" +
                $"<p><a href='#' class='btn btn-primary' role='button'>Button</a>" +
                $"<a href='#' class='btn btn-default' role='button'>Button</a></p></div></div></div>";
            this.Productos.Controls.Add(DivContenedor);
        }

    }
}