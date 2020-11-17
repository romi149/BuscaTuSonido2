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
                CargarComboPrecio();
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

        public void CargarComboPrecio()
        {
            ListItem i;
            i = new ListItem("-Seleccionar Rango de Precios-", "0");
            listPrecio.Items.Add(i);
            i = new ListItem("de 0 a 20.000", "1");
            listPrecio.Items.Add(i);
            i = new ListItem("de 20.001 a 80.000", "2");
            listPrecio.Items.Add(i);
            i = new ListItem("de 80.001 a 150.000", "3");
            listPrecio.Items.Add(i);
            i = new ListItem("de 150.001 a 280.000", "4");
            listPrecio.Items.Add(i);
        }

        public void Buscar_Click(object sender, EventArgs e)
        {
            var marca = listMarca.SelectedItem.ToString();
            var categ = listCategoria.SelectedItem.ToString();
            var precio = listPrecio.SelectedItem.ToString();
            
            switch (precio)
            {
                case "de 0 a 20.000":
                    precio = "uno";
                    break;
                case "de 20.001 a 80.000":
                    precio = "dos";
                    break;
                case "de 80.001 a 150.000":
                    precio = "tres";
                    break;
                case "de 150.001 a 280.000":
                    precio = "cuatro";
                    break;
            }

            if (marca != Constantes.SeleccionarMarca)
            {
                if (categ != Constantes.SeleccionarCategoria)
                {
                    if(precio != "-Seleccionar Rango de Precios-")
                    {
                        CargarProductosBuscados(marca, categ, precio);
                    }
                    else
                    {
                        CargarProductosPorMarcaCat(marca, categ);
                    }
                    
                }
                else if(precio != "-Seleccionar Rango de Precios-")
                {
                    CargarProductosPorMarcaPrecio(marca, precio);
                }
                else
                {
                    CargarProductosPorMarca(marca);
                }
            }
            else if (categ != Constantes.SeleccionarCategoria)
            {
                if (precio != "-Seleccionar Rango de Precios-")
                {
                    CargarProductosPorCatPrecio(categ, precio);
                }
                else
                {
                    CargarProductosPorCategoria(categ);
                }
                
            }
            else if(precio != "-Seleccionar Rango de Precios-")
            {
                CargarProductosPorPrecio(precio);
            }

            CargarComboMarca();
            CargarComboCategoria();
        
        }

        protected void CargarProductosBuscados(string marca, string categoria, string precio)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosBuscados(marca, categoria, precio))
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

        protected void CargarProductosPorMarcaCat(string marca, string categoria)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosPorMarcaCat(marca, categoria))
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

        protected void CargarProductosPorMarcaPrecio(string marca, string precio)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosPorMarcaPrecio(marca, precio))
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

        protected void CargarProductosPorCatPrecio(string categoria, string precio)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosPorCatPrecio(categoria, precio))
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

        protected void CargarProductosPorPrecio(string precio)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosPorPrecio(precio))
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
        public const string SeleccionarTipo = "--- Seleccionar Tipo Instrumento---";
        
    }
}