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
    public partial class ConsultarBitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var User = $"{((BE.Usuario)Session["usuarioBackend"])?.User}";
            var IdRol = GestorUsuario.ObtenerRolUsuario(User);
            var permiso = GestorUsuario.VerificarAcceso(IdRol, "ReporteVentas.aspx");

            if (permiso.Count == 0)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

            var listaDatos = CargarDatos();
            this.gvBitacora.DataSource = listaDatos;
            this.gvBitacora.DataBind();

        }

        public DataSet CargarDatos()
        {
            return GestorBitacora.Listar();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var Evento = tipoEvento.Text.Trim();
            var user = usuario.Text.Trim();
            var fechaDesde = desde.Text.Trim();
            var fechaHasta = hasta.Text.Trim();


            if ((string.IsNullOrEmpty(fechaDesde) && (!string.IsNullOrEmpty(fechaHasta)))
                || ((!string.IsNullOrEmpty(fechaDesde)) && (string.IsNullOrEmpty(fechaHasta))))
            {
                Response.Write("<script>alert('¡Para filtrar por fechas debe seleccionar fecha desde y fecha hasta!')</script>");

                return;
            }
            else if (!string.IsNullOrEmpty(fechaDesde) && (!string.IsNullOrEmpty(fechaHasta)))
            {
                if (!string.IsNullOrEmpty(Evento))
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        //filtro por todo
                        gvBitacora.DataSource = null;
                        gvBitacora.DataSource = GestorBitacora.ListarFiltradoTotal(Evento, user, fechaDesde, fechaHasta);
                        gvBitacora.DataBind();
                        LimpiarCampos();
                    }
                    else
                    {
                        //filtro por fecha y evento
                        gvBitacora.DataSource = null;
                        gvBitacora.DataSource = GestorBitacora.ListarFiltradoEventoFecha(Evento, fechaDesde, fechaHasta);
                        gvBitacora.DataBind();
                        LimpiarCampos();
                    }

                }
                else if (!string.IsNullOrEmpty(user))
                {
                    //filtro por fechas y usuario
                    gvBitacora.DataSource = null;
                    gvBitacora.DataSource = GestorBitacora.ListarFiltradoUsuarioFecha(user, fechaDesde, fechaHasta);
                    gvBitacora.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro solo por fechas
                    gvBitacora.DataSource = null;
                    gvBitacora.DataSource = GestorBitacora.ListarFiltradoFechas(fechaDesde, fechaHasta);
                    gvBitacora.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(Evento))
            {
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por evento y usuario
                    gvBitacora.DataSource = null;
                    gvBitacora.DataSource = GestorBitacora.ListarFiltradoUsuarioEvento(user, Evento);
                    gvBitacora.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por evento
                    gvBitacora.DataSource = null;
                    gvBitacora.DataSource = GestorBitacora.ListarFiltradoEvento(Evento);
                    gvBitacora.DataBind();
                    LimpiarCampos();
                }

            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro solo por usuario
                gvBitacora.DataSource = null;
                gvBitacora.DataSource = GestorBitacora.ListarFiltradoUsuario(user);
                gvBitacora.DataBind();
                LimpiarCampos();
            }
        }


        public void LimpiarCampos()
        {
            tipoEvento.Text = "";
            usuario.Text = "";
            desde.Text = "";
            hasta.Text = "";
        }
    }
}