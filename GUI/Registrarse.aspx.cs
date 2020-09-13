using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendregistrarse_Click(object sender, EventArgs e)
        {

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}