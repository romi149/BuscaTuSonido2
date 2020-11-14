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

        static public DataSet ListarFiltradoTotal(string evento, string user, string fechaDesde, string fechaHasta)
        {
            return MapperBitacora.ListarBitacoraFiltradoTotal(evento, user, fechaDesde, fechaHasta);
        }

        static public bool Agregar(DateTime fecha, string tipoEvento, string user, string entidadInv)
        {
            return MapperBitacora.InsertarEnBicatora(fecha,tipoEvento,user,entidadInv);
        }

        static public DataSet ListarFiltradoEventoFecha(string evento, string fechaDesde, string fechaHasta)
        {
            return MapperBitacora.ListarBitacoraFiltroEventoFecha(evento, fechaDesde, fechaHasta);
        }

        static public DataSet ListarFiltradoFechas(string fechadesde, string fechahasta)
        {
            return MapperBitacora.ListarFiltroFechas(fechadesde,fechahasta);
        }

        static public DataSet ListarFiltradoUsuarioFecha(string user, string fechaDesde, string fechaHasta)
        {
            return MapperBitacora.ListarBitacoraFiltroUsuarioFecha(user, fechaDesde, fechaHasta);
        }

        static public DataSet ListarFiltradoUsuarioEvento(string user, string evento)
        {
            return MapperBitacora.ListarBitacoraFiltroUsuarioEvento(user, evento);
        }

        static public DataSet ListarFiltradoEvento(string evento)
        {
            return MapperBitacora.ListarBitacoraFiltroEvento(evento);
        }

        static public DataSet ListarFiltradoUsuario(string user)
        {
            return MapperBitacora.ListarBitacoraFiltroUsuario(user);
        }
    }
}
