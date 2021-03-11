using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using static BE.GoogleCharts;

namespace GUI
{
    public partial class Grafico_Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string GraficaBarras()
        {
            var fecha = "2021";
            var listaDatos = GestorFactura.ListarVentasGrafico(fecha);
            var enero = listaDatos[0].TotalEne;
            var febrero = listaDatos[0].TotalFeb;
            var marzo = listaDatos[0].TotalMar;
            var abril = listaDatos[0].TotalAbr;
            var mayo = listaDatos[0].TotalMay;
            var junio = listaDatos[0].TotalJun;
            var julio = listaDatos[0].TotalJul;
            var agosto = listaDatos[0].TotalAgo;
            var septiembre = listaDatos[0].TotalSep;
            var octubre = listaDatos[0].TotalOct;
            var noviembre = listaDatos[0].TotalNov;
            var diciembre = listaDatos[0].TotalDic;
            
            GoogleCharts chart = new GoogleCharts();
            //Agregar columnas
            chart.cols.Add(new GoogleCharts.ChartColumn()
            {
                label = "Mes",
                type = "string"
            });
            chart.cols.Add(new GoogleCharts.ChartColumn()
            {
                label = "Ventas",
                type = "number"
            });
            chart.cols.Add(new GoogleCharts.ChartColumn()
            {
                role = "style",
                type = "string"
            });
            
            //Agregar datos
            //Agregar Enero
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Enero" } },
                { new GoogleCharts.ChartRowValue() { v = enero } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });
            //Agregar Febrero
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Febrero" } },
                { new GoogleCharts.ChartRowValue() { v = febrero } },
                { new GoogleCharts.ChartRowValue() { v = "color: #00CC00" } }
            }
            });
            //Agregar Marzo
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Marzo" } },
                { new GoogleCharts.ChartRowValue() { v = marzo } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });
            //Agregar Abril
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Abril" } },
                { new GoogleCharts.ChartRowValue() { v = abril } },
                { new GoogleCharts.ChartRowValue() { v = "color: #9900CC" } }
            }
            });
            //Agregar Mayo
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Mayo" } },
                { new GoogleCharts.ChartRowValue() { v = mayo } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });
            //Agregar Junio
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Junio" } },
                { new GoogleCharts.ChartRowValue() { v = junio } },
                { new GoogleCharts.ChartRowValue() { v = "color: #9900CC" } }
            }
            });
            //Agregar Julio
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Julio" } },
                { new GoogleCharts.ChartRowValue() { v = julio } },
                { new GoogleCharts.ChartRowValue() { v = "color: #00CC00" } }
            }
            });
            //Agregar Agosto
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Agosto" } },
                { new GoogleCharts.ChartRowValue() { v = agosto } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });
            //Agregar Septiembre
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Septiembre" } },
                { new GoogleCharts.ChartRowValue() { v = septiembre } },
                { new GoogleCharts.ChartRowValue() { v = "color: #9900CC" } }
            }
            });
            //Agregar Octubre
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Octubre" } },
                { new GoogleCharts.ChartRowValue() { v = octubre } },
                { new GoogleCharts.ChartRowValue() { v = "color: #00CC00" } }
            }
            });
            //Agregar Noviembre
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Noviembre" } },
                { new GoogleCharts.ChartRowValue() { v = noviembre } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });
            //Agregar Diciembre
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Diciembre" } },
                { new GoogleCharts.ChartRowValue() { v = diciembre } },
                { new GoogleCharts.ChartRowValue() { v = "color: #9900CC" } }
            }
            });

            //Convertir clase a Json
            return new JavaScriptSerializer().Serialize(chart);
        }



        //protected void Buscar_Click(object sender, EventArgs e)
        //{
        //    var Anio = anio.Text.Trim();

        //    LimpiarCampos();

        //}

        //public void LimpiarCampos()
        //{
        //    anio.Text = "";

        //}
    }
}