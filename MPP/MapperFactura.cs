﻿using BE;
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
        public static bool InsertarFactura(Factura fact)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, fact.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Cantidad", DbType.Int32, ParameterDirection.Input, fact.Cantidad));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioTotal", DbType.String, ParameterDirection.Input, fact.PrecioTotal));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodCliente", DbType.Int32, ParameterDirection.Input, fact.CodCliente));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPedido", DbType.Int32, ParameterDirection.Input, fact.NroPedido));
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
        public static bool ActualizarEstadoFactura(Factura fact)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, fact.NroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, fact.Estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Detalle", DbType.String, ParameterDirection.Input, fact.Detalle));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarEstadoFactura", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        public static int ObtenerNroFactura(int NroPedido)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPedido", DbType.Int32, ParameterDirection.Input, NroPedido));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerNroFactura", ListaParametros);
            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                  .Select(dataRow => new Factura
                  {
                      NroFactura = dataRow.Field<Int32>("NroFactura")

                  }).ToList();

                return empList.FirstOrDefault().NroFactura;
            }
            return 0;
        }

        public static List<ReporteFactura> ListarVentasGrafico(string anio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("anioRecibido", DbType.String, ParameterDirection.Input, anio));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("GraficoVentasPorAnioMes", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                     .Select(dataRow => new ReporteFactura
                     {
                         TotalEne = dataRow.Field<Int32>("TotalEne"),
                         TotalFeb = dataRow.Field<Int32>("TotalFeb"),
                         TotalMar = dataRow.Field<Int32>("TotalMar"),
                         TotalAbr = dataRow.Field<Int32>("TotalAbr"),
                         TotalMay = dataRow.Field<Int32>("TotalMay"),
                         TotalJun = dataRow.Field<Int32>("TotalJun"),
                         TotalJul = dataRow.Field<Int32>("TotalJul"),
                         TotalAgo = dataRow.Field<Int32>("TotalAgo"),
                         TotalSep = dataRow.Field<Int32>("TotalSep"),
                         TotalOct = dataRow.Field<Int32>("TotalOct"),
                         TotalNov = dataRow.Field<Int32>("TotalNov"),
                         TotalDic = dataRow.Field<Int32>("TotalDic")

                     }).ToList();

                    return empList;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataSet ListarFacturasReporte()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasReporte", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasFiltroTotal(int NroFactura, string user,
                                                        string fechaDesde, string fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, NroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechaDesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechaHasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasFiltroTotal", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasFechaNroFactura(int NroFactura, string fechaDesde, string fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, NroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechaDesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechaHasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasFechaNroFactura", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasFechaUser(string user, string fechaDesde, 
                                                       string fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechaDesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechaHasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasFechaUsuario", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasFechas(string fechaDesde, string fechaHasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechaDesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechaHasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasFechas", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasNroFactUser(int nroFactura, string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasNroFacturaUser", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasNroFactura(int nroFactura)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasNroFactura", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarFacturasUser(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarVentasUser", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }
    }
}
