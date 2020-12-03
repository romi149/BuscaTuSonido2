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
    public class MapperFactura
    {
        /// <summary>
        /// Retorna todas las facturas de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarTodasLasFacturas()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarFacturas", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Retorna todas las facturas de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarFacturasEmitidas()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarFacturasEmitidas", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Inserta una Factura en Bd
        /// </summary>
        /// <param =""></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarFactura(string descripcion, int cantidad, string precioTotal, 
                                            int codCliente, int nroPedido)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Cantidad", DbType.Int32, ParameterDirection.Input, cantidad));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioTotal", DbType.String, ParameterDirection.Input, precioTotal));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodCliente", DbType.Int32, ParameterDirection.Input, codCliente));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPedido", DbType.Int32, ParameterDirection.Input, nroPedido));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarFactura", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza una Factura en Bd cambiando el estado
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarEstadoFactura(int Nro, string estado, string detalle)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, Nro));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Detalle", DbType.String, ParameterDirection.Input, detalle));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarEstadoFactura", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }
    }
}
