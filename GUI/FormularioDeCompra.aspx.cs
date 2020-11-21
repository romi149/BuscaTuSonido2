using BE;
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
                var respuesta = Request.QueryString.ToString();
                this.PrecioCompra.Text = total;

                if(respuesta != null)
                {
                    ConfirmarCompra();
                }
            }
        }

        public void ConfirmarCompra()
        {
            var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
            string Nombre = Request.QueryString["Nombre"]?.ToString();
            string total = Request.QueryString["total"]?.ToString();
            Nombre = Nombre.TrimEnd(',');
            var Productos = new List<string>(Nombre.Split(','));

            var NPGenerada = GestorNP.AgregarNP(UserCliente, total);

            if (NPGenerada)
            {
                var NP = GestorNP.ObtenerNP(UserCliente, total);

                 foreach(var item in Productos)
                {
                    GestorNP.AgregarProdNP(NP, item);
                }

            }

        }
    }
}