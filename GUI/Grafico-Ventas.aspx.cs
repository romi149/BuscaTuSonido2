using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Grafico_Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo consulta para llenado de grafico

            //Chart1.DataSource = Grafico.LlenoGraficoEstadistico();
            //Chart1.Series["Series1"].XValueMember = "Nombre";
            //Chart1.Series["Series1"].YValueMembers = "Total";
            //Chart1.Series[0].ChartType = SeriesChartType.Pie;
            //Chart1.Series["Series1"].Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel;

            //this.Chart1.DataBind();
        }
    }
}