using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ABMC_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvUsuarios.DataSource = listaDatos;
            this.gvUsuarios.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorUsuario.Eliminar(int.Parse(Id));

            if (eliminado)

                Response.Write("<script>alert('Se ha eliminado el usuario')</script>");

            Response.Redirect("/ABMC-Usuarios.aspx");

            //Console.WriteLine(Id);
            //string customerId = row.Cells[0].Text.Trim();
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            //BindGridView();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string Usuario = row.Cells[1].Text.Trim();
            string Nombre = row.Cells[2].Text.Trim();
            string Apellido = row.Cells[3].Text.Trim();
            string Password = row.Cells[4].Text.Trim();
            string Dni = row.Cells[5].Text.Trim();
            string Estado = row.Cells[6].Text.Trim();

            Response.Redirect($"/EditarUsuario.aspx?Id={Id}&Usuario={Usuario}&Nombre={Nombre}&Apellido={Apellido}&Password{Password}&Dni={Dni}&Estado={Estado}");
        }

        public DataSet CargarDatos()
        {
            return GestorUsuario.Listar();
        }
    }
}