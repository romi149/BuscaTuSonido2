using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ConfirmarRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuario = Request.QueryString["clave"];
            var hash = Request.QueryString["hash"];
            GestorUsuario.ConfirmacionUsuario(usuario, hash);
        }
    }
}