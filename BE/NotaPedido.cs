using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class NotaPedido
    {
        public int NroPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int CodCliente { get; set; }
        public string Upc { get; set; }
        public string Descripcion { get; set; }
        public double PrecioTotal { get; set; }
        public string Estado { get; set; }
        public string TipoOperacion { get; set; }
        public double PrecioAlq { get; set; }
    }
}
