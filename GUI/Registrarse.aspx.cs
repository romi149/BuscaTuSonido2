using BE;
using BLL;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendregistrarse_Click(object sender, EventArgs e)
        {
            if(!tyc.Checked)
            {
                Response.Write("<script>alert('Debe aceptar los Términos y Condiciones')</script>");
                return;
            }

            
            if(string.IsNullOrEmpty(email.Text.Trim()))
            {
                Response.Write("<script>alert('Debe ingresar un email')</script>");

            }


            if (IsReCaptchValid())
            {
                Cliente cli = new Cliente();
                cli.Nombre = nombre.Text.Trim();
                cli.Apellido = apellido.Text.Trim();
                cli.Email = email.Text.Trim();
                cli.Telefono = telefono.Text.Trim();
                cli.DomEntrega = domEntrega.Text.Trim();
                cli.DomFacturacion = domFactura.Text.Trim();
                cli.Pass = EnvioEmails.md5(password.Text.Trim());
                cli.Dni = dni.Text.Trim();
                cli.Usuario = username.Text.Trim();

                bool Insertado = GestorCliente.Agregar(cli);

                Usuario user = new Usuario();
                user.User = username.Text.Trim();
                user.Nombre = nombre.Text.Trim();
                user.Apellido = apellido.Text.Trim();
                user.Pass = EnvioEmails.md5(password.Text.Trim());
                user.Estado = EstadoCliente.PENDIENTE;
                user.IdIdioma = 1;
                user.Dni = int.Parse(dni.Text.Trim());

                bool UserNuevo = GestorUsuario.Agregar(user);

                bool Cliente = GestorGestionRoles.AsignarRolCliente(int.Parse(dni.Text.Trim()), 8);

                if (Insertado)
                {
                    GestorBitacora.Agregar(DateTime.Now, "Se inserto un registro", "Cliente", "Cliente");
                    EnvioEmails.EnviarMail(email.Text.Trim(),
                                         $"https://localhost:44328/ConfirmarRegistro.aspx?clave={username.Text.Trim()}&hash={GestorUsuario.RecuperarHashUsuario(username.Text.Trim())}");

                    Response.Write("<script>alert('Se ha enviado un email a su casilla de correo para que confirme su registro')</script>");
                    LimpiarCampos();
                    return;

                }
                else
                    Response.Write("<script>alert('No se pudo realizar el registro, intente nuevamente')</script>");

                //Response.Redirect("~/Login");
            }
            else
            {
                Response.Write("<script>alert('Debe validar el Captcha')</script>");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.close()</script>");
            Response.Redirect("~/Login");
        }

        protected void LimpiarCampos()
        {
            nombre.Text = "";
            apellido.Text = "";
            email.Text = "";
            telefono.Text = "";
            domEntrega.Text = "";
            domFactura.Text = "";
            password.Text = "";
            dni.Text = "";
            username.Text = "";
        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LcGyNwZAAAAABVPkeHH_NAGSM-bf--zru2KvoMO";
            //var secretKey = ConfigurationManager.AppSettings["key"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}