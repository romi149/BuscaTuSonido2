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
    public class GestorBitacora
    {
        static public DataSet Listar()
        {
            return MapperBitacora.ListarBitacora();
        }

        static public DataSet ListarFiltradoTotal(string tipo, string entidadIn)
        {
            return MapperBitacora.ListarBitacoraFiltroTotal(tipo,entidadIn);
        }

        static public bool Agregar(DateTime fecha, string tipoEvento, string user, string entidadInv)
        {
            return MapperBitacora.InsertarEnBicatora(fecha,tipoEvento,user,entidadInv);
        }
    }
}
