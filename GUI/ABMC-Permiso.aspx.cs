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
    public partial class ABMC_Permiso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Permiso.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            if (!IsPostBack)
            {
                var listaDatos = CargarDatos();
                this.gvPermiso.DataSource = listaDatos;
                this.gvPermiso.DataBind();
            }
        }

        public DataSet CargarDatos()
        {
            return GestorPermiso.Listar();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string IdPermiso = row.Cells[0].Text.Trim();

            bool eliminado = GestorPermiso.Eliminar(int.Parse(IdPermiso));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se elimino un Permiso", "Admin", "Permiso");
            }

            Response.Redirect("/ABMC-Permiso.aspx");

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string IdPermiso = row.Cells[0].Text.Trim();
            string Nombre = row.Cells[1].Text.Trim();
            string Descripcion = row.Cells[2].Text.Trim();
            string TipoPermiso = row.Cells[3].Text.Trim();

            Response.Redirect($"/EditarPermiso.aspx?IdPermiso={IdPermiso}&Nombre={Nombre}" +
                $"&Descripcion={Descripcion}&TipoPermiso={TipoPermiso}");

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            Permiso per = new Permiso();
            per.NombrePermiso = nombre.Text.Trim();
            per.Descripcion = descripcion.Text.Trim();
            per.TipoPermiso = tipoPermiso.Text.Trim();

            bool Insertado = GestorPermiso.Agregar(per);

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se inserto un nuevo permiso", "Admin", "Permiso");
                Response.Write("<script>alert('El permiso se ha agregado correctamente')</script>");
            }

            Response.Redirect("~/ABMC-Permiso");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Permiso");
        }
    }
}