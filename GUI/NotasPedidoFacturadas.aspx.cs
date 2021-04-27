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
    public partial class NotasPedidoFacturadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "NotasPedidoFacturadas.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

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

            Remito re = new Remito();
            re.NroNP = NroPedido;
            re.NroFactura = nroFactura;
            re.Estado = "Pendiente";

            bool Generado = GestorRemito.Agregar(re);

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
