using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class OrdenPago
    {
        public int NroOrdenPago { get; set; }
        public DateTime FechaFactProveedor { get; set; }
        public int NroFactProveedor { get; set; }
        public string DetalleFact { get; set; }
        public DateTime FechaPago { get; set; }
        public string CondicionesPago { get; set; }
        public string Estado { get; set; }
    }
}
