using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ABMC_Menus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Menus.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvMenus.DataSource = listaDatos;
            this.gvMenus.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorMenu.Eliminar(int.Parse(Id));

            if (eliminado)

                GestorBitacora.Agregar(DateTime.Now, "Se elimino un registro", "Admin", "Menu");
            Response.Write("<script>alert('Se ha eliminado el menu')</script>");

            Response.Redirect("/ABMC-Menus.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string Nombre = row.Cells[1].Text.Trim();
            string Descripcion = row.Cells[2].Text.Trim();
            string Ubicacion = row.Cells[3].Text.Trim();
            
            Response.Redirect($"/EditarMenu.aspx?Id={Id}&Nombre={Nombre}&Descripcion={Descripcion}&" +
                $"Ubicacion={Ubicacion}");
        }

        public DataSet CargarDatos()
        {
            return GestorMenu.Listar();
        }

        //protected void Buscar_Click(object sender, EventArgs e)
        //{
        //    //var Dato = buscar.Text.Trim();
        //    var userbuscado = user.Text.Trim();
        //    var dni = doc.Text.Trim();
        //    var status = "GET";

        //    if (!string.IsNullOrEmpty(userbuscado))
        //    {
        //        if (!string.IsNullOrEmpty(dni))
        //        {
        //            //filtro por todos los campos
        //            GestorUsuario.ListarUsuariosFiltroTotal(userbuscado, dni);
        //        }
        //        else
        //        {
        //            //filtro por usuario
        //            dni = null;
        //            GestorUsuario.ListarUsuariosConFiltro(userbuscado, dni, status);
        //        }
        //    }
        //    else if (!string.IsNullOrEmpty(dni))
        //    {
        //        //filtro solo por dni
        //        GestorUsuario.ListarUsuariosConFiltro(userbuscado, dni, status);
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Debe indicar un dato a buscar')</script>");
        //    }

        //}

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            bool Insertado = GestorMenu.Agregar(
                                       nombreControl.Text.Trim(),
                                       descripcion.Text.Trim(),
                                       ubicacion.Text.Trim());

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se agrego un registro", "Admin", "Menu");
                Response.Write("alert('El menu se ha agregado correctamente')");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Menus");

        }

        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Menus");
        }
    }
}