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

        public static bool AgregarNC(NotaCredito notaCred)
        {
            return MapperNC.InsertarNotaDeCredito(notaCred);
        }

        public static List<NotaCredito> ObtenerImporteNC(string usuario)
        {
            return MapperNC.ObtenerImporteNotaDeCredito(usuario);
        }

        public static List<NotaCredito> ObtenerNC(string usuario)
        {
            return MapperNC.ObtenerNotaDeCredito(usuario);
        }

        public static bool ModificarEstadoNC(NotaCredito nc)
        {
            return MapperNC.ActualizarEstadoNC(nc);
        }

        //public static bool AgregarND()
        //{
        //    return MapperNC.InsertarNotaDeDebito();
        //}


    }
}
