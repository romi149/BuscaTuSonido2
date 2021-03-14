using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "Backup.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }
        }

        protected void generar_Click(object sender, EventArgs e)
        {
            //FileUpload.SaveAs(Server.MapPath(".") + "/Imagenes/Catalogo/Cuerdas");

            var destino = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQL2019\\MSSQL\\Backup\\";

            var generado = GestorBackup.RealizarBackup(destino);

            if(generado)
            {
                Response.Write("<script>alert('El backup se realizo correctamente')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo realizar el backup')</script>");
            }

        }
    }
}