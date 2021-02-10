using BLL;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace GUI
{
    public partial class ReporteVentas : System.Web.UI.Page
    {
        public object PdfWriter { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvVentas.DataSource = listaDatos;
            this.gvVentas.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorFactura.ListarFacturasReporte();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var NroFactura = nroFactura.Text.Trim();
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
                if (!string.IsNullOrEmpty(NroFactura))
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        //filtro por todo
                        gvVentas.DataSource = null;
                        gvVentas.DataSource = GestorFactura.ListarReporteFiltroTotal(int.Parse(NroFactura), user, fechaDesde, fechaHasta);
                        gvVentas.DataBind();
                        LimpiarCampos();
                    }
                    else
                    {
                        //filtro por fecha y nro factura
                        gvVentas.DataSource = null;
                        gvVentas.DataSource = GestorFactura.ListarReporteFechaNroFactura(int.Parse(NroFactura), fechaDesde, fechaHasta);
                        gvVentas.DataBind();
                        LimpiarCampos();
                    }

                }
                else if (!string.IsNullOrEmpty(user))
                {
                    //filtro por fechas y usuario
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteFechaUser(user, fechaDesde, fechaHasta);
                    gvVentas.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro solo por fechas
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteFechas(fechaDesde, fechaHasta);
                    gvVentas.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(NroFactura))
            {
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por nro factura y usuario
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteNroFactUser(int.Parse(NroFactura), user);
                    gvVentas.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por nro factura
                    gvVentas.DataSource = null;
                    gvVentas.DataSource = GestorFactura.ListarReporteNroFactura(int.Parse(NroFactura));
                    gvVentas.DataBind();
                    LimpiarCampos();
                }

            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro solo por usuario
                gvVentas.DataSource = null;
                gvVentas.DataSource = GestorFactura.ListarReporteUser(user);
                gvVentas.DataBind();
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            nroFactura.Text = "";
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

            gvVentas.EnableViewState = false;

            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gvVentas);
            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        private void ExportGridToPdf()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();
                    //StringWriter sw = new StringWriter(sb);
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    Page page = new Page();
                    HtmlForm form = new HtmlForm();

                    gvVentas.EnableViewState = false;

                    page.EnableEventValidation = false;
                    page.DesignerInitialize();
                    page.Controls.Add(form);
                    form.Controls.Add(gvVentas);
                    page.RenderControl(htw);

                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(a4:Page, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}