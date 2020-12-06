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
    public partial class NotasPedidoFacturadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvNotasPedidoFacturadas.DataSource = listaDatos;
            this.gvNotasPedidoFacturadas.DataBind();
        }

        protected void btnGenerarRemito_Click(object sender, EventArgs e)
        {
            //Generar remito (crear registro en tabla Remito) 
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int NroPedido = int.Parse(row.Cells[0].Text.Trim().ToString());

            var nroFactura = GestorFactura.ObtenerFactura(NroPedido);

            bool Generado = GestorRemito.Agregar(NroPedido, nroFactura, "Pendiente");

            if (Generado)
            {
                CargarDatos();
                Response.Write("<script>alert('El remito se ha generado correctamente')</script>");
            }
            

        }

        public DataSet CargarDatos()
        {
            return GestorNP.ListarNotasPedidoFacturadas();
        }
    }
}
