﻿using BE;
using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static BE.GlobalEnv;

namespace GUI
{
    public partial class DescripcionProducto : System.Web.UI.Page
    {
        public Producto ProductoActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string nombre = Request.QueryString["Nombre"]?.ToString();
                string modelo = Request.QueryString["Modelo"]?.ToString();
                var producto = GestorProducto.ListarDetalleProducto(nombre, modelo);
                HtmlGenericControl textoTitulo = new HtmlGenericControl("h1");
                HtmlGenericControl textoTitulo1 = new HtmlGenericControl("h2");
                HtmlGenericControl textoTitulo2 = new HtmlGenericControl("h3");
                HtmlGenericControl textoTitulo3 = new HtmlGenericControl("p");
                HtmlGenericControl textoTitulo4 = new HtmlGenericControl("label");
                textoTitulo4.Attributes.Add("id", "NombreProducto");
                textoTitulo4.Attributes.Add("hidden", "true");
                textoTitulo.InnerHtml = $"{producto.Nombre}";
                textoTitulo1.InnerHtml = $"{producto.Modelo}";
                textoTitulo2.InnerHtml = $"$ {producto.Precio}";
                textoTitulo3.InnerHtml = $"{producto.Descripcion}";
                textoTitulo4.InnerHtml = $"{JsonConvert.SerializeObject(producto)}";
                TxtNombre.Controls.Add(textoTitulo);
                TxtModelo.Controls.Add(textoTitulo1);
                TxtPrecio.Controls.Add(textoTitulo2);
                TxtDescripcion.Controls.Add(textoTitulo3);
                TxtDescripcion.Controls.Add(textoTitulo4);
                this.ImagenProducto.ImageUrl = GestorProducto.GestionImagen(nombre, "sin categoria");
                CargarDatosPreguntas();
                this.ProductoActual = producto;
                this.gvOpinionProducto.DataSource = CargarOpiniones(nombre);
                this.gvOpinionProducto.DataBind();
                var Total = Calcular();
                this.puntajeTotal.Text = $"{Total}";
            }
            catch (Exception error)
            {

                throw error;
            }
            
        }

        private void CargarDatosPreguntas()
        {
            try
            {
                string nombre = Request.QueryString["Nombre"]?.ToString();
                string modelo = Request.QueryString["Modelo"]?.ToString();

                var Preguntas = GestorProducto.ListarPreguntas(nombre,modelo);
                foreach (var item in Preguntas)
                {
                    HtmlGenericControl DivContenedor = new HtmlGenericControl("div");
                    HtmlGenericControl DivContenedorInterno1 = new HtmlGenericControl("div");
                    HtmlGenericControl DivContenedorInterno2 = new HtmlGenericControl("div");
                    DivContenedor.Attributes.Add("class", "panel panel-default");
                    DivContenedorInterno1.Attributes.Add("class", "panel-heading");
                    DivContenedorInterno2.Attributes.Add("class", "panel-body");
                    DivContenedorInterno1.InnerText = item.Pregunta;
                    DivContenedorInterno2.InnerText = item.Respuesta;
                    DivContenedor.Controls.Add(DivContenedorInterno1);
                    DivContenedor.Controls.Add(DivContenedorInterno2);
                    this.peopleComment.Controls.Add(DivContenedor);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void sendPreguntar_Click(object sender, EventArgs e)
        {
            string nombre = Request.QueryString["Nombre"].ToString();
            string modelo = Request.QueryString["Modelo"].ToString();

            var CLIENTE = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";

            if (!string.IsNullOrEmpty(CLIENTE))
            {
                GestorProducto.InsertarPregunta(nombre, modelo, pregunta.Text, CLIENTE);
            }
            else
            {
                Response.Write("<script>alert('Para realizar una pregunta debe iniciar sesión')</script>");
            }

            Response.Redirect($"/DescripcionProducto.aspx?Nombre={nombre}&Modelo={modelo}");

        }

        public DataSet CargarOpiniones(string nombreP)
        {
            return GestorProducto.ObtenerOpionesProducto(nombreP);
        }


        public decimal Calcular()
        {
            string nombre = Request.QueryString["Nombre"]?.ToString();
            var lista = GestorProducto.ListarValoraciones(nombre);
            decimal total = 0;
            decimal totalRetornar = 0;
            
            if(lista.Count != 0)
            {
                foreach (var item in lista)
                {
                    total = total + item.Valoracion;
                }
                
                totalRetornar = total / Convert.ToDecimal(lista.Count);
            }
            else
            {
                totalRetornar = total;
            }

            return totalRetornar;

            
        }

        protected void sendComprar_Click(object sender, EventArgs e)
        {
            string Precio = Request.QueryString["Precio"]?.ToString();
            string nombre = Request.QueryString["Nombre"]?.ToString();
            string modelo = Request.QueryString["Modelo"]?.ToString();

            Response.Redirect($"/FormularioDeCompraDirecta.aspx?Precio={Precio}&Nombre={nombre}");

        }
    }
}