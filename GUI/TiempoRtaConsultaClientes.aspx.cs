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
    public partial class TiempoRtaConsultaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvTiempoRtaConsultaClientes.DataSource = listaDatos;
            this.gvTiempoRtaConsultaClientes.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorProducto.ListarReporteTiempoRtaClientes();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var user = usuario.Text.Trim();
            var fechaDesde = desde.Text.Trim();
            var fechaHasta = hasta.Text.Trim();

            if ((string.IsNullOrEmpty(fechaDesde) && (!string.IsNullOrEmpty(fechaHasta)))
                || ((!string.IsNullOrEmpty(fechaDesde)) && (string.IsNullOrEmpty(fechaHasta))))
            {
                Response.Write("<script>alert('¡Para filtrar por fechas debe seleccionar fecha desde y fecha hasta!')</script>");

                return;
            }
            else if (!string.IsNullOrEmpty(fechaDesde) && (!string.IsNullOrEmpty(fechaHasta)))
            {
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por todo
                    gvTiempoRtaConsultaClientes.DataSource = null;
                    gvTiempoRtaConsultaClientes.DataSource = GestorProducto.ListarTiempoRtaClienteFiltroTotal(user, fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaClientes.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por fecha
                    gvTiempoRtaConsultaClientes.DataSource = null;
                    gvTiempoRtaConsultaClientes.DataSource = GestorProducto.ListarTiempoRtaClienteFiltroFechas(fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaClientes.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro por usuario
                gvTiempoRtaConsultaClientes.DataSource = null;
                gvTiempoRtaConsultaClientes.DataSource = GestorProducto.ListarTiempoRtaClientesFiltroUser(user);
                gvTiempoRtaConsultaClientes.DataBind();
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            usuario.Text = "";
            desde.Text = "";
            hasta.Text = "";
        }
    }
}