using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class FacturasEmitidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            //Habilita el campo Detalle para ingresar el motivo de la anulación y luego
            //Generar NC (crear registro en tabla NotaCredito) y modificar el estado de la factura a Anulado
        }
    }
}