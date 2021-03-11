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
    public partial class ABM_UsuariosRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABM-UsuariosRol.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            if (!IsPostBack)
            {
                var listaDatos = CargarDatos();
                this.gvUsuarioRol.DataSource = listaDatos;
                this.gvUsuarioRol.DataBind();
                CargarComboRol();
                CargarComboUsuario();

            }
        }

        public DataSet CargarDatos()
        {
            return GestorUsuario.ListarUsuarioRol();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string IdUsuario = row.Cells[0].Text.Trim();
            string Usuario = row.Cells[2].Text.Trim();
            string IdRol = row.Cells[4].Text.Trim();
            string Rol = row.Cells[6].Text.Trim();

            bool eliminado = GestorUsuario.EliminarUsuarioRol(int.Parse(IdUsuario), int.Parse(IdRol));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se desasigno el  rol " + Rol + " al usuario" + Usuario, "Admin", "UsuarioRol");
            }

            Response.Redirect("/ABM-UsuariosRol.aspx");

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            var IdUsuario = usuario.SelectedItem.Value;
            var NombreUsuario = usuario.SelectedItem.ToString();
            var IdRol = nombreRol.SelectedValue.ToString();
            var NombreRol = nombreRol.SelectedItem.ToString();

            bool Insertado = GestorUsuario.AgregarUsuarioRol(
                                           int.Parse(IdUsuario),
                                           int.Parse(IdRol));

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se asignó el rol " +NombreRol+ " al usuario" +NombreUsuario, "Admin", "UsuarioRol");
                //Response.Write("<script>alert('El registro se ha agregado correctamente')</script>");
            }
            Response.Redirect("/ABM-UsuariosRol.aspx");
        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABM-UsuariosRol");
        }

        public void CargarComboUsuario()
        {
            List<Usuario> lista = GestorUsuario.ListarUsuarios();
            lista.Insert(0, new Usuario { User = Constantes.SeleccionarUsuario });
            usuario.DataSource = lista;
            usuario.DataTextField = "User";
            usuario.DataValueField = "IdUsuario";
            usuario.DataBind();

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