using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Editar_Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string IdProveedor = Request.QueryString["IdProveedor"].ToString();
            string CodProv = Request.QueryString["CodProveedor"].ToString();
            string NombreEmp = Request.QueryString["NombreEmpresa"].ToString();
            string RazonS = Request.QueryString["RazonSocial"].ToString();
            string Domi = Request.QueryString["Domicilio"].ToString();
            string Email = Request.QueryString["Email"].ToString();
            string Telefono = Request.QueryString["Telefono"].ToString();
            string Descrip = Request.QueryString["Descripcion"].ToString();
            string Cuit = Request.QueryString["Cuit"].ToString();

            idProv.Text = IdProveedor;
            codProv.Text = CodProv;
            nombreEmpresa.Text = NombreEmp;
            razonSocial.Text = RazonS;
            domicilio.Text = Domi;
            email.Text = Email;
            telefono.Text = Telefono;
            descrip.Text = Descrip;
            cuit.Text = Cuit;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorProveedor.Modificar(
                                       int.Parse(idProv.Text.Trim()), 
                                       codProv.Text.Trim(),
                                       nombreEmpresa.Text.Trim(),
                                       razonSocial.Text.Trim(),
                                       domicilio.Text.Trim(),
                                       email.Text.Trim(),
                                       telefono.Text.Trim(),
                                       descrip.Text.Trim(),
                                       cuit.Text.Trim());

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "RespCompras", "Proveedor");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Proveedores");
        }
    }
}