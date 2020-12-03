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
    public class MapperNC
    {
        /// <summary>
        /// Retorna todos las Notas de credito de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarNotasDeCredito()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarNotasCredito", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Inserta una NC en Bd
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarNotaDeCredito(int nroFactura, string detalle, string importe, string estado)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Detalle", DbType.String, ParameterDirection.Input, detalle));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Importe", DbType.String, ParameterDirection.Input, importe));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarNotaCredito", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ActualizarEstadoNC(string estado, int nro)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroNC", DbType.Int32, ParameterDirection.Input, nro));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarEstadoNC", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserta una ND en Bd
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarNotaDeDebito(int nroFactura, int nroNotaCredito, string detalle)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroNotaCredito", DbType.Int32, ParameterDirection.Input, nroNotaCredito));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Detalle ", DbType.String, ParameterDirection.Input, detalle));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarNotaDebito", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static List<NotaCredito> ObtenerImporteNotaDeCredito(string usuario)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, usuario));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerImporteNotaCredito", ListaParametros);

            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new NotaCredito
                      {
                          Importe = dataRow.Field<string>("Importe")
                          
                      }).ToList();

                return empList;
            }

            return null;
        }

        public static List<NotaCredito> ObtenerNotaDeCredito(string usuario)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, usuario));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerNotaCredito", ListaParametros);

            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new NotaCredito
                      {
                          NroNotaC = dataRow.Field<Int32>("NroNotaC")

                      }).ToList();

                return empList;
            }

            return null;
        }

    }
}

