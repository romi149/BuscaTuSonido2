using BE;
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
    public partial class ABMC_PermisoRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-PermisoRol.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            if (!IsPostBack)
            {
                var listaDatos = CargarDatos();
                this.gvPermisoRol.DataSource = listaDatos;
                this.gvPermisoRol.DataBind();
                CargarComboRol();
                CargarComboPermiso();

            }
        }
        public DataSet CargarDatos()
        {
            return GestorPermiso.ListarPermisoRol();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorPermiso.EliminarPermisoRol(int.Parse(Id));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se desasigno un  permiso a un rol", "Admin", "PermisoRol");
            }

            Response.Redirect("/ABMC-PermisoRol.aspx");

        }
            
        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            var IdPermiso = nombrePermiso.SelectedItem.Value;
            var NombrePermiso = nombrePermiso.SelectedItem.ToString();
            var IdRol = nombreRol.SelectedValue.ToString();
            var NombreRol = nombreRol.SelectedItem.ToString();
                
            bool Insertado = GestorPermiso.AgregarPermisoRol(
                                           int.Parse(IdPermiso),
                                           int.Parse(IdRol));

            if (Insertado)
            {
               GestorBitacora.Agregar(DateTime.Now, "Se asignó un nuevo permiso al rol seleccionado", "Admin", "PermisoRol");
               //Response.Write("<script>alert('El registro se ha agregado correctamente')</script>");
            }
            Response.Redirect("/ABMC-PermisoRol.aspx");
        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-PermisoRol");
        }

        public void CargarComboPermiso()
        {
             List<Permiso> lista = GestorPermiso.ObtenerPermisos();
             lista.Insert(0, new Permiso { NombrePermiso = Constantes.SeleccionarPermiso });
             nombrePermiso.DataSource = lista;
             nombrePermiso.DataTextField = "NombrePermiso";
             nombrePermiso.DataValueField = "IdPermiso";
             nombrePermiso.DataBind();

        }

        public void CargarComboRol()
        {
            List<Rol> lista = GestorRol.ObtenerListadoRoles();
            lista.Insert(0, new Rol { NombreRol = Constantes.SeleccionarRol });
            nombreRol.DataSource = lista;
            nombreRol.DataTextField = "NombreRol";
            nombreRol.DataValueField = "IdRol";
            nombreRol.DataBind();

        }
    }
}