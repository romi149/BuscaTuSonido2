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
            string UPC = Request.QueryString["upc"].ToString();
            string Nombre = Request.QueryString["nombre"].ToString();
            string Descrip = Request.QueryString["descripcion"].ToString();
            string Categoria = Request.QueryString["Categoria"].ToString();
            string Tipo = Request.QueryString["tipoInst"].ToString();
            string IdMarca = Request.QueryString["idMarca"].ToString();
            string Modelo = Request.QueryString["modelo"].ToString();
            string CodProv = Request.QueryString["codProv"].ToString();
            string IdProv = Request.QueryString["idProv"].ToString();
            string Color = Request.QueryString["color"].ToString();
            string Estado = Request.QueryString["estado"].ToString();
            string Precio = Request.QueryString["precio"].ToString();
            
            Id.Text = IdProd;
            upc.Text = UPC;
            nombre.Text = Nombre;
            categoria.Text = Categoria;
            tipoInst.Text = Tipo;
            idMarca.Text = IdMarca;
            modelo.Text = Modelo;
            codProv.Text = CodProv;
            idProv.Text = IdProv;
            color.Text = Color;
            precio.Text = Precio;
            estado.Text = Estado;
            descripcion.Text = Descrip;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorProducto.Modificar(
                                        int.Parse(Id.Text.Trim()),
                                        upc.Text.Trim(),
                                        nombre.Text.Trim(),
                                        descripcion.Text.Trim(),
                                        categoria.Text.Trim(),
                                        tipoInst.Text.Trim(),
                                        int.Parse(idMarca.Text.Trim()),
                                        modelo.Text.Trim(),
                                        codProv.Text.Trim(),
                                        int.Parse(idProv.Text.Trim()),
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