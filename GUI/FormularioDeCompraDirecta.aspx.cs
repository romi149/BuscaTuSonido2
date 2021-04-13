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
    public partial class FormularioDeCompraDirecta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuarioCliente"] == null)
                {
                    Response.Redirect("Login");
                }
                else
                {
                    string producto = Request.QueryString["Nombre"]?.ToString();
                    string precio = GestorProducto.ObtenerPrecioProducto(producto);
                    this.PrecioCompra.Text = precio;
                    
                    var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

                    var ImporteNC = GestorNC.ObtenerImporteNC(UserCliente);
                    double Total = double.Parse(precio);

                    if (ImporteNC != null && ImporteNC.Count != 0)
                    {
                        double nc = double.Parse(ImporteNC[0].Importe);
                        double aPagar = Total - nc;
                        CargarComboNotaCredito(UserCliente);
                        precioAPagar.Text = aPagar.ToString();
                    }
                }
            }
            else
            {
                string producto = Request.QueryString["Nombre"]?.ToString();
                string Total = GestorProducto.ObtenerPrecioProducto(producto);
                
                var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

                var ImporteNC = GestorNC.ObtenerImporteNC(UserCliente);

                if (ImporteNC.Count != 0)
                {
                    double total = double.Parse(Total);
                    double nc = double.Parse(ImporteNC[0].Importe);
                    double aPagar = total - nc;

                    var opcionNC = Constantes.SeleccionarNC;

                    if (listNotaCred.SelectedValue != opcionNC)
                    {
                        precioAPagar.Text = aPagar.ToString();
                    }
                    else
                    {
                        precioAPagar.Text = Total;
                    }
                }
                else
                {
                    precioAPagar.Text = Total;
                }

                //Session["Precio"] = null;
                //string NombreProd = (string)Session["Nombre"];
                string NombreProd = Request.QueryString["Nombre"];
                ConfirmarCompra(NombreProd, precioAPagar.Text);

            }

        }

        public void ConfirmarCompra(string Nombre, string Total)
        {
            var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
            try
            {
                //var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
                var NPGenerada = GestorNP.AgregarNP(UserCliente, Total);
                var nroNC = GestorNC.ObtenerNC(UserCliente);
                if (NPGenerada)
                {
                    var NP = GestorNP.ObtenerNP(UserCliente, Total);
                    GestorNP.ModificarEstado(NP, "Cobrado");

                    GestorNP.AgregarProdNP(NP, Nombre);
                    GestorNP.AgregarDetalle(NP, Nombre);

                    NotaCredito nc = new NotaCredito();
                    nc.Estado = "Aplicado";
                    nc.NroNotaC = nroNC[0].NroNotaC;

                    if (nroNC.Count != 0)
                    {
                        GestorNC.ModificarEstadoNC(nc);
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default");

            }
            var email = GestorCliente.ObtenerEmailCliente(UserCliente);
            EnvioEmails.EnviarMailConfirmacionCompra(email.Email, "");
            Response.Redirect("ConfirmacionCompra");

        }

        public void CargarComboNotaCredito(string usuario)
        {
            List<NotaCredito> lista = GestorNC.ObtenerImporteNC(usuario);
            lista.Insert(0, new NotaCredito { Importe = Constantes.SeleccionarNC });
            listNotaCred.DataSource = lista;
            listNotaCred.DataTextField = "Importe";
            listNotaCred.DataValueField = "Importe";
            listNotaCred.DataBind();

        }

    }
    
}