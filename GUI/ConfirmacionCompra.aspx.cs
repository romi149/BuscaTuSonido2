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
            //Pregunta 1
            if(CheckPreg1Punt1.Checked == true)
            {
                GestorOpinion.Agregar(1, "¿Qué tan fácil te pareció el proceso de compra?", 1,"FichaOpinion");
            }
            else if(CheckPreg1Punt2.Checked == true)
            {
                GestorOpinion.Agregar(1, "¿Qué tan fácil te pareció el proceso de compra?", 2, "FichaOpinion");
            }
            else if(CheckPreg1Punt3.Checked == true)
            {
                GestorOpinion.Agregar(1, "¿Qué tan fácil te pareció el proceso de compra?", 3, "FichaOpinion");
            }
            else if(CheckPreg1Punt4.Checked == true)
            {
                GestorOpinion.Agregar(1, "¿Qué tan fácil te pareció el proceso de compra?", 4, "FichaOpinion");
            }
            else if(CheckPreg1Punt5.Checked == true)
            {
                GestorOpinion.Agregar(1, "¿Qué tan fácil te pareció el proceso de compra?", 5, "FichaOpinion");
            }

            //Pregunta 2
            if (CheckPreg2Punt1.Checked == true)
            {
                GestorOpinion.Agregar(2, "¿Te resultó fácil encontrar el producto que buscabas?", 1, "FichaOpinion");
            }
            else if (CheckPreg2Punt2.Checked == true)
            {
                GestorOpinion.Agregar(2, "¿Te resultó fácil encontrar el producto que buscabas?", 2, "FichaOpinion");
            }
            else if (CheckPreg2Punt3.Checked == true)
            {
                GestorOpinion.Agregar(2, "¿Te resultó fácil encontrar el producto que buscabas?", 3, "FichaOpinion");
            }
            else if (CheckPreg2Punt4.Checked == true)
            {
                GestorOpinion.Agregar(2, "¿Te resultó fácil encontrar el producto que buscabas?", 4, "FichaOpinion");
            }
            else if (CheckPreg2Punt5.Checked == true)
            {
                GestorOpinion.Agregar(2, "¿Te resultó fácil encontrar el producto que buscabas?", 5, "FichaOpinion");
            }


            //Pregunta 3
            if (CheckPreg3Punt1.Checked == true)
            {
                GestorOpinion.Agregar(3, "¿Qué tan satisfecho estás con la disponibilidad de los productos?", 1, "FichaOpinion");
            }
            else if (CheckPreg3Punt2.Checked == true)
            {
                GestorOpinion.Agregar(3, "¿Qué tan satisfecho estás con la disponibilidad de los productos?", 2, "FichaOpinion");
            }
            else if (CheckPreg3Punt3.Checked == true)
            {
                GestorOpinion.Agregar(3, "¿Qué tan satisfecho estás con la disponibilidad de los productos?", 3, "FichaOpinion");
            }
            else if (CheckPreg3Punt4.Checked == true)
            {
                GestorOpinion.Agregar(3, "¿Qué tan satisfecho estás con la disponibilidad de los productos?", 4, "FichaOpinion");
            }
            else if (CheckPreg3Punt5.Checked == true)
            {
                GestorOpinion.Agregar(3, "¿Qué tan satisfecho estás con la disponibilidad de los productos?", 5, "FichaOpinion");
            }


            //Pregunta 4
            if (CheckPreg4Punt1.Checked == true)
            {
                GestorOpinion.Agregar(4, "¿Qué tan probable es que nos recomiendes?", 1, "FichaOpinion");
            }
            else if (CheckPreg4Punt2.Checked == true)
            {
                GestorOpinion.Agregar(4, "¿Qué tan probable es que nos recomiendes?", 2, "FichaOpinion");
            }
            else if (CheckPreg4Punt3.Checked == true)
            {
                GestorOpinion.Agregar(4, "¿Qué tan probable es que nos recomiendes?", 3, "FichaOpinion");
            }
            else if (CheckPreg4Punt4.Checked == true)
            {
                GestorOpinion.Agregar(4, "¿Qué tan probable es que nos recomiendes?", 4, "FichaOpinion");
            }
            else if (CheckPreg4Punt5.Checked == true)
            {
                GestorOpinion.Agregar(4, "¿Qué tan probable es que nos recomiendes?", 5, "FichaOpinion");
            }

            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}