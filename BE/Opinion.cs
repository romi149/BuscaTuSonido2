using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Opinion
    {
        public int Id { get; set; }
        public int NroPregunta { get; set; }
        public string NombrePregunta { get; set; }
        public int Puntuacion { get; set; }
        public string Tipo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Opcion1 { get; set; }
        public string Opcion2 { get; set; }
        public string UrlOpcion1 { get; set; }
        public string UrlOpcion2 { get; set; }

    }

    public class OpinionReporte
    {
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
        public int Valor3 { get; set; }
        public int Valor4 { get; set; }
        public int Valor5 { get; set; }
    }
}
