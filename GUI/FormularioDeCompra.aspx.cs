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
                    {
                        Session["ProductosActuales"] = Request.QueryString["Nombre"]?.ToString();
                    }
    
                    this.PrecioCompra.Text = Request.QueryString["total"]?.ToString();
                    Session["Total"] = Request.QueryString["total"].ToString();
                    string Total = (string)Session["Total"];
                    var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

                    var ImporteNC = GestorNC.ObtenerImporteNC(UserCliente);
                    double total = double.Parse(Total);
                   
                    if (ImporteNC != null && ImporteNC.Count != 0)
                    {
                        double nc = double.Parse(ImporteNC[0].Importe);
                        double aPagar = total - nc;
                        CargarComboNotaCredito(UserCliente);
                        precioAPagar.Text = aPagar.ToString();
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty((string)Session["ProductosActuales"])
                    || string.IsNullOrEmpty((string)Session["Total"]))
                {
                    Response.Redirect("Default");
                }
                    
                string Productos = (string)Session["ProductosActuales"];
                string Total = (string)Session["Total"];
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

                Session["ProductosActuales"] = null;
                Session["Total"] = null;
                ConfirmarCompra(Productos, precioAPagar.Text);

            }

        }

        public void ConfirmarCompra(string Nombre, string Total)
        {
            var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
            try
            {
                //var UserCliente = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
                Nombre = Nombre.TrimEnd(',');
                var Productos = new List<string>(Nombre.Split(','));

                var NPGenerada = GestorNP.AgregarNP(UserCliente, Total);
                var nroNC = GestorNC.ObtenerNC(UserCliente);

                if (NPGenerada)
                {
                    var NP = GestorNP.ObtenerNP(UserCliente, Total);
                    GestorNP.ModificarEstado(NP, "Cobrado");
                    //string nombreProd = "";
                    string cadena = "";
                    
                    foreach (var item in Productos)
                    {
                        GestorNP.AgregarProdNP(NP, item);

                        //nombreProd = nombreProd + item.Split(',');
                        cadena = string.Join(",", Productos.ToArray());
                    }

                   
                    GestorNP.AgregarDetalle(NP, cadena);

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
            EnvioEmails.EnviarMailConfirmacionCompra(email.Email,"");
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

        protected void listNotaCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}