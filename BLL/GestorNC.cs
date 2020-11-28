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

        public static bool AgregarNC(int NroFactura, string detalleNC)
        {
            return MapperNC.InsertarNotaDeCredito(NroFactura, detalleNC);
        }

        //public static bool AgregarND()
        //{
        //    return MapperNC.InsertarNotaDeDebito();
        //}

        
    }
}
