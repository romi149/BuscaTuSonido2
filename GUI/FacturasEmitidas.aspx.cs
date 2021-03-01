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
    public partial class FacturasEmitidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ReporteVentas.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvFacturas.DataSource = listaDatos;
            this.gvFacturas.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorFactura.ListarFacturasEmitidas();
        }

        protected void anular_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string NroFactura = row.Cells[0].Text.Trim();
            string PrecioTotal = row.Cells[4].Text.Trim();

            Session["NroFactura"] = NroFactura;
            Session["PrecioTotal"] = PrecioTotal;

        }
    }
}