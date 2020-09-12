using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MPP.Helpers
{
    public class UsuarioTbl
    {
        public UsuarioTbl()
        {
           
            

        }

        public string Usuario1 { get; internal set; }
        public string Nombre { get; internal set; }
        public string Apellido { get; internal set; }
        public string Pass { get; internal set; }
        public string Estado { get; internal set; }
        public int? IdIdioma { get; internal set; }
        public int? Dni { get; internal set; }
    }

    public class ProductoTbl
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public float Precio { get; set; }
    }
}
