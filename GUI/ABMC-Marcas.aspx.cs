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
    public partial class ABMC_Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Marcas.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvMarca.DataSource = listaDatos;
            this.gvMarca.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorMarca.Eliminar(int.Parse(Id));

            if (eliminado)

                GestorBitacora.Agregar(DateTime.Now, "Se elimino un registro", "Admin", "Marca");
            Response.Write("<script>alert('Se ha eliminado el registro')</script>");

            Response.Redirect("/ABMC-Marca.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string IdMarca = row.Cells[0].Text.Trim();
            string Nombre = row.Cells[2].Text.Trim();
            string Descripcion = row.Cells[3].Text.Trim();
            
            Response.Redirect($"/EditarMarca.aspx?IdMarca={IdMarca}&Nombre={Nombre}&Descripcion={Descripcion}");
        }

        public DataSet CargarDatos()
        {
            return GestorMarca.ListarMarcas();
        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            var user = Request.QueryString["usuarioBackEnd"];

            Marca marca = new Marca();
            marca.Nombre = nombre.Text.Trim();
            marca.Descripcion = descripcion.Text.Trim();

            bool Insertado = GestorMarca.Agregar(marca);

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se agrego un registro", user, "Marca");
                Response.Write("alert('El registro se ha agregado correctamente')");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Marcas");

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Marcas");
        }
    }
}