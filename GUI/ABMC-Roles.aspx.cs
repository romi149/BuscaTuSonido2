﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ABMC_Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Roles.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvRoles.DataSource = listaDatos;
            this.gvRoles.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorRol.Listar();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();

            bool eliminado = GestorRol.Eliminar(int.Parse(Id));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se elimino un registro", "Admin", "Rol");
            }

            Response.Redirect("/ABMC-Roles.aspx");

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Id = row.Cells[0].Text.Trim();
            string Nombre = row.Cells[2].Text.Trim();
            string Descripcion = row.Cells[3].Text.Trim();
            string TipoRol = row.Cells[5].Text.Trim();
            
            Response.Redirect($"/EditarRol.aspx?Id={Id}&Nombre={Nombre}&Descripcion={Descripcion}" +
                $"&TipoRol={TipoRol}");

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            BE.Rol oRol;
            oRol = new BE.Rol();

            bool Insertado = GestorRol.Agregar(oRol);

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se inserto un registro", "Admin", "Rol");
                Response.Write("<script>alert('El Rol se ha agregado correctamente')</script>");
                //Response.Redirect("/ABMC-Usuarios");
            }

            Response.Redirect("~/ABMC-Roles");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Roles");
        }

    }
}