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
            var idUser = Request.QueryString["IdUsuario"].ToString();

            bool eliminado = GestorUsuario.Eliminar(int.Parse(idUser));

            if(eliminado)
            
                Response.Write("alert('Se ha eliminado el usuario')");
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        public DataSet CargarDatos()
        {
            return GestorUsuario.Listar();
        }
    }
}