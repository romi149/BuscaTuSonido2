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
    public partial class ValoracionProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void sendconfirmar_Click(object sender, EventArgs e)
        {
            var Comentario = comentario.Text;
            int puntaje = 0;

            if(CheckPunt1.Checked == true)
            {
                puntaje = 1;
            }
            else if(CheckPunt2.Checked == true)
            {
                puntaje = 2;
            }
            else if(CheckPunt3.Checked == true)
            {
                puntaje = 3;
            }
            else if (CheckPunt4.Checked == true)
            {
                puntaje = 4;
            }
            else if (CheckPunt5.Checked == true)
            {
                puntaje = 5;
            }


            var Usuario = $"{((BE.Usuario)Session["usuarioCliente"])?.User}";
            var IDCliente = GestorCliente.ObtenerCodCliente(Usuario);
            var NroNP = Request.QueryString["NroNP"];

            var Productos = GestorNP.ListarProdxNP(int.Parse(NroNP));

            foreach (var item in Productos)
            {
                
                GestorProducto.AgregarValoracion(puntaje,Comentario, 
                                                IDCliente.CodCliente, 
                                                item.Nombre,
                                                Usuario);
            }

            Response.Write("<script>alert('Muchas gracias por sus comentarios')</script>");

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MisCompras.aspx");
        }
    }
}