using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorRemito
    {
        public static DataSet Listar()
        {
            return MapperRemito.ListarRemitos();

        }

        public static DataSet ListarRemitosPorCliente(int nroFactura, string usuario)
        {
            return MapperRemito.ListarRemitosPorCliente(nroFactura, usuario);

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
