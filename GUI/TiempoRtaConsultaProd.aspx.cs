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
    public partial class TiempoRtaConsultaProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvTiempoRtaConsultaProd.DataSource = listaDatos;
            this.gvTiempoRtaConsultaProd.DataBind();
        }

        public DataSet CargarDatos()
        {
            return GestorProducto.ListarReporteTiempoRtaProductos();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            var Producto = producto.Text.Trim();
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
                if (!string.IsNullOrEmpty(Producto))
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        //filtro por todo
                        gvTiempoRtaConsultaProd.DataSource = null;
                        gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroTotal(Producto, user, fechaDesde, fechaHasta);
                        gvTiempoRtaConsultaProd.DataBind();
                        LimpiarCampos();
                    }
                    else
                    {
                        //filtro por fecha y producto
                        gvTiempoRtaConsultaProd.DataSource = null;
                        gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroFechaProd(Producto, fechaDesde, fechaHasta);
                        gvTiempoRtaConsultaProd.DataBind();
                        LimpiarCampos();
                    }

                }
                else if (!string.IsNullOrEmpty(user))
                {
                    //filtro por fechas y usuario
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroFechaUser(user, fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro solo por fechas
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroFechas(fechaDesde, fechaHasta);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }
            }
            else if (!string.IsNullOrEmpty(Producto))
            {
                if (!string.IsNullOrEmpty(user))
                {
                    //filtro por producto y usuario
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroProdUser(Producto, user);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }
                else
                {
                    //filtro por producto
                    gvTiempoRtaConsultaProd.DataSource = null;
                    gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroProd(Producto);
                    gvTiempoRtaConsultaProd.DataBind();
                    LimpiarCampos();
                }

            }
            else if (!string.IsNullOrEmpty(user))
            {
                //filtro solo por usuario
                gvTiempoRtaConsultaProd.DataSource = null;
                gvTiempoRtaConsultaProd.DataSource = GestorProducto.ListarTiempoRtaProdFiltroUser(user);
                gvTiempoRtaConsultaProd.DataBind();
                LimpiarCampos();
            }
        }

        public void LimpiarCampos()
        {
            producto.Text = "";
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

            gvTiempoRtaConsultaProd.EnableViewState = false;

            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gvTiempoRtaConsultaProd);
            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=ConsultaProductos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        private void ExportGridToPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ConsultaProductos.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            HtmlForm hf = new HtmlForm();
            gvTiempoRtaConsultaProd.Parent.Controls.Add(hf);
            hf.Attributes["runat"] = "server";
            hf.Controls.Add(gvTiempoRtaConsultaProd);
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