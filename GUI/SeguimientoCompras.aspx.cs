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
    public partial class SeguimientoCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var listaDatos = CargarDatos();
            this.gvRemitos.DataSource = listaDatos;
            this.gvRemitos.DataBind();
            
        }

        protected override void OnInit(EventArgs e)
        {
            gvRemitos.RowDataBound += new GridViewRowEventHandler(gvRemitos_RowDataBound);
            base.OnInit(e);
        }
        void gvRemitos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            if (e.Row.Cells[6].Text == "Entregado")
            {
                Button btnOpinion = (Button)e.Row.FindControl("btnOpinion");
                btnOpinion.Visible = true;
            }

        }

        public DataSet CargarDatos()
        {
            int NroFactura = int.Parse(Request.QueryString["NroFactura"].ToString());
            string Usuario = Request.QueryString["Usuario"].ToString();

            return GestorRemito.ListarRemitosPorCliente(NroFactura, Usuario);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/MisCompras.aspx");

        }

        protected void btnOpinion_Click(object sender, EventArgs e)
        {
            var CLIENTE = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string NroFactura = row.Cells[3].Text.Trim();
            
            var NroNP = GestorNP.ObtenerNPxFC(int.Parse(NroFactura));
            var NombreProducto = GestorNP.ObtenerProducto(NroNP);
            var valorado = GestorNP.VerificarValoracion(CLIENTE, NombreProducto);

            if(valorado.Count != 0)
            {
                Response.Write("<script>alert('Ya ha valorado el producto, si desea realizar otro comentario hagalo a través de nuestro chat.')</script>");
                
            }
            else
            {
                Response.Redirect($"/ValoracionProducto.aspx?NroNP={NroNP}");
            }
            

        }
       

    }
}