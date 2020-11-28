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
    public class MapperNP
    {
        /// <summary>
        /// Retorna todas las notas de pedido de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<NotaPedido> ListarNotasPedido()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarNotaPedido", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new NotaPedido
                      {
                          NroPedido = dataRow.Field<Int32>("NroPedido"),
                          Fecha = dataRow.Field<DateTime>("Fecha"),
                          CodCliente = dataRow.Field<Int32>("CodCliente"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          PrecioTotal = dataRow.Field<string>("PrecioTotal"),
                          Estado = dataRow.Field<string>("Estado"),
                          TipoOperacion = dataRow.Field<string>("TipoOperacion"),
                          PeriodoAlq = dataRow.Field<string>("PeriodoAlquiler"),
                          Cantidad = dataRow.Field<Int32>("Cantidad")

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

        public static int ObtenerIdNP(string usuario, string  total)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, usuario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Total", DbType.String, ParameterDirection.Input, total));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerNP", ListaParametros);
                if (respuesta != null)
                {
                    {
                        var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<int>("NroPedido");

                        return empList;
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// Retorna todos las Notas de pedido de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarNotasPedidoSinFacturar()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarNPSinFacturar", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Inserta una NP en Bd
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarNotaPedido(string usuario, string total)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("User", DbType.String, ParameterDirection.Input, usuario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Total", DbType.String, ParameterDirection.Input, total));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarNotaPedido", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza una NP en Bd cambiando el estado
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarEstadoNP(int Nro, string estado)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nro", DbType.String, ParameterDirection.Input, Nro));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarEstadoNP", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Elimina una NP en Bd
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarNotaPedido(int Nro)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPedido", DbType.Int32, ParameterDirection.Input, Nro));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarNotaPedido", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static bool InsertarProductosXNP(int numNP, string nombreProd)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroNP", DbType.Int32, ParameterDirection.Input, numNP));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto", DbType.String, ParameterDirection.Input, nombreProd));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarProductosEnNP", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}

