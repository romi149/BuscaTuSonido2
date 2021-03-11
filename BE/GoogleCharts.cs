using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GoogleCharts
    {
        public List<ChartColumn> cols = new List<ChartColumn>();
        public List<ChartRow> rows = new List<ChartRow>();
        public struct ChartColumn
        {
            public string id;
            public string label;
            public string pattern;
            public string type;
            public string role;
        }
        public struct ChartRow
        {
            public List<ChartRowValue> c;
        }
        public struct ChartRowValue
        {
            public object v;
            public object f;
        }
        public void AddColumn(ChartColumn col) { cols.Add(col); }
        public void AddRow(ChartRow row) { rows.Add(row); }
    }
}
