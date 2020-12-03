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
            string DetalleFC = detalle.Text.Trim();
            string DetalleNC = detalleNC.Text.Trim();
            var NumFactura = Session["NroFactura"].ToString();
            var importe = Session["PrecioTotal"].ToString();

            GestorFactura.ModificarFactura(int.Parse(NumFactura),"Anulado",DetalleFC);

            bool Generado = GestorNC.AgregarNC(int.Parse(NumFactura), DetalleNC, importe, "");

            if (Generado)
            {
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
            }

        }
    }
}