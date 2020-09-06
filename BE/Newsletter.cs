using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Newsletter
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Estado { get; set; }
    }
}
