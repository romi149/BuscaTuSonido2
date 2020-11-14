using BE;
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
            if (!IsPostBack)
            {
                CargarProductos();
                CargarComboMarca();
                CargarComboCategoria();
            }

            CargarMenuVertical();

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


        protected void CargarProductos()
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
            $"{Descripcion}</p></div><div class='card-footer'></div></div></div>";

        }

        public string CrearMenuVertical(string Nombre)
        {
            return
            $"<div class='list-group'><a id='{Nombre}' href='/CatalogoProductos?NombreProducto={Nombre}' class='list - group - item' >{Nombre}</a></div>";

        }

        public void CargarComboMarca()
        {
            List<Marca> lista = GestorMarca.Listar();
            lista.Insert(0, new Marca { Nombre = Constantes.SeleccionarMarca });
            listMarca.DataSource = lista;
            listMarca.DataTextField = "Nombre";
            listMarca.DataValueField = "IdMarca";
            listMarca.DataBind();


        }

        public void CargarComboCategoria()
        {
            List<Producto> lista = GestorProducto.ListarCategorias();
            lista.Insert(0, new Producto { Categoria = Constantes.SeleccionarCategoria });
            listCategoria.DataSource = lista;
            listCategoria.DataTextField = "Categoria";
            listCategoria.DataValueField = "Categoria";
            listCategoria.DataBind();
        }
        
        public void Buscar_Click(object sender, EventArgs e)
        {
            var marca = listMarca.SelectedItem.ToString();
            var categ = listCategoria.SelectedItem.ToString();

            if (marca != Constantes.SeleccionarMarca)
            {
                if (categ != Constantes.SeleccionarCategoria)
                {
                    CargarProductosBuscados(marca, categ);
                }
                else
                {
                    CargarProductosPorMarca(marca);
                }
            }
            else if (categ != Constantes.SeleccionarCategoria)
            {
                CargarProductosPorCategoria(categ);
            }
            CargarComboMarca();
            CargarComboCategoria();
        }

        protected void CargarProductosBuscados(string marca, string categoria)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosBuscados(marca, categoria))
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

        protected void CargarProductosPorMarca(string marca)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosPorMarca(marca))
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

        protected void CargarProductosPorCategoria(string categoria)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosCategoria(categoria))
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

    public class Constantes
    {
        public const string SeleccionarCategoria = "--- Seleccionar categoria---";
        public const string SeleccionarMarca = "--- Seleccionar Marca---";
        public const string SeleccionarProveedor = "--- Seleccionar Proveedor---";
    }
}