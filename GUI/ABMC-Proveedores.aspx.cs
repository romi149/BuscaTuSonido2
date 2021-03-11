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
    public partial class ABMC_Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Proveedores.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvProveedores.DataSource = listaDatos;
            this.gvProveedores.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorProveedor.Eliminar(int.Parse(Id));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now,"Se elimino un registro","RespCompras","Proveedor");
                Response.Write("<script>alert('Se ha eliminado el proveedor')</script>");
            }

            Response.Redirect("/ABMC-Proveedores.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string CodProv = row.Cells[1].Text.Trim();
            string NombreEmpresa = row.Cells[2].Text.Trim();
            string RazonSocial = row.Cells[3].Text.Trim();
            string Domicilio = row.Cells[4].Text.Trim();
            string Email = row.Cells[5].Text.Trim();
            string Telefono = row.Cells[6].Text.Trim();
            string Descripcion = row.Cells[7].Text.Trim();
            string Cuit = row.Cells[8].Text.Trim();

            Response.Redirect($"/EditarProveedor.aspx?IdProveedor={Id}&CodProveedor={CodProv}&NombreEmpresa={NombreEmpresa}" +
                $"&RazonSocial={RazonSocial}&Domicilio={Domicilio}&Email={Email}&Telefono={Telefono}&Descripcion={Descripcion}&Cuit={Cuit}");
        }

        public DataSet CargarDatos()
        {
            return GestorProveedor.Listar();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {

            //this.gvProductos.DataSource = CargarDatos();
            //this.gvProductos.DataBind();
        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            bool Insertado = GestorProveedor.Agregar(
                                       codProv.Text.Trim(),
                                       nombreEmp.Text.Trim(),
                                       razonSocial.Text.Trim(),
                                       domicilio.Text.Trim(),
                                       email.Text.Trim(),
                                       tel.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       cuit.Text.Trim());

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se inserto un registro", "RespCompras", "Proveedor");
                Response.Write("alert('El proveedor se ha agregado correctamente')");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Proveedores");

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Proveedores");
        }
    }
}