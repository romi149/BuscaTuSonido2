using MPP;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorProducto
    {
        public static List<ProductoTbl> ObtenerProductos()
        {
            return MapperProducto.ListarProductos();


        }
    }
}
