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
    public partial class ABMC_Publicidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Publicidad.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvPublicidad.DataSource = listaDatos;
            this.gvPublicidad.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorPublicidad.Eliminar(int.Parse(Id));

            if (eliminado)
            {
                Response.Write("<script>alert('Se ha eliminado el registro')</script>");
            }

            Response.Redirect("/ABMC-Publicidad.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string ImageUrl = row.Cells[1].Text.Trim();
            string NavigateUrl = row.Cells[2].Text.Trim();
            string FechaInicio = row.Cells[3].Text.Trim();
            string FechaFin = row.Cells[4].Text.Trim();
            
            Response.Redirect($"/EditarPublicidad.aspx?Id={Id}&ImageUrl={ImageUrl}&" +
                $"NavigateUrl={NavigateUrl}&FechaInicio={FechaInicio}&" +
                $"FechaFin={FechaFin}");
        }

        public DataSet CargarDatos()
        {
            return GestorPublicidad.Listar();
        }


        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            bool Insertado = GestorPublicidad.Agregar(
                                       imageUrl.Text.Trim(),
                                       navigateUrl.Text.Trim(),
                                       fechaInicio.Text.Trim(),
                                       fechaFin.Text.Trim());

            if (Insertado)
            {
                Response.Write("alert('La publicidad se ha agregado correctamente')");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Publicidad");

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Publicidad");
        }
    }
}