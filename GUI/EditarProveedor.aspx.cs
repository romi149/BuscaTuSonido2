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
    public partial class Editar_Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            idProv.Text = Request.QueryString["IdProveedor"].ToString();
            codProv.Text = Request.QueryString["CodProveedor"].ToString();
            nombreEmpresa.Text = Request.QueryString["NombreEmpresa"].ToString();
            razonSocial.Text = Request.QueryString["RazonSocial"].ToString();
            domicilio.Text = Request.QueryString["Domicilio"].ToString();
            email.Text = Request.QueryString["Email"].ToString();
            telefono.Text = Request.QueryString["Telefono"].ToString();
            descrip.Text = Request.QueryString["Descripcion"].ToString();
            cuit.Text = Request.QueryString["Cuit"].ToString();
            
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.IdProveedor = int.Parse(idProv.Text.Trim());
            prov.CodProveedor = codProv.Text.Trim();
            prov.NombreEmpresa = nombreEmpresa.Text.Trim();
            prov.RazonSocial = razonSocial.Text.Trim();
            prov.Domicilio = domicilio.Text.Trim();
            prov.Email = email.Text.Trim();
            prov.Telefono = telefono.Text.Trim();
            prov.Descripcion = descrip.Text.Trim();
            prov.Cuit = cuit.Text.Trim();

            bool Modificado = GestorProveedor.Modificar(prov);

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