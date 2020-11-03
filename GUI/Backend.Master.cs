using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Backend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioBackEnd"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session["usuarioBackEnd"] = null;
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}