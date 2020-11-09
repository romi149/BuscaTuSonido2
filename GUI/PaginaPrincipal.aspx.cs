using BLL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
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

        public void CheckOfertas_Clicked(object sender, EventArgs e)
        {
            

        }

        protected void CheckEventos_Clicked(object sender, EventArgs e)
        {


        }

        protected void CheckNoticias_Clicked(object sender, EventArgs e)
        {


        }


    }
}