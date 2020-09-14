using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorBitacorra
    {
        static public List<Bitacora> Listar()
        {
            return MapperBitacora.ListarBitacora();
        }

        static public bool Agregar(DateTime fecha, string tipoEvento, string user, string entidadInv)
        {
            return MapperBitacora.InsertarEnBicatora(fecha,tipoEvento,user,entidadInv);
        }
    }
}
