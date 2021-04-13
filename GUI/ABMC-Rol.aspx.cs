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
    public partial class ABMC_Rol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ABMC-Rol.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            if (!IsPostBack)
            {
                var listaDatos = CargarDatos();
                this.gvRol.DataSource = listaDatos;
                this.gvRol.DataBind();
            }
        }

        BE.Rol oRol;
        public DataSet CargarDatos()
        {
            return GestorRol.Listar();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string IdRol = row.Cells[0].Text.Trim();

            bool eliminado = GestorRol.Eliminar(int.Parse(IdRol));

            if (eliminado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se elimino un rol", "Admin", "Rol");
            }

            Response.Redirect("/ABMC-Rol.aspx");

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string IdRol = row.Cells[0].Text.Trim();
            string Nombre = row.Cells[1].Text.Trim();
            string Descripcion = row.Cells[2].Text.Trim();
            string TipoRol = row.Cells[3].Text.Trim();
            
            Response.Redirect($"/EditarRol.aspx?IdRol={IdRol}&Nombre={Nombre}" +
                $"&Descripcion={Descripcion}&TipoRol={TipoRol}");

        }

        protected void sendAgregar_Click(object sender, EventArgs e)
        {
            oRol = new BE.Rol();

            oRol.NombreRol = nombre.Text.Trim();
            oRol.Descripcion = descripcion.Text.Trim();
            oRol.TipoRol = tipoRol.Text.Trim();
            
            bool Insertado = GestorRol.Agregar(oRol);

            if (Insertado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se inserto un nuevo rol", "Admin", "Rol");
                Response.Write("<script>alert('El rol se ha agregado correctamente')</script>");
            }

            Response.Redirect("~/ABMC-Rol");

        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Rol");
        }
    }
}