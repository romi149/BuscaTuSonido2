using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class MisCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvCompras.DataSource = listaDatos;
            this.gvCompras.DataBind();
            CargarDatosPreguntas();
        }

        public DataSet CargarDatos()
        {
            var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

            return GestorCliente.ListarCompras(UserCliente);
        }

        private void CargarDatosPreguntas()
        {
            try
            {
                var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
                
                var Preguntas = GestorProducto.ListarPreguntasCliente(UserCliente);
                foreach (var item in Preguntas)
                {
                    HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
                    HtmlGenericControl DivContenedorInterno1 = new HtmlGenericControl("div");
                    HtmlGenericControl DivContenedorInterno2 = new HtmlGenericControl("div");
                    DivContenedor.Attributes.Add("class", "panel panel-default");
                    DivContenedorInterno1.Attributes.Add("class", "panel-heading");
                    DivContenedorInterno2.Attributes.Add("class", "panel-body");
                    DivContenedorInterno1.InnerText = item.Pregunta;
                    DivContenedorInterno2.InnerText = item.Respuesta;
                    DivContenedor.Controls.Add(DivContenedorInterno1);
                    DivContenedor.Controls.Add(DivContenedorInterno2);
                    this.peopleComment.Controls.Add(DivContenedor);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void sendPreguntar_Click(object sender, EventArgs e)
        {
            var CLIENTE = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

            GestorProducto.InsertarPreguntaPersonal(pregunta.Text, CLIENTE);

            pregunta.Text = "";

        }

        protected void btnTracking_Click(object sender, EventArgs e)
        {
            var CLIENTE = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            int NroFactura = int.Parse(row.Cells[0].Text.Trim());
            
            Response.Redirect($"/SeguimientoCompras.aspx?NroFactura={NroFactura}&Usuario={CLIENTE}");

        }
    }
}