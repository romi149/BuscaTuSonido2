using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace BE
{
    public class Remito
    {
        public int NroRemito { get; set; }
        public DateTime Fecha { get; set; }
        public int NroNP { get; set; }
        public int NroFactura { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }
    }
}
