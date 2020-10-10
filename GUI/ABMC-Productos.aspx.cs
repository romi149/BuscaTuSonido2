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
            var listaDatos = CargarDatos();
            this.gvProductos.DataSource = listaDatos;
            this.gvProductos.DataBind();
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
            string IdMarca = row.Cells[6].Text.Trim();
            string Modelo = row.Cells[7].Text.Trim();
            string CodProv = row.Cells[8].Text.Trim();
            string IdProv = row.Cells[9].Text.Trim();
            string Color = row.Cells[10].Text.Trim();
            string Estado = row.Cells[11].Text.Trim();
            string Precio = row.Cells[12].Text.Trim();

            Response.Redirect($"/EditarProducto.aspx?Id={Id}&Upc={Upc}&Nombre={Nombre}&Descripcion={Descripcion}" +
                $"&Categoria={Categoria}&TipoInstrumento={TipoInst}&IdMarca={IdMarca}&Modelo={Modelo}&" +
                $"CodProveedor={CodProv}&IdProveedor={IdProv}&Color={Color}&Estado={Estado}&Precio={Precio}");


        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            bool Insertado = GestorProducto.Agregar(
                                       upc.Text.Trim(),
                                       nombre.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       categoria.Text.Trim(),
                                       tipoInstrumento.Text.Trim(),
                                       int.Parse(idMarca.Text.Trim()),
                                       modelo.Text.Trim(),
                                       codProv.Text.Trim(),
                                       int.Parse(idProv.Text.Trim()),
                                       color.Text.Trim(),
                                       estado.Text.Trim(),
                                       precio.Text.Trim()
                                        );

            if (Insertado)
            {
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
    }
}