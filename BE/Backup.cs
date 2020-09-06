using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Backup
    {
        public string NombreArchivo { get; set; }
        public DateTime Fecha { get; set; }
        public string Destino { get; set; }
        public string Origen { get; set; }
    }
}
