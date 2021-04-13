using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string PrecioTotal { get; set; }
        public string Empresa { get; set; }
        public int CodCliente { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }
        public int NroPedido { get; set; }


    }

    public class ReporteFactura
    {
        public int TotalEne { get; set; }
        public int TotalFeb { get; set; }
        public int TotalMar { get; set; }
        public int TotalAbr { get; set; }
        public int TotalMay { get; set; }
        public int TotalJun { get; set; }
        public int TotalJul { get; set; }
        public int TotalAgo { get; set; }
        public int TotalSep { get; set; }
        public int TotalOct { get; set; }
        public int TotalNov { get; set; }
        public int TotalDic { get; set; }

    }

}
