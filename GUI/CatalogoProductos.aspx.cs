using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class InstrumentosCuerdas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMenuVertical();
            string Nombre = Request.QueryString["NombreProducto"]?.ToString();
            CargarProductos(Nombre);

        }

        protected void CargarMenuVertical()
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorMenu.ObtenerMenuVertical())
            {
                if (cont == 0)
                    DivContenedor.InnerHtml += "<div clas='row'>";
                if (cont < 3)
                {
                    DivContenedor.InnerHtml += CrearMenuVertical(item.NombreMenu);
                }
                else
                {
                    DivContenedor.InnerHtml += CrearMenuVertical(item.NombreMenu) + "</div>";
                    cont = 0;
                }
                cont++;
            }
            DivContenedor.InnerHtml += "</div>";
            this.contenedorMenu.Controls.Add(DivContenedor);
        }

        protected void CargarProductos(string nombre)
        {
            if (nombre != null)
            {
                HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
                DivContenedor.InnerHtml = $"<div>";
                int cont = 0;
                foreach (var item in GestorProducto.ListarProdPorCategoria(nombre))
                {
                    if (cont == 0)
                        DivContenedor.InnerHtml += "<div clas='row'>";
                    if (cont < 3)
                    {
                        DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Modelo, item.Precio.ToString(), item.Descripcion, GestorProducto.GestionImagen(item.Nombre, "sin categoria"));
                    }
                    else
                    {
                        DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Modelo, item.Precio.ToString(), item.Descripcion, GestorProducto.GestionImagen(item.Nombre, "sin categoria")) + "</div>";
                        cont = 0;
                    }
                    cont++;
                }
                DivContenedor.InnerHtml += "</div>";
                this.contenedor.Controls.Add(DivContenedor);
            }
        }

        public string CrearCardProducto(string NombreProducto,
                                          string Modelo,
                                          string PrecioProducto,
                                          string Descripcion,
                                          string urlImagen)
        {
            return
            $"<div class='col-md-4 col-sm-4'><div class='card'><a href='#'><img class='card-img-top' " +
            $"src='{urlImagen}' alt='' /></a><div class='card-body'><h4 class='card-title'>" +
            $"<a href='DescripcionProducto.aspx?Nombre={NombreProducto}&Modelo={Modelo}'>{NombreProducto}</a></h4><h5>${PrecioProducto}</h5><p class='card-text'>" +
            $"{Descripcion}</p></div><div class='card-footer'>" +
            $"<input type='checkbox' class='ck' name='producto' value='{NombreProducto}' onChange='addComparacion(this.value);'/> " +
            $"<label for ='producto'> Comparar producto</label></div></div></div>";

        }


        public string CrearMenuVertical(string Nombre)
        {
            return
            $"<div class='list-group'><a id='{Nombre}' href='/CatalogoProductos?NombreProducto={Nombre}' class='list - group - item' >{Nombre}</a></div>";

        }


        protected void Comparar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}