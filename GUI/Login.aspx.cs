using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendlogin_Click(object sender, EventArgs e)
        {
            GestorUsuario.ObtenerUsuario(username.Text.Trim(), password.Text.Trim());
           
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }


        
    }
    
}