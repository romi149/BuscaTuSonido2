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
        public double PrecioTotal { get; set; }
        public string Empresa { get; set; }
        public int CodCliente { get; set; }

    }
}
