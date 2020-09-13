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
        public static List<Remito> ListarRemitos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarRemitos", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Remito
                      {
                          NroRemito = dataRow.Field<int>("nroRemito"),
                          Fecha = dataRow.Field<DateTime>("fecha"),
                          NroNP = dataRow.Field<int>("nroNP"),
                          NroFactura = dataRow.Field<int>("nroFactura"),
                          Descripcion = dataRow.Field<string>("descrip"),
                          Notas = dataRow.Field<string>("notas"),
                          Estado = dataRow.Field<string>("estado")

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

        /// <summary>
        /// Inserta un Remito en Bd
        /// </summary>
        /// <param name="remito">Tipo Remito</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarRemito(DateTime fecha, int nroNp, int nroFactura, string descrip, string notas,
                                          string estado)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Fecha", DbType.DateTime, ParameterDirection.Input, fecha));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPedido", DbType.Int16, ParameterDirection.Input, nroNp));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroFactura", DbType.Int32, ParameterDirection.Input, nroFactura));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.Int32, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Notas", DbType.Int32, ParameterDirection.Input, notas));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.Int32, ParameterDirection.Input, estado));
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

        
    }
}
