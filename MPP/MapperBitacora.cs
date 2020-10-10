using BE;
using DAL;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MapperBitacora
    {
        /// <summary>
        /// Devuelve una lista de registros en bitacora
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarBitacora()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarEventosBitacora", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Devuelve una lista de registros en bitacora
        /// filtrando por todos los campos
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarBitacoraFiltroTotal(string tipo, string entidadIn)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoEvento", DbType.String, ParameterDirection.Input, tipo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("EntidadInvolucrada", DbType.String, ParameterDirection.Input, entidadIn));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarBitacoraFiltroTotal", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Inserta un registro en bitacora
        /// </summary>
        /// <returns>Devuelve si se insertó o no</returns>
        public static bool InsertarEnBicatora(DateTime fecha, string tipoEvento, string user, string entidadInv)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Fecha", DbType.DateTime, ParameterDirection.Input, fecha));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoEvento", DbType.String, ParameterDirection.Input, tipoEvento));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("EntidadInvolucrada", DbType.String, ParameterDirection.Input, entidadInv));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarEnBitacora", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
