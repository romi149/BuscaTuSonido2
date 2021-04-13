﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ABMC_Encuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Encuestas.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvEncuesta.DataSource = listaDatos;
            this.gvEncuesta.DataBind();
            //CargarComboTipo();
        }

        public DataSet CargarDatos()
        {
            return GestorOpinion.ListarTodasEncuestas();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorOpinion.Eliminar(int.Parse(Id));

            if (eliminado)
            {
                Response.Write("<script>alert('Se ha eliminado el registro')</script>");
            }

            Response.Redirect("/ABMC-Encuestas.aspx");

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string NombrePregunta = row.Cells[1].Text.Trim();
            string FechaInicio = row.Cells[2].Text.Trim();
            string FechaFin = row.Cells[3].Text.Trim();
            string Opcion1 = row.Cells[4].Text.Trim();
            string Opcion2 = row.Cells[5].Text.Trim();
            string NombreImg1 = row.Cells[6].Text.Trim();
            string NombreImg2 = row.Cells[7].Text.Trim();

            Server.Transfer($"/EditarEncuesta.aspx?Id={Id}&NombrePregunta={NombrePregunta}&FechaInicio={FechaInicio}&" +
                $"FechaFin={FechaFin}&Opcion1={Opcion1}&Opcion2={Opcion2}&" +
                $"NombreImg1={NombreImg1}&NombreImg2={NombreImg2}");

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            var NroPregunta = 1;
            var NombrePregunta = nombrePregunta.Text.Trim();
            var Tipo = "Encuesta";
            var FechaInicio = fechaInicio.Text.Trim();
            var FechaFin = fechaFin.Text.Trim();
            var Opcion1 = opcion1.Text.Trim();
            var Opcion2 = opcion2.Text.Trim();
            var NombreImg1 = img1.Text.Trim();
            var NombreImg2 = img2.Text.Trim();

            var existe = GestorOpinion.VerificarFechaEncuesta(FechaInicio);
            bool Insertado = false;

            //if(existe != null)
            //{
            //    Response.Write("<script>alert('Ya existe una fecha de inicio para la fecha ingresada, debe ingresar una fecha de inicio superior')</script>");
            //}
            //else
            //{
            if(string.IsNullOrEmpty(NombreImg1) || string.IsNullOrEmpty(NombreImg2))
            {
                Response.Write("<script>alert('Debe ingresar los nombres de las imagenes')</script>");
            }
            else
            {
                Insertado = GestorOpinion.AgregarEncuesta(
                                       NroPregunta,
                                       NombrePregunta,
                                       Tipo,
                                       FechaInicio,
                                       FechaFin,
                                       Opcion1,
                                       Opcion2,
                                       NombreImg1,
                                       NombreImg2);
            }
                
            //}

            if (Insertado)
            {
                Response.Write("<script>alert('La encuesta se agregó correctamente')</script>");

            }

            Response.Redirect("~/ABMC-Encuestas");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Encuestas");
        }

    

        //protected void subirImg_Click(object sender, EventArgs e)
        //{
        //    FileUpload.SaveAs(Server.MapPath(".") + "/Imagenes/Portada");
        //    FileUpload.SaveAs(Server.MapPath(".") + "/Imagenes/Portada");

        //}

    }
}