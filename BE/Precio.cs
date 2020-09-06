using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Precio
    {
        public DateTime Fecha { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioAnterior { get; set; }
        public double PorcentajeVenta { get; set; }
        public double PrecioPublicado { get; set; }
        public string Descripcion { get; set; }
    }
}
