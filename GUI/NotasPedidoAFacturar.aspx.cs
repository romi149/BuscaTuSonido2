using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class NotasPedidoAFacturar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            //Generar factura (crear registro en tabla Factura) 
            //y modificar el estado de la NP a Facturado
        }
    }
}