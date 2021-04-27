using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Microsoft.SqlServer.Server;
using MPP.Helpers;

namespace MPP
{
    public class MapperRemito
    {
        /// <summary>
        /// Devuelve todas las NP en estado "Facturado" para generarles el remito
        /// </summary>
        /// <returns></returns>
        //public static List<Remito> ListarNpFacturadas()
        //{
            
        //}

        /// <summary>
        /// Retorna todos los remitos de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarRemitos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarRemitos", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarEnviosPendientes()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarEnviosPendientes", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        public static DataSet ListarRemitosPorCliente(int nroFactura, string usuario)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, usuario));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarRemitosPorCliente", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Inserta un Remito en Bd
        /// </summary>
        /// <param name="remito">Tipo Remito</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarRemito(Remito re)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPedido", DbType.Int16, ParameterDirection.Input, re.NroNP));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, re.NroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, re.Estado));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarRemito", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Anula un remito en Bd (coloca el estado "Anulado")
        /// </summary>
        /// <param name="remito">Tipo remito</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool AnularRemito(int nroRemito)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroRemito", DbType.Int32, ParameterDirection.Input, nroRemito));
                var respuesta = Conexion.GetInstance.EjecutarStore("AnularRemito", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ModificarRemito(Remito re)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroRemito", DbType.Int16, ParameterDirection.Input, re.NroRemito));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, re.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Notas", DbType.String, ParameterDirection.Input, re.Notas));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, re.Estado));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarRemito", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static string ObtenerEstadoRemito(int nroFactura)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerEstadoRemito", ListaParametros);
            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                  .Select(dataRow => new Remito
                  {
                      Estado = dataRow.Field<string>("Estado")
                      
                  }).ToList();

                return empList.FirstOrDefault().Estado;
            }
            return null;
        }

        public static int VerificarRemito(int nroFactura)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("VerificarRemito", ListaParametros);
            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                  .Select(dataRow => new Remito
                  {
                      NroRemito = dataRow.Field<Int32>("NroRemito")

                  }).ToList();

                if(empList.FirstOrDefault() == null)
                {
                    return 0;
                }

                return empList.FirstOrDefault().NroRemito;
            }
            return 0;
        }

    }
}
