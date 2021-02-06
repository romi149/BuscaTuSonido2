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
    public partial class ReporteVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvVentas.DataSource = listaDatos;
            this.gvVentas.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorFactura.ListarFacturasReporte();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var NroFactura = nroFactura.Text.Trim();
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
                if (!string.IsNullOrEmpty(NroFactura))
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        //filtro por todo
                        gvVentas.DataSource = null;
                        gvVentas.DataSource = GestorFactura.ListarReporteFiltroTotal(int.Parse(NroFactura), user, fechaDesde, fechaHasta);
                        gvVentas.DataBind();
                        LimpiarCampos();
                    }
                    else
                    {
                        //filtro por fecha y nro factura
                        gvVentas.DataSource = null;
                        gvVentas.DataSource = GestorFactura.ListarReporteFechaNroFactura(int.Parse(NroFactura), fechaDesde, fechaHasta);
                        gvVentas.DataBind();
                        LimpiarCampos();
                    }

                }
                else if (!string.IsNullOrEmpty(user))
                {
                    //filtro por fechas y usuario
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteFechaUser(user, fechaDesde, fechaHasta);
                    gvVentas.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro solo por fechas
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteFechas(fechaDesde, fechaHasta);
                    gvVentas.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(NroFactura))
            {
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por nro factura y usuario
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteNroFactUser(int.Parse(NroFactura), user);
                    gvVentas.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por nro factura
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteNroFactura(int.Parse(NroFactura));
                    gvVentas.DataBind();
                    LimpiarCampos();
                }

            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro solo por usuario
                gvVentas.DataSource = null;
                gvVentas.DataSource = GestorFactura.ListarReporteUser(user);
                gvVentas.DataBind();
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            nroFactura.Text = "";
            usuario.Text = "";
            desde.Text = "";
            hasta.Text = "";
        }
    }
}