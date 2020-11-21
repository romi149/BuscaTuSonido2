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

        public DataSet CargarDatos()
        {
            int NroFactura = int.Parse(Request.QueryString["NroFactura"].ToString());
            string Usuario = Request.QueryString["Usuario"].ToString();

            return GestorRemito.ListarRemitosPorCliente(NroFactura, Usuario);
        }
    }
}