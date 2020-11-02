using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void CargarDatos()
        {
            var DNI = "32123321";
            var EMAIL = "romi.caste@gmail.com";

            int cont = 0;

            foreach (var item in GestorCliente.ObtenerDatosCliente(DNI,EMAIL))
            {
                username.Text = item.Usuario;
                nombre.Text = item.Nombre;
                apellido.Text = item.Apellido;
                email.Text = item.Email;
                dni.Text = (item.Dni).ToString();
                telefono.Text = item.Telefono;
                domEntrega.Text = item.DomEntrega;
                domFactura.Text = item.DomFacturacion;

                cont++;
            }
        }


        protected void sendeditar_Click(object sender, EventArgs e)
        {
            
            bool Modificado = GestorCliente.Actualizar (
                                        int.Parse(codCliente.Text.Trim()),
                                        nombre.Text.Trim(),
                                        apellido.Text.Trim(),
                                        email.Text.Trim(),
                                        telefono.Text.Trim(),
                                        domEntrega.Text.Trim(),
                                        domFactura.Text.Trim(),
                                        dni.Text.Trim(),
                                        username.Text.Trim());

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "Cliente", "Cliente");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }




        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.close()</script>");
            Response.Redirect("~/MiCuenta");
        }

        protected void sendcambiarPass_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.close()</script>");
            Response.Redirect("~/RecuperoPass");
        }
    }
}