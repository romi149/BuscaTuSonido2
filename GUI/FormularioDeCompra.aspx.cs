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
            if (!IsPostBack)
            {
                if (Session["usuarioCliente"] == null)
                {
                    Session["ProductosActuales"] = null;
                    Response.Redirect("Login");
                }
                else
                {
                    if (Session["ProductosActuales"] == null || (string)Session["ProductosActuales"] == "")

                        Session["ProductosActuales"] = Request.QueryString["Nombre"]?.ToString();

                    this.PrecioCompra.Text = Request.QueryString["total"]?.ToString();
                    Session["Total"] = Request.QueryString["total"].ToString();
                }
            }
            else
            {
                if (string.IsNullOrEmpty((string)Session["ProductosActuales"])
                    || string.IsNullOrEmpty((string)Session["Total"]))
                    Response.Redirect("Default");

                string Productos = (string)Session["ProductosActuales"];
                string Total = (string)Session["Total"];
                Session["ProductosActuales"] = null;
                Session["Total"] = null;
                ConfirmarCompra(Productos, Total);

            }

        }

        public void ConfirmarCompra(string Nombre, string Total)
        {
            try
            {
                var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
                Nombre = Nombre.TrimEnd(',');
                var Productos = new List<string>(Nombre.Split(','));
                var NPGenerada = GestorNP.AgregarNP(UserCliente, Total);

                if (NPGenerada)
                {
                    var NP = GestorNP.ObtenerNP(UserCliente, Total);
                    GestorNP.ModificarEstado(NP, "Cobrado");

                    foreach (var item in Productos)
                    {
                        GestorNP.AgregarProdNP(NP, item);
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default");

            }
            
            Response.Redirect("ConfirmaciónCompra");
            

        }

    }
}