using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorBusqueda
    {
        public static List<Busqueda> ListarPaginasFront(string dato)
        {
            return MapperBusqueda.ListarUrlPaginasFront(dato);

        }

        public static List<Busqueda> ListarPaginasBack(string dato)
        {
            return MapperBusqueda.ListarUrlPaginasBack(dato);

        }
    }
}
