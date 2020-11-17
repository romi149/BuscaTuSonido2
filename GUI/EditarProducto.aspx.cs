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

            string IdProd = Request.QueryString["Id"].ToString();
            string UPC = Request.QueryString["UPC"].ToString();
            string Nombre = Request.QueryString["Nombre"].ToString();
            string Descripcion = Request.QueryString["Descripcion"].ToString();
            string Categoria = Request.QueryString["Categoria"]?.ToString();
            string TipoInst = Request.QueryString["TipoInst"].ToString();
            //string IdMarca = Request.QueryString["IdMarca"].ToString();
            string Modelo = Request.QueryString["Modelo"].ToString();
            string CodProv = Request.QueryString["CodProv"].ToString();
            //string IdProv = Request.QueryString["IdProv"].ToString();
            string Color = Request.QueryString["Color"].ToString();
            string Estado = Request.QueryString["Estado"].ToString();
            string Precio = Request.QueryString["Precio"].ToString();
            
            Id.Text = IdProd;
            upc.Text = UPC;
            nombre.Text = Nombre;
            categoria.Text = Categoria;
            tipoInstrumento.Text = TipoInst;
            //idMarca.Text = IdMarca;
            modelo.Text = Modelo;
            codProv.Text = CodProv;
            //idProv.Text = IdProv;
            color.Text = Color;
            precio.Text = Precio;
            estado.Text = Estado;
            descripcion.Text = Descripcion;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorProducto.Modificar(
                                        int.Parse(Id.Text.Trim()),
                                        upc.Text.Trim(),
                                        nombre.Text.Trim(),
                                        descripcion.Text.Trim(),
                                        categoria.Text.Trim(),
                                        tipoInstrumento.Text.Trim(),
                                        //int.Parse(idMarca.Text.Trim()),
                                        modelo.Text.Trim(),
                                        codProv.Text.Trim(),
                                        //int.Parse(idProv.Text.Trim()),
                                        color.Text.Trim(),
                                        estado.Text.Trim(),
                                        precio.Text.Trim());

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