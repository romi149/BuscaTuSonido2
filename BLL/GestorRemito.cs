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

        public static bool Agregar(Remito re)
        {
            return MapperRemito.InsertarRemito(re);
        }

        public static bool AnularRemito(int nroRemito)
        {
            return MapperRemito.AnularRemito(nroRemito);
        }

        public static bool ModificarRemito(Remito re)
        {
            return MapperRemito.ModificarRemito(re);
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
