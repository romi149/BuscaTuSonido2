using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class OrdenCompra
    {
        public int NroOrdenCompra { get; set; }
        public int CodProveedor { get; set; }
        public string TipoInstrumento { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
