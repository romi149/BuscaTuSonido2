using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ABMC_Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Productos.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            if (!IsPostBack)
            {
                var listaDatos = CargarDatos();
                this.gvProductos.DataSource = listaDatos;
                this.gvProductos.DataBind();
                CargarComboMarca();
                CargarComboCodProv();
                CargarComboCategoria();
                CargarComboTipoInstrumento();
                CargarComboEstados();
            }
        }

        public DataSet CargarDatos()
        {
            return GestorProducto.ListarProductos();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorProducto.Eliminar(int.Parse(Id));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se elimino un registro", "RespCompras", "Producto");
            }

            Response.Redirect("/ABMC-Productos.aspx");

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string Upc = row.Cells[1].Text.Trim();
            string Nombre = row.Cells[2].Text.Trim();
            string Descripcion = row.Cells[3].Text.Trim();
            string Categoria = row.Cells[4].Text.Trim();
            string TipoInst = row.Cells[5].Text.Trim();
            //string IdMarca = row.Cells[6].Text.Trim();
            string Modelo = row.Cells[6].Text.Trim();
            string CodProv = row.Cells[7].Text.Trim();
            //string IdProv = row.Cells[9].Text.Trim();
            string Color = row.Cells[8].Text.Trim();
            string Estado = row.Cells[9].Text.Trim();
            string Precio = row.Cells[10].Text.Trim();

            Response.Redirect($"/EditarProducto.aspx?Id={Id}&Upc={Upc}&Nombre={Nombre}&Descripcion={Descripcion}" +
                $"&Categoria={Categoria}&TipoInstrumento={TipoInst}&Modelo={Modelo}&" +
                $"CodProveedor={CodProv}&Color={Color}&Estado={Estado}&Precio={Precio}");

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            var marca = listMarca.SelectedItem.ToString();
            var nombreEmpresa = listCodProv.SelectedItem.ToString();
            
            var IDMarca = GestorMarca.ObtenerId(marca);
            var codProv = GestorProveedor.ObtenerCod(nombreEmpresa);
            var IDProv = GestorProveedor.ObtenerId(nombreEmpresa);

            Producto prod = new Producto();
            prod.Upc = upc.Text.Trim();
            prod.Nombre = nombre.Text.Trim();
            prod.Descripcion = descripcion.Text.Trim();
            prod.Categoria = listCategoria.SelectedItem.ToString();
            prod.TipoInstrumento = listTipoInstrumento.SelectedItem.ToString();
            prod.IdMarca = IDMarca;
            prod.Modelo = modelo.Text.Trim();
            prod.CodProveedor = codProv;
            prod.IdProveedor = IDProv;
            prod.Color = color.Text.Trim();
            prod.Estado = listEstado.SelectedItem.ToString();
            prod.Precio = precio.Text.Trim();

            bool Insertado = GestorProducto.Agregar(prod);

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se inserto un nuevo producto", "RespCompras", "Producto");
                Response.Write("<script>alert('El producto se ha agregado correctamente')</script>");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Productos");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Productos");
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {

            //this.gvProductos.DataSource = CargarDatos();
            //this.gvProductos.DataBind();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var nombreProd = nombre.Text.Trim();
            var Tipo = listTipoInstrumento.SelectedItem.ToString();
            string ruta;
            string rutaBD;

            if (string.IsNullOrEmpty(nombreProd))
            {
                Response.Write("<script>alert('Debe completar los datos del producto')</script>");
            }
            else 
            {
                switch(Tipo)
                {
                    case "Cuerdas":
                        ruta = @"C:/Users/romina/source/repos/BuscaTuSonido/GUI/Imagenes/Catalogo/Cuerdas/";
                        ruta += FileUpload.FileName;

                        rutaBD = @"/Imagenes/Catalogo/Cuerdas/";
                        rutaBD += FileUpload.FileName;

                        FileUpload.SaveAs(ruta);
                        GestorProducto.AgregarImg(nombreProd, "Sin categoria", rutaBD);
                        break;

                    case "Electronico":
                        ruta = @"C:/Users/romina/source/repos/BuscaTuSonido/GUI/Imagenes/Catalogo/Electronicos/";
                        ruta += FileUpload.FileName;

                        rutaBD = @"/Imagenes/Catalogo/Electronicos/";
                        rutaBD += FileUpload.FileName;

                        FileUpload.SaveAs(ruta);
                        GestorProducto.AgregarImg(nombreProd, "Sin categoria", rutaBD);
                        break;

                    case "Viento":
                        ruta = @"C:/Users/romina/source/repos/BuscaTuSonido/GUI/Imagenes/Catalogo/Viento/";
                        ruta += FileUpload.FileName;

                        rutaBD = @"/Imagenes/Catalogo/Viento/";
                        rutaBD += FileUpload.FileName;

                        FileUpload.SaveAs(ruta);
                        GestorProducto.AgregarImg(nombreProd, "Sin categoria", rutaBD);
                        break;

                    case "Percusion":
                        ruta = @"C:/Users/romina/source/repos/BuscaTuSonido/GUI/Imagenes/Catalogo/Percusion/";
                        ruta += FileUpload.FileName;

                        rutaBD = @"/Imagenes/Catalogo/Percusion/";
                        rutaBD += FileUpload.FileName;

                        FileUpload.SaveAs(ruta);
                        GestorProducto.AgregarImg(nombreProd, "Sin categoria", rutaBD);
                        break;
                }

            }
            
        }

        public void CargarComboMarca()
        {
            List<Marca> lista = GestorMarca.Listar();
            lista.Insert(0, new Marca { Nombre = Constantes.SeleccionarMarca });
            listMarca.DataSource = lista;
            listMarca.DataTextField = "Nombre";
            listMarca.DataValueField = "Nombre";
            listMarca.DataBind();

        }

        public void CargarComboCodProv()
        {
            List<Proveedor> lista = GestorProveedor.ListarProveedor();
            lista.Insert(0, new Proveedor { NombreEmpresa = Constantes.SeleccionarProveedor });
            listCodProv.DataSource = lista;
            listCodProv.DataTextField = "NombreEmpresa";
            listCodProv.DataValueField = "NombreEmpresa";
            listCodProv.DataBind();

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

        public void CargarComboTipoInstrumento()
        {
            List<Producto> lista = GestorProducto.ListarTipoInstrumentos();
            lista.Insert(0, new Producto { TipoInstrumento = Constantes.SeleccionarTipo });
            listTipoInstrumento.DataSource = lista;
            listTipoInstrumento.DataTextField = "TipoInstrumento";
            listTipoInstrumento.DataValueField = "TipoInstrumento";
            listTipoInstrumento.DataBind();

        }

        public void CargarComboEstados()
        {
            ListItem i;
            i = new ListItem("--- Seleccionar Estado---", "1");
            listEstado.Items.Add(i);
            i = new ListItem("Normal", "2");
            listEstado.Items.Add(i);
            i = new ListItem("Destacado", "3");
            listEstado.Items.Add(i);
            i = new ListItem("Alquiler", "4");
            listEstado.Items.Add(i);
        }
    }
}