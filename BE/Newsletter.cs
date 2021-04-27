using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Newsletter
    {
        public int Id { get; set; }
        public string Titulo1 { get; set; }
        public string Texto1 { get; set; }
        public string Titulo2 { get; set; }
        //public string Texto2 { get; set; }
        public string Img { get; set; }
        //public int AltoImg { get; set; }
        //public int AnchoImg { get; set; }
        public DateTime FechaPub { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
