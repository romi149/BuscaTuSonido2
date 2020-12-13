using BLL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
		private const string mensaje = "{menssage:Usted ha enviado} ";
		
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendSuscribirse_Click(object sender, EventArgs e)
        {
            bool Insertado = false;
            
            if(string.IsNullOrEmpty(email.Text.Trim()))
            {
                Response.Write("<script>alert('¡Debe ingresar un email!')</script>");

            }

            if (!CheckOfertas.Checked)
            {
                if (!CheckEventos.Checked)
                {
                    if(!CheckNoticias.Checked)
                    {
                        Response.Write("<script>alert('¡Debe elegir al menos una categoría!')</script>");
                    }
                }
            }

            if (CheckOfertas.Checked)
            {
                if (CheckEventos.Checked)
                {
                    if (CheckNoticias.Checked)
                    {
                        Insertado = GestorSuscripcion.Agregar(
                                       email.Text.Trim(),
                                       "",
                                       "Activo",
                                       true,
                                       true,
                                       true);
                    }
                    else
                    {
                        Insertado = GestorSuscripcion.Agregar(
                                       email.Text.Trim(),
                                       "",
                                       "Activo",
                                       true,
                                       true,
                                       false);
                    }

                }
                else if (CheckNoticias.Checked)
                {
                    Insertado = GestorSuscripcion.Agregar(
                                       email.Text.Trim(),
                                       "",
                                       "Activo",
                                       true,
                                       false,
                                       true);
                }
            }
            else if (CheckEventos.Checked)
            {
                if (CheckNoticias.Checked)
                {
                    Insertado = GestorSuscripcion.Agregar(
                               email.Text.Trim(),
                               "",
                               "Activo",
                               false,
                               true,
                               true);
                }
                else 
                {
                    Insertado = GestorSuscripcion.Agregar(
                                   email.Text.Trim(),
                                   "",
                                   "Activo",
                                   false,
                                   true,
                                   false);
                }
            }
            else if(CheckNoticias.Checked)
            {
                Insertado = GestorSuscripcion.Agregar(
                                   email.Text.Trim(),
                                   "",
                                   "Activo",
                                   false,
                                   false,
                                   true);
            }
        

            if (Insertado)
            {
                Response.Write("<script>alert('¡Suscripción realizada con éxito!')</script>");

                email.Text = "";
                CheckOfertas.Checked = false;
                CheckEventos.Checked = false;
                CheckNoticias.Checked = false;
                suscribirse.Visible = false;
                

                return;
            }

        }

        protected void opcionSuscribirse_Click(object sender, EventArgs e)
        {
            email.Visible = true;
            suscribirse.Visible = true;
            CheckOfertas.Visible = true;
            CheckEventos.Visible = true;
            CheckNoticias.Visible = true;
            desuscribirse.Visible = false;
        }

        protected void opcionDesuscribirse_Click(object sender, EventArgs e)
        {
            email.Visible = true;
            desuscribirse.Visible = true;
            motivo.Visible = true;
            suscribirse.Visible = false;
        }

        protected void sendDesuscribirse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(motivo.Text.Trim()))
            {
                Response.Write("<script>alert('¡Debe ingresar un motivo!')</script>");
            }

            if (string.IsNullOrEmpty(email.Text.Trim()))
            {
                Response.Write("<script>alert('¡Debe ingresar un email!')</script>");
            }

            bool Eliminado = GestorSuscripcion.Eliminar(email.Text.Trim(), motivo.Text.Trim());

            if (Eliminado)
            {
                Response.Write("<script>alert('¡Su suscripción se ha cancelado correctamente!')</script>");
                email.Visible = false;
                desuscribirse.Visible = false;
                motivo.Visible = false;
                suscribirse.Visible = false;
            }

        }
		
		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static EncuestaDelDia CargarEncuestaDeDia()
        {
            //cargar Encuesta del dia
            var Encuestas = GestorOpinion.ListarEncuestas();
            var respuesta1 = Encuestas[0].Opcion1;
            var respuesta2 = Encuestas[0].Opcion2;
            var imagen1 = Encuestas[0].UrlOpcion1;
            var imagen2 = Encuestas[0].UrlOpcion2;
            
            EncuestaDelDia encuesta = new EncuestaDelDia
            {
                titulo = Encuestas[0].NombrePregunta,
                
                Respuesta = new List<Respuestas>
                {
                    new Respuestas{imagen=imagen1,Texto=respuesta1},
                    new Respuestas{imagen=imagen2,Texto=respuesta2},
                }
            };


            return encuesta;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public static ValoresPorcentuales Votar(string Voto)
        {
            var Encuestas = GestorOpinion.ListarEncuestas();
            var IdEncuesta = Encuestas[0].Id;
            var Punt1 = GestorOpinion.ObtenerPuntaje1(IdEncuesta);
            var Punt2 = GestorOpinion.ObtenerPuntaje2(IdEncuesta);

            //realizar un store que devuelva ambos valores
            return new ValoresPorcentuales { Valor1 = Punt1, Valor2 = Punt2 };
        }

        public void CheckOfertas_Clicked(object sender, EventArgs e)
        {

        }
        protected void CheckEventos_Clicked(object sender, EventArgs e)
        {

        }
        protected void CheckNoticias_Clicked(object sender, EventArgs e)
        {

        }

        //protected void pub_Load(object sender, EventArgs e)
        //{
        //    var listaPublicidad = GestorPublicidad.ListarActuales();
        //    var imagPub1 = listaPublicidad[0].ImageUrl;
        //    var navPub1 = listaPublicidad[0].NavigateUrl;
        //    var imagPub2 = listaPublicidad[1].ImageUrl;
        //    var navPub2 = listaPublicidad[1].NavigateUrl;
        //    var imagPub3 = listaPublicidad[2].ImageUrl;
        //    var navPub3 = listaPublicidad[2].NavigateUrl;

        //    //var publicidad = "
        //    //    <?xml version=\"1.0\" encoding="\utf-8\" ?>
        //    //    <Advertisements>
	       //    //     <Ad>
		      //    //      <ImageUrl>http://www.uai.edu.ar/images/uai-logo.gif</ImageUrl>
		      //    //      <NavigateUrl>http://uai.edu.ar/</NavigateUrl>
		      //    //      <AlternateText>No se encontró la imagen</AlternateText>
		      //    //      <Keyword>Computers</Keyword>
	       //    //     </Ad>
	       //    //     <Ad>
		      //    //      <ImageUrl>http://www.uaisoft.uai.edu.ar/imagen/Cabeza1.JPG</ImageUrl>
		      //    //      <NavigateUrl>http://uai.edu.ar/C/</NavigateUrl>
		      //    //      <AlternateText>No se encontró la imagen</AlternateText>
		      //    //      <Keyword>Computers</Keyword>
		      //    //      <Impressions>80</Impressions>
	       //    //     </Ad>
	       //    //     <Ad>
		      //    //      <ImageUrl>http://www.vaneduc.edu.ar/assets/img/uai.png</ImageUrl>
		      //    //      <NavigateUrl>http://www.uai.edu.ar/</NavigateUrl>
		      //    //      <AlternateText>No se encontró la imagen</AlternateText>
		      //    //      <Keyword>Computers</Keyword>
		      //    //      <Impressions>80</Impressions>
	       //    //     </Ad>
        //    //        </Advertisements>";
        //}
    }



    public class EncuestaDelDia
    {
        public string titulo { get; set; }
        public List<Respuestas> Respuesta { get; set; }
    }



    public class Respuestas
    {
        public string Texto { get; set; }
        public string imagen { get; set; }
    }

    public class ValoresPorcentuales
    {
        public int  Valor1{ get; set; }
        public int  Valor2{ get; set; }
    }
}