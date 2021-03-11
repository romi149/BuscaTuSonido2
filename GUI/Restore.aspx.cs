using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Restore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "Restore.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //btnFileUpload.SaveAs(Server.MapPath(".") + "/backup");

        }

        protected void restore_Click(object sender, EventArgs e)
        {
            var ruta = @"C:\\Backup";

            bool realizado = GestorBackup.RealizarRestore(ruta);
            //btnFileUpload.SaveAs(Server.MapPath(".") + "/backup");


        }
    }
}