using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorRemito
    {
        public static List<Remito> ObtenerRemitos()
        {
            return MapperRemito.ListarRemitos();

        }

        //public static List<NotaPedido> ObtenerNpFacturadas()
        //{
        //    return MapperRemito.ListarNpFacturadas();

        //}

        public static bool Agregar(DateTime fecha, int nroNp, int nroFactura, string descrip, string notas,
                                   string estado)
        {
            return MapperRemito.InsertarRemito(fecha,nroNp,nroFactura,descrip,notas,estado);
        }

        public static bool Anular(int nroRemito)
        {
            return MapperRemito.AnularRemito(nroRemito);
        }
    }
}
