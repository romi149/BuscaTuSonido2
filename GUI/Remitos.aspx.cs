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
    public partial class Remitos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvRemitos.DataSource = listaDatos;
            this.gvRemitos.DataBind();

        }

        public DataSet CargarDatos()
        {
            return GestorRemito.Listar();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
        }
    }
}