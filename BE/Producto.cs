using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Producto
    {
        public string Upc { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string TipoInstrumento { get; set; }
        public int IdMarca { get; set; }
        public string Modelo { get; set; }
        public string CodProveedor { get; set; }
        public int IdProveedor { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
        public string Precio { get; set; }
        public string urlImg { get; set; }
    }
}
