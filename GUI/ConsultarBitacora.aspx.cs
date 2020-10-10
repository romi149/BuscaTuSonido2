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
            var tipo = tipoEvento.Text.Trim();
            var entidadIn = entidad.Text.Trim();

            if (tipo != null)
            {
                if (entidadIn != null)
                {
                    //filtro por todos los campos
                    GestorBitacora.ListarFiltradoTotal(tipo, entidadIn);
                }
                else
                {
                    //filtro solo por tipo


                }
            }
            else if(entidadIn != null)
            {
                //filtro solo por entidad

            }
            
        }
    }
}