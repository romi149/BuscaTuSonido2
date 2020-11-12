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
    public partial class ConsultarBitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvBitacora.DataSource = listaDatos;
            this.gvBitacora.DataBind();

        }

        public DataSet CargarDatos()
        {
            return GestorBitacora.Listar();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var entidadIn = entidad.Text.Trim();
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
                if (!string.IsNullOrEmpty(entidadIn))
                {
                    gvBitacora.DataSource = null;
                    gvBitacora.DataSource = GestorBitacora.ListarFiltrado(entidadIn, fechaDesde, fechaHasta);
                    gvBitacora.DataBind();
                }
                else
                {
                    gvBitacora.DataSource = null;
                    gvBitacora.DataSource = GestorBitacora.ListarFiltradoFechas(fechaDesde, fechaHasta);
                    gvBitacora.DataBind();
                }
            }
            else if (entidadIn != null)
            {
                gvBitacora.DataSource = null;
                gvBitacora.DataSource = GestorBitacora.ListarFiltradoEntidad(entidadIn);
                gvBitacora.DataBind();
                                
            }
            
        }
    }
}