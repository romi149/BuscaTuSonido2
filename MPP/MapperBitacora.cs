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
        /// Devuelve una lista de registros en bitacora filtrado
        /// por entidad
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarFiltroEntidad(string entidad)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Entidad", DbType.String, ParameterDirection.Input, entidad));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarBitacoraFiltroEnt", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Devuelve una lista de registros en bitacora filtrado
        /// por fechas
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarFiltroFechas(string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarBitacoraFiltroFechas", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Devuelve una lista de registros en bitacora
        /// filtrando
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarBitacoraFiltrado(string entidad, string fechaDesde, string fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Entidad", DbType.String, ParameterDirection.Input, entidad));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("fechaDesde", DbType.DateTime, ParameterDirection.Input, fechaDesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("fechaHasta", DbType.DateTime, ParameterDirection.Input, fechaHasta));
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
