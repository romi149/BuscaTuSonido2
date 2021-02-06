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
    public partial class TiempoRtaConsultaProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvTiempoRtaConsultaProd.DataSource = listaDatos;
            this.gvTiempoRtaConsultaProd.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorProducto.ListarReporteTiempoRtaProductos();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var Producto = producto.Text.Trim();
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
                if (!string.IsNullOrEmpty(Producto))
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        //filtro por todo
                        gvTiempoRtaConsultaProd.DataSource = null;
                        gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroTotal(Producto, user, fechaDesde, fechaHasta);
                        gvTiempoRtaConsultaProd.DataBind();
                        LimpiarCampos();
                    }
                    else
                    {
                        //filtro por fecha y producto
                        gvTiempoRtaConsultaProd.DataSource = null;
                        gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroFechaProd(Producto, fechaDesde, fechaHasta);
                        gvTiempoRtaConsultaProd.DataBind();
                        LimpiarCampos();
                    }

                }
                else if (!string.IsNullOrEmpty(user))
                {
                    //filtro por fechas y usuario
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroFechaUser(user, fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro solo por fechas
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroFechas(fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(Producto))
            {
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por producto y usuario
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroProdUser(Producto, user);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por producto
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroProd(Producto);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }

            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro solo por usuario
                gvTiempoRtaConsultaProd.DataSource = null;
                gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroUser(user);
                gvTiempoRtaConsultaProd.DataBind();
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            producto.Text = "";
            usuario.Text = "";
            desde.Text = "";
            hasta.Text = "";
        }
    }
}