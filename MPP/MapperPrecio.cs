using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using MPP.Helpers;

namespace MPP
{
    public class MapperPrecio
    {
        /// <summary>
        /// Retorna todos los precios de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Precio> ListarPrecios()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPrecios", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Precio
                      {
                          Fecha = dataRow.Field<DateTime>("fecha"),
                          PrecioCompra = dataRow.Field<float>("precioCompra"),
                          PrecioAnterior = dataRow.Field<float>("precioAnterior"),
                          PrecioPublicado = dataRow.Field<float>("precioPublicado"),
                          Descripcion = dataRow.Field<string>("Descip")
                          
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
        /// Inserta un precio en Bd
        /// </summary>
        /// <param name="precio">Tipo Precio</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarPrecio(DateTime fecha, float precioCompra, float precioAnterior, 
                                        float precioPublicado, string descrip)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Fecha", DbType.String, ParameterDirection.Input, fecha));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioCompra", DbType.Double, ParameterDirection.Input, precioCompra));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioAnterior", DbType.Double, ParameterDirection.Input, precioAnterior));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioPublicado", DbType.Double, ParameterDirection.Input, precioPublicado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPrecio", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un precio en Bd
        /// </summary>
        /// <param name="precio">Tipo Precio</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarPrecio(int IdPrecio, DateTime fecha, float precioCompra, float precioAnterior,
                                        float precioPublicado, string descrip)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPrecio", DbType.String, ParameterDirection.Input, IdPrecio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Fecha", DbType.String, ParameterDirection.Input, fecha));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioCompra", DbType.Double, ParameterDirection.Input, precioCompra));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioAnterior", DbType.Double, ParameterDirection.Input, precioAnterior));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("PrecioPublicado", DbType.Double, ParameterDirection.Input, precioPublicado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarPrecio", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Elimina un precio en Bd
        /// </summary>
        /// <param name="precio">Tipo Precio</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarPrecio(int IdPrecio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPrecio", DbType.Int32, ParameterDirection.Input, IdPrecio));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarPrecio", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
