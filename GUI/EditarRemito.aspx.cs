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
    public partial class EditarRemito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboEstados();
            var descAnterior = Session["Descripcion"].ToString();

            if(descAnterior == "&nbsp;")
            {
                if(descripcion.Text == "&nbsp;")
                {
                    descripcion.Text = "";
                }
                
            }
            else
            {
                descripcion.Text = Session["Descripcion"].ToString();
            }
            
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Envios");
        }

        protected void confirmar_Click(object sender, EventArgs e)
        {
            Remito re = new Remito();
            re.NroRemito = int.Parse(Session["NroRemito"].ToString());
            re.Descripcion = descripcion.Text;
            re.Notas = notas.Text;
            re.Estado = listEstado.SelectedItem.ToString();

            bool Generado = GestorRemito.ModificarRemito(re);

            if (Generado)
            {
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                
            }

        }

        public void CargarComboEstados()
        {
            ListItem i;
            i = new ListItem("--- Seleccionar Estado---", "1");
            listEstado.Items.Add(i);
            i = new ListItem("Pendiente", "2");
            listEstado.Items.Add(i);
            i = new ListItem("En espera", "3");
            listEstado.Items.Add(i);
            i = new ListItem("En preparacion", "4");
            listEstado.Items.Add(i);
            i = new ListItem("Despachado", "5");
            listEstado.Items.Add(i);
            i = new ListItem("Entregado", "6");
            listEstado.Items.Add(i);
        }
    }
}