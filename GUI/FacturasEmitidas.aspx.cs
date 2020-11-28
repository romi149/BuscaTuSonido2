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
            var listaDatos = CargarDatos();
            this.gvFacturas.DataSource = listaDatos;
            this.gvFacturas.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorFactura.ListarFacturasEmitidas();
        }

        //protected void cancelar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("/FacturasEmitidas");
        //}

        //protected void confirmar_Click(object sender, EventArgs e)
        //{
        //    string Detalle = detalle.Text.Trim();
        //    string DetalleNC = detalleNC.Text.Trim();
        //    //int NumFactura = NroFactura.Text.Trim();

        //    //bool Generado = GestorNC.AgregarNC(NroFactura, DetalleNC);

        //    //Generar NC(crear registro en tabla NotaCredito) y modificar el estado de la factura a Anulado

        //}

        protected void anular_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string NroFactura = row.Cells[0].Text.Trim();

            Session["NroFactura"] = NroFactura;

        }
    }
}