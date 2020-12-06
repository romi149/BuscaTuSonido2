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

        public static DataSet ListarEnviosPendientes()
        {
            return MapperRemito.ListarEnviosPendientes();

        }

        public static DataSet ListarRemitosPorCliente(int nroFactura, string usuario)
        {
            return MapperRemito.ListarRemitosPorCliente(nroFactura, usuario);

        }

        //public static List<NotaPedido> ObtenerNpFacturadas()
        //{
        //    return MapperRemito.ListarNpFacturadas();

        //}

        public static bool Agregar(int nroNp, int nroFactura, string estado)
        {
            return MapperRemito.InsertarRemito(nroNp, nroFactura, estado);
        }

        public static bool AnularRemito(int nroRemito)
        {
            return MapperRemito.AnularRemito(nroRemito);
        }

        public static bool ModificarRemito(int nroRemito, string descripcion, string notas, string estado)
        {
            return MapperRemito.ModificarRemito(nroRemito, descripcion, notas, estado);
        }

        public static string ObtenerEstado(int nroFactura)
        {
            return MapperRemito.ObtenerEstadoRemito(nroFactura);
        }

        public static int VerificarRemito(int nroFactura)
        {
            return MapperRemito.VerificarRemito(nroFactura);
        }
    }
}
