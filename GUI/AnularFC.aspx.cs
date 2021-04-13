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
    public partial class AnularFC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FacturasEmitidas");
        }

        protected void confirmar_Click(object sender, EventArgs e)
        {
            Factura fact = new Factura();
            fact.Detalle = detalle.Text.Trim();
            fact.NroFactura = int.Parse(Session["NroFactura"].ToString());
            fact.PrecioTotal = Session["PrecioTotal"].ToString();
            fact.Estado = "Anulado";
                                    
            GestorFactura.ModificarFactura(fact);

            NotaCredito nc = new NotaCredito();
            nc.NroFactura = int.Parse(Session["NroFactura"].ToString());
            nc.Detalle = detalleNC.Text.Trim();
            nc.Importe = Session["PrecioTotal"].ToString();
            nc.Estado = "";

            bool Generado = GestorNC.AgregarNC(nc);

            if (Generado)
            {
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
            }

        }
    }
}