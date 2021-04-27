using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EditarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Id.Text = Request.QueryString["Id"].ToString();
            upc.Text = Request.QueryString["UPC"].ToString();
            nombre.Text = Request.QueryString["Nombre"].ToString();
            descripcion.Text = Request.QueryString["Descripcion"].ToString();
            categoria.Text = Request.QueryString["Categoria"]?.ToString();
            tipoInstrumento.Text = Request.QueryString["TipoInst"].ToString();
            //idMarca.Text = Request.QueryString["IdMarca"].ToString();
            modelo.Text = Request.QueryString["Modelo"].ToString();
            codProv.Text = Request.QueryString["CodProv"].ToString();
            //idProv.Text = Request.QueryString["IdProv"].ToString();
            color.Text = Request.QueryString["Color"].ToString();
            estado.Text = Request.QueryString["Estado"].ToString();
            precio.Text = Request.QueryString["Precio"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Id = int.Parse(Id.Text.Trim());
            prod.Upc = upc.Text.Trim();
            prod.Nombre = nombre.Text.Trim();
            prod.Descripcion = descripcion.Text.Trim();
            prod.Categoria = categoria.Text.Trim();
            prod.TipoInstrumento = tipoInstrumento.Text.Trim();
            prod.Modelo = modelo.Text.Trim();
            prod.CodProveedor = codProv.Text.Trim();
            prod.Color = color.Text.Trim();
            prod.Estado = estado.Text.Trim();
            prod.Precio = precio.Text.Trim();

            bool Modificado = GestorProducto.Modificar(prod);

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "RespCompras", "Producto");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Productos");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Productos");
        }


    }
}