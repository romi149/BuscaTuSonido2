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
    public class GestorNP
    {
        public static List<NotaPedido> Listar()
        {
            return MapperNP.ListarNotasPedido();

        }

        public static int ObtenerNP(string usuario, string total)
        {
            return MapperNP.ObtenerIdNP(usuario, total);
        }

        public static int ObtenerNPxFC(int nroFactura)
        {
            return MapperNP.ObtenerNPSegunFactura(nroFactura);
        }

        public static DataSet ListarNotasPedidoSinFacturar()
        {
            return MapperNP.ListarNotasPedidoSinFacturar();

        }

        public static DataSet ListarNotasPedidoFacturadas()
        {
            return MapperNP.ListarNotasPedidoFacturadas();

        }

        public static bool AgregarNP(string usuario, string total)
        {
            return MapperNP.InsertarNotaPedido(usuario, total);
        }

        public static bool AgregarProdNP(int numNP, string nombreProd)
        {
            return MapperNP.InsertarProductosXNP(numNP, nombreProd);
        }

        public static bool ModificarEstado(int Nro, string estado)
        {
            return MapperNP.ActualizarEstadoNP(Nro, estado);
        }

        public static bool Eliminar(int Nro)
        {
            return MapperNP.EliminarNotaPedido(Nro);
        }

        public static List<Producto> ListarProdxNP(int nroNP)
        {
            return MapperNP.ListarProductosxNP(nroNP);

        }

        public static bool AgregarDetalle(int np, string prod)
        {
            return MapperNP.InsertarDetalle(np, prod);
        }

        public static string ObtenerProducto(int nroNP)
        {
            return MapperNP.ObtenerProducto(nroNP);
        }

        public static List<Producto> VerificarValoracion(string cliente, string producto)
        {
            return MapperNP.ObtenerValoraciones(cliente, producto);

        }
    }
}
