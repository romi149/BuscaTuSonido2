using System;
using System.Security.Principal;

namespace BE
{
    public class Recibo
    {
        public int NroRecibo { get; set; }
        public DateTime Fecha { get; set; }
        public string Empresa { get; set; }
        public int CodCliente { get; set; }
        public string Descripcion { get; set; }
        public double Importe { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }

    }
}
