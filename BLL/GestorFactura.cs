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
    public class GestorFactura
    {
        public static bool Agregar(string descripcion, int cantidad, string precioTotal, int codCliente, 
                                    int nroPedido)
        {
            return MapperFactura.InsertarFactura(descripcion, cantidad, precioTotal, codCliente, 
                                                nroPedido);
        }

        public static bool ModificarFactura(int nroFactura, string estado, string detalle)
        {
            return MapperFactura.ActualizarEstadoFactura(nroFactura, estado, detalle);
        }

        public static DataSet ListarFacturas()
        {
            return MapperFactura.ListarTodasLasFacturas();
        }

        public static DataSet ListarFacturasEmitidas()
        {
            return MapperFactura.ListarFacturasEmitidas();
        }

        public static int ObtenerFactura(int nroPedido)
        {
            return MapperFactura.ObtenerNroFactura(nroPedido);
        }

        public static DataSet ListarFacturasReporte()
        {
            return MapperFactura.ListarFacturasReporte();
        }

        public static DataSet ListarReporteFiltroTotal(int NroFactura, string user, 
                                                        string fechaDesde, string fechaHasta)
        {
            return MapperFactura.ListarFacturasFiltroTotal(NroFactura, user, fechaDesde, fechaHasta);
        }

        public static DataSet ListarReporteFechaNroFactura(int NroFactura, string fechaDesde, string fechaHasta)
        {
            return MapperFactura.ListarFacturasFechaNroFactura(NroFactura, fechaDesde, fechaHasta);
        }

        public static DataSet ListarReporteFechaUser(string user, string fechaDesde, string fechaHasta)
        {
            return MapperFactura.ListarFacturasFechaUser(user, fechaDesde, fechaHasta);
        }

        public static DataSet ListarReporteFechas(string fechaDesde, string fechaHasta)
        {
            return MapperFactura.ListarFacturasFechas(fechaDesde, fechaHasta);
        }

        public static DataSet ListarReporteNroFactUser(int NroFactura, string user)
        {
            return MapperFactura.ListarFacturasNroFactUser(NroFactura, user);
        }

        public static DataSet ListarReporteNroFactura(int NroFactura)
        {
            return MapperFactura.ListarFacturasNroFactura(NroFactura);
        }

        public static DataSet ListarReporteUser(string user)
        {
            return MapperFactura.ListarFacturasUser(user);
        }
        public static List<ReporteFactura> ListarVentasGrafico(string anio)
        {
            return MapperFactura.ListarVentasGrafico(anio);
        }
    }
}
