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

                HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
                HtmlGenericControl DivInterno = new HtmlGenericControl("div");
                HtmlGenericControl DivBody = new HtmlGenericControl("div");
                DivContenedor.Attributes.Add("class", "panel panel-default container");
                DivInterno.Attributes.Add("class", "panel-heading");
                DivBody.Attributes.Add("class", "panel-body");
                DivInterno.InnerText = "Chat con el vendedor";
                var Preguntas = GestorProducto.ListarPreguntasCliente(UserCliente);
                foreach (var item in Preguntas)
                    DivBody.InnerHtml += $"<p ><span class='preguntaCliente'>{item.Pregunta}</span></p>" +
                                        $"<p ><span class='respuestaCliente'>{item.Respuesta}</span></p>";

                DivContenedor.Controls.Add(DivInterno);
                DivContenedor.Controls.Add(DivBody);
                this.peopleComment.Controls.Add(DivContenedor);
            }
            catch (Exception e)
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
            var EstadoRemito = "";
            int NroRemito = GestorRemito.VerificarRemito(NroFactura);

            if (NroRemito != 0)
            {
                EstadoRemito = GestorRemito.ObtenerEstado(NroFactura);
            }
            else
            {
                EstadoRemito = "NoExiste";
            }
            
            Response.Redirect($"/SeguimientoCompras.aspx?NroFactura={NroFactura}&Usuario={CLIENTE}&EstadoRemito={EstadoRemito}");

        }
       
    }
}