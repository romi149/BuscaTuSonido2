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
    public partial class GestionConsultasClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvConsultas.DataSource = listaDatos;
            this.gvConsultas.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorProducto.EliminarPregunta(int.Parse(Id));

            if (eliminado)

                GestorBitacora.Agregar(DateTime.Now, "Se elimino un registro", "Admin", "GestionPreguntas");
            Response.Write("<script>alert('Se ha eliminado el registro')</script>");

            Response.Redirect("/ABMC-Marca.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string NombreProducto = row.Cells[1].Text.Trim();
            string Modelo = row.Cells[2].Text.Trim();
            string Pregunta = row.Cells[3].Text.Trim();
            string Respuesta = row.Cells[4].Text.Trim();
            string Usuario = row.Cells[5].Text.Trim();
            string Fecha = row.Cells[6].Text.Trim();

            Response.Redirect($"/ResponderConsultas.aspx?Id={Id}&NombreProducto={NombreProducto}&Modelo={Modelo}" +
                $"&Pregunta={Pregunta}&Respuesta={Respuesta}&Usuario={Usuario}&Fecha={Fecha}");
        }

        public DataSet CargarDatos()
        {
            return GestorProducto.ListarTotalPreguntas();
        }


    }
}