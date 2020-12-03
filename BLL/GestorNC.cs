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
    public class GestorNC
    {
        public static DataSet ListarNotasCredito()
        {
            return MapperNC.ListarNotasDeCredito();

        }

        public static bool AgregarNC(int NroFactura, string detalleNC, string importe, string estado)
        {
            return MapperNC.InsertarNotaDeCredito(NroFactura, detalleNC, importe, estado);
        }

        public static List<NotaCredito> ObtenerImporteNC(string usuario)
        {
            return MapperNC.ObtenerImporteNotaDeCredito(usuario);
        }

        public static List<NotaCredito> ObtenerNC(string usuario)
        {
            return MapperNC.ObtenerNotaDeCredito(usuario);
        }

        public static bool ModificarEstadoNC(string estado, int nro)
        {
            return MapperNC.ActualizarEstadoNC(estado, nro);
        }

        //public static bool AgregarND()
        //{
        //    return MapperNC.InsertarNotaDeDebito();
        //}


    }
}
