using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class NotaCredito
    {
        public int NroNotaC { get; set; }
        public DateTime Fecha { get; set; }
        public int NroFactura { get; set; }
        public string Detalle { get; set; }
        public string Importe { get; set; }
        public string Estado { get; set; }

    }
}
