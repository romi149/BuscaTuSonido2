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
    public partial class ConfirmacionCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script> localStorage.clear()</script>");

        }

        protected void btnOpinar_Click(object sender, EventArgs e)
        {
            Opinion op = new Opinion();

            //Pregunta 1
            
            if (CheckPreg1Punt1.Checked == true)
            {
                op.NroPregunta = 1;
                op.NombrePregunta = "¿Qué tan fácil te pareció el proceso de compra?";
                op.Puntuacion = 1;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if(CheckPreg1Punt2.Checked == true)
            {
                op.NroPregunta = 1;
                op.NombrePregunta = "¿Qué tan fácil te pareció el proceso de compra?";
                op.Puntuacion = 2;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if(CheckPreg1Punt3.Checked == true)
            {
                op.NroPregunta = 1;
                op.NombrePregunta = "¿Qué tan fácil te pareció el proceso de compra?";
                op.Puntuacion = 3;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if(CheckPreg1Punt4.Checked == true)
            {
                op.NroPregunta = 1;
                op.NombrePregunta = "¿Qué tan fácil te pareció el proceso de compra?";
                op.Puntuacion = 4;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if(CheckPreg1Punt5.Checked == true)
            {
                op.NroPregunta = 1;
                op.NombrePregunta = "¿Qué tan fácil te pareció el proceso de compra?";
                op.Puntuacion = 5;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }

            //Pregunta 2
            if (CheckPreg2Punt1.Checked == true)
            {
                op.NroPregunta = 2;
                op.NombrePregunta = "¿Te resultó fácil encontrar el producto que buscabas?";
                op.Puntuacion = 1;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg2Punt2.Checked == true)
            {
                op.NroPregunta = 2;
                op.NombrePregunta = "¿Te resultó fácil encontrar el producto que buscabas?";
                op.Puntuacion = 2;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg2Punt3.Checked == true)
            {
                op.NroPregunta = 2;
                op.NombrePregunta = "¿Te resultó fácil encontrar el producto que buscabas?";
                op.Puntuacion = 3;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg2Punt4.Checked == true)
            {
                op.NroPregunta = 2;
                op.NombrePregunta = "¿Te resultó fácil encontrar el producto que buscabas?";
                op.Puntuacion = 4;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg2Punt5.Checked == true)
            {
                op.NroPregunta = 2;
                op.NombrePregunta = "¿Te resultó fácil encontrar el producto que buscabas?";
                op.Puntuacion = 5;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }


            //Pregunta 3
            if (CheckPreg3Punt1.Checked == true)
            {
                op.NroPregunta = 3;
                op.NombrePregunta = "¿Qué tan satisfecho estás con la disponibilidad de los productos?";
                op.Puntuacion = 1;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg3Punt2.Checked == true)
            {
                op.NroPregunta = 3;
                op.NombrePregunta = "¿Qué tan satisfecho estás con la disponibilidad de los productos?";
                op.Puntuacion = 2;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg3Punt3.Checked == true)
            {
                op.NroPregunta = 3;
                op.NombrePregunta = "¿Qué tan satisfecho estás con la disponibilidad de los productos?";
                op.Puntuacion = 3;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg3Punt4.Checked == true)
            {
                op.NroPregunta = 3;
                op.NombrePregunta = "¿Qué tan satisfecho estás con la disponibilidad de los productos?";
                op.Puntuacion = 4;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg3Punt5.Checked == true)
            {
                op.NroPregunta = 3;
                op.NombrePregunta = "¿Qué tan satisfecho estás con la disponibilidad de los productos?";
                op.Puntuacion = 5;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }


            //Pregunta 4
            if (CheckPreg4Punt1.Checked == true)
            {
                op.NroPregunta = 4;
                op.NombrePregunta = "¿Qué tan probable es que nos recomiendes?";
                op.Puntuacion = 1;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg4Punt2.Checked == true)
            {
                op.NroPregunta = 4;
                op.NombrePregunta = "¿Qué tan probable es que nos recomiendes?";
                op.Puntuacion = 2;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg4Punt3.Checked == true)
            {
                op.NroPregunta = 4;
                op.NombrePregunta = "¿Qué tan probable es que nos recomiendes?";
                op.Puntuacion = 3;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg4Punt4.Checked == true)
            {
                op.NroPregunta = 4;
                op.NombrePregunta = "¿Qué tan probable es que nos recomiendes?";
                op.Puntuacion = 4;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }
            else if (CheckPreg4Punt5.Checked == true)
            {
                op.NroPregunta = 4;
                op.NombrePregunta = "¿Qué tan probable es que nos recomiendes?";
                op.Puntuacion = 5;
                op.Tipo = "FichaOpinion";
                GestorOpinion.Agregar(op);
            }

            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}