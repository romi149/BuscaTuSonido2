using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class FormularioDeCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioCliente"] == null)
            {
                Response.Redirect("Login");

            }
            else
            {
                string Nombre = Request.QueryString["Nombre"]?.ToString();
                string total = Request.QueryString["total"]?.ToString();
                this.PrecioCompra.Text = total;


            }
        }

        public void ConfirmarCompra()
        {
            var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
            string total = Request.QueryString["total"]?.ToString();

            var NPGenerada = GestorNP.Agregar(UserCliente, total);

            if (NPGenerada)
            {
                var NP = GestorNP.ObtenerNP(UserCliente, total);




            }

        }
    }
}