using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BE
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Pass { get; set; }
        public string Estado { get; set; }
        public int IdIdioma { get; set; }
    }

    public class VerificacionUsuario
    {
        public string Hash { get; set; }
        public DateTime Fecha { get; set; }
    }
}
