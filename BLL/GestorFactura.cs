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
    }
}
