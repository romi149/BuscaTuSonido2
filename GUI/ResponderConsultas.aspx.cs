using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ResponderConsultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string Id = Request.QueryString["Id"].ToString();
            string NombreProducto = Request.QueryString["NombreProducto"].ToString();
            string Modelo = Request.QueryString["Modelo"].ToString();
            string Usuario = Request.QueryString["Usuario"].ToString();
            string Fecha = Request.QueryString["Fecha"].ToString();
            string Pregunta = Request.QueryString["Pregunta"].ToString();
            string Respuesta = Request.QueryString["Respuesta"].ToString();

            id.Text = Id;
            nombreProd.Text = NombreProducto;
            modelo.Text = Modelo;
            usuario.Text = Usuario;
            fecha.Text = Fecha;
            pregunta.Text = Pregunta;
            respuesta.Text = Respuesta;
        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            var userbk = Session["usuariobackend"].ToString();

            bool Modificado = GestorProducto.AgregarRespuesta(int.Parse(id.Text.Trim()),
                                                              respuesta.Text.Trim());

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se agregó una respuesta al cliente", userbk, "Cliente");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionConsultasClientes");
        }
    }
}