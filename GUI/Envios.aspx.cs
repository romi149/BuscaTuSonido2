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
    public partial class Envios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "Envios.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvRemitos.DataSource = listaDatos;
            this.gvRemitos.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorRemito.ListarEnviosPendientes();
        }

        protected void editar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string NroRemito = row.Cells[0].Text.Trim();
            
            Session["NroRemito"] = NroRemito;
            

        }

        protected void anular_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string NroRemito = row.Cells[0].Text.Trim();

            GestorRemito.AnularRemito(int.Parse(NroRemito));

        }
    }
}