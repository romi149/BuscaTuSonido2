using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Bitacora
    {
        public DateTime Fecha { get; set; }
        public string TipoEvento { get; set; }
        public string Usuario { get; set; }
        public string EntidadInvolucrada { get; set; }
        public string Criticidad { get; set; }
    }
}
