using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BE.GoogleCharts;

namespace GUI
{
    public partial class Grafico_FOpinionPreg1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GraficaBarras()
        {
            var listaDatos = GestorOpinion.ObtenerResultadosPregunta1();
            var valor1 = listaDatos[0].Valor1;
            var valor2 = listaDatos[0].Valor2;
            var valor3 = listaDatos[0].Valor3;
            var valor4 = listaDatos[0].Valor4;
            var valor5 = listaDatos[0].Valor5;

            GoogleCharts chart = new GoogleCharts();
            //Agregar columnas
            chart.cols.Add(new GoogleCharts.ChartColumn()
            {
                label = "Mes",
                type = "string"
            });
            chart.cols.Add(new GoogleCharts.ChartColumn()
            {
                label = "Opiniones de Clientes",
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
                { new GoogleCharts.ChartRowValue() { v = "Muy Fácil" } },
                { new GoogleCharts.ChartRowValue() { v = valor1 } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });
            //Agregar Febrero
            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Fácil" } },
                { new GoogleCharts.ChartRowValue() { v = valor2 } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });

            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Algo Fácil" } },
                { new GoogleCharts.ChartRowValue() { v = valor3 } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });

            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Nada Fácil" } },
                { new GoogleCharts.ChartRowValue() { v = valor4 } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });

            chart.rows.Add(new GoogleCharts.ChartRow()
            {
                c = new List<ChartRowValue>() {
                { new GoogleCharts.ChartRowValue() { v = "Difícil" } },
                { new GoogleCharts.ChartRowValue() { v = valor5 } },
                { new GoogleCharts.ChartRowValue() { v = "color: #FF0000" } }
            }
            });

            //Convertir clase a Json
            return new JavaScriptSerializer().Serialize(chart);
        }
    }
}