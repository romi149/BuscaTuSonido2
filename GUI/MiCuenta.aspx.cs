using BE;
using BLL;
using Microsoft.Ajax.Utilities;
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
            var DNI = $"{((BE.Usuario)Session["usuarioCliente"])?.Dni}";
            var NOMBRE = $"{((BE.Usuario)Session["usuarioCliente"])?.Nombre}";
            
            int cont = 0;

            foreach (var item in GestorCliente.ObtenerDatosCliente(DNI,NOMBRE))
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
            Cliente cli = new Cliente();
            cli.CodCliente = int.Parse(codCliente.Text.Trim());
            cli.Nombre = nombre.Text.Trim();
            cli.Apellido = apellido.Text.Trim();
            cli.Email = email.Text.Trim();
            cli.Telefono = telefono.Text.Trim();
            cli.DomEntrega = domEntrega.Text.Trim();
            cli.DomFacturacion = domFactura.Text.Trim();
            cli.Dni = dni.Text.Trim();
            cli.Usuario = username.Text.Trim();

            bool Modificado = GestorCliente.Actualizar (cli);

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
            Response.Redirect("~/MiCuenta.aspx");
        }

        protected void sendvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PaginaPrincipal.aspx");
        }
        protected void sendcambiarPass_Click(object sender, EventArgs e)
        {
            password.Visible = true;
            repeatPass.Visible = true;
            confirmarPass.Visible = true;
            cancelar.Visible = true;

        }

        protected void confirmarCambioPass_Click(object sender, EventArgs e)
        {
            var Iduser = $"{((BE.Usuario)Session["usuarioCliente"])?.IdUsuario}";
            var nombreUser = $"{((BE.Usuario)Session["usuarioCliente"])?.Nombre}";

            if (password.Text == repeatPass.Text)
            {
                Cliente cli = new Cliente();
                cli.Pass = EnvioEmails.md5(password.Text.Trim());
                cli.CodCliente = int.Parse(codCliente.Text.Trim());

                Usuario user = new Usuario();
                user.IdUsuario = int.Parse(Iduser);
                user.Pass = EnvioEmails.md5(password.Text.Trim());
                
                
                bool modificadoCli = GestorCliente.ModificarPassCliente(user, cli);


                bool modidificadoUs = GestorUsuario.ModificarPass(user);

                if (modificadoCli && modidificadoUs)
                {
                    EnvioEmails.EnviarMailConfirmacionCambioPass(email.Text.Trim(),"");
                    GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", nombreUser, "Cliente");
                    Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('Las contraseñas no coinciden')</script>");
            }
        }


    }
}