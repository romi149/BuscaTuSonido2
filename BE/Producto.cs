using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Producto
    {
        public int Upc { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string TipoInstrumento { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int CodProveedor { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
    }
}
