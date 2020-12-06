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

        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Envios");
        }

        protected void confirmar_Click(object sender, EventArgs e)
        {
            var NroRemito = Session["NroRemito"].ToString();
            var Descripcion = descripcion.Text;
            var Notas = notas.Text;
            var Estado = estado.Text;

            bool Generado = GestorRemito.ModificarRemito(int.Parse(NroRemito), 
                                                        Descripcion, 
                                                        Notas, 
                                                        Estado);

            if (Generado)
            {
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
            }

        }
    }
}