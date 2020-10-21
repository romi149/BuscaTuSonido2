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
            var status = "GET";

            //if(entidadIn != null || entidadIn != "")
            //{
            //    GestorBitacora.ListarFiltradoEntidad(entidadIn);
            //}


            if (fechaDesde == null && fechaHasta != null
                || fechaDesde != null && fechaHasta == null)
            {
                Response.Write("alert('Seleccione la fecha desde y fecha  hasta para filtrar la información')");

                fechaDesde = null;
                fechaHasta = null;
                return;
            }
            else if ((fechaDesde != null || fechaDesde != "") && (fechaHasta != null || fechaHasta != ""))
            {
                if (entidadIn != null)
                {
                    GestorBitacora.ListarFiltrado(entidadIn, fechaDesde, fechaHasta, status);
                }
                else
                {
                    entidadIn = null;
                    GestorBitacora.ListarFiltrado(entidadIn, fechaDesde, fechaHasta, status);
                }
            }
            else if (entidadIn != null)
            {
                fechaDesde = null;
                fechaHasta = null;

                GestorBitacora.ListarFiltrado(entidadIn, fechaDesde, fechaHasta, status);
            }

        }
    }
}