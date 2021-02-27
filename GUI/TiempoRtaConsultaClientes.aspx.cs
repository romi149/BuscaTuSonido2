using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;

namespace GUI
{
    public partial class TiempoRtaConsultaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvTiempoRtaConsultaClientes.DataSource = listaDatos;
            this.gvTiempoRtaConsultaClientes.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorProducto.ListarReporteTiempoRtaClientes();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
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
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por todo
                    gvTiempoRtaConsultaClientes.DataSource = null;
                    gvTiempoRtaConsultaClientes.DataSource = GestorProducto.ListarTiempoRtaClienteFiltroTotal(user, fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaClientes.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por fecha
                    gvTiempoRtaConsultaClientes.DataSource = null;
                    gvTiempoRtaConsultaClientes.DataSource = GestorProducto.ListarTiempoRtaClienteFiltroFechas(fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaClientes.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro por usuario
                gvTiempoRtaConsultaClientes.DataSource = null;
                gvTiempoRtaConsultaClientes.DataSource = GestorProducto.ListarTiempoRtaClientesFiltroUser(user);
                gvTiempoRtaConsultaClientes.DataBind();
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            usuario.Text = "";
            desde.Text = "";
            hasta.Text = "";
        }

        protected void ExportXls_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        protected void ExportPdf_Click(object sender, EventArgs e)
        {
            ExportGridToPdf();
        }

        private void ExportGridToExcel()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gvTiempoRtaConsultaClientes.EnableViewState = false;

            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gvTiempoRtaConsultaClientes);
            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=ConsultaClientes.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        private void ExportGridToPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ConsultaClientes.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            HtmlForm hf = new HtmlForm();
            gvTiempoRtaConsultaClientes.Parent.Controls.Add(hf);
            hf.Attributes["runat"] = "server";
            hf.Controls.Add(gvTiempoRtaConsultaClientes);
            hf.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }
    }
}