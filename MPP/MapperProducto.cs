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
    public class MapperProducto
    {
        /// <summary>
        /// Retorna los 10 primeros productos de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarProductosTOP()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarCatalogo", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Categoria = dataRow.Field<string>("Categoria")
                          //Precio = dataRow.Field<float>("Precio")

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
        /// Retorna todos los productos de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarProductos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductos", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Upc = dataRow.Field<string>("upc"),
                          Nombre = dataRow.Field<string>("nombre"),
                          Descripcion = dataRow.Field<string>("descrip"),
                          Categoria = dataRow.Field<string>("categ"),
                          TipoInstrumento = dataRow.Field<string>("TipoInst"),
                          IdMarca = dataRow.Field<int>("IdMarca"),
                          Modelo = dataRow.Field<string>("modelo"),
                          CodProveedor = dataRow.Field<string>("codProveedor"),
                          IdProveedor = dataRow.Field<int>("IdProveedor"),
                          Color = dataRow.Field<string>("color"),
                          Estado = dataRow.Field<string>("estado"),
                          Precio = dataRow.Field<float>("precio")
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
        /// Inserta un producto en Bd
        /// </summary>
        /// <param name="producto">Tipo Producto</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarProducto(string upc, string nombre, string descrip, string categ, string TipoInst,
                                     int IdMarca, string modelo, string codProveedor, int IdProveedor, string color,
                                     string estado, float precio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Upc", DbType.String, ParameterDirection.Input, upc));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categ));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoInstrumento", DbType.String, ParameterDirection.Input, TipoInst));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMarca", DbType.Int16, ParameterDirection.Input, IdMarca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Modelo", DbType.String, ParameterDirection.Input, modelo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, codProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, IdProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Color", DbType.String, ParameterDirection.Input, color));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.Double, ParameterDirection.Input, precio));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarProducto", ListaParametros);
                
                    return respuesta;
                }
            
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un producto en Bd
        /// </summary>
        /// <param name="producto">Tipo Producto</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarProducto(int IdProd, string upc, string nombre, string descrip, string categ, string TipoInst,
                                     int IdMarca, string modelo, string codProveedor, int IdProveedor, string color,
                                     string estado, float precio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProd", DbType.String, ParameterDirection.Input, IdProd));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Upc", DbType.String, ParameterDirection.Input, upc));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categ));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoInstrumento", DbType.String, ParameterDirection.Input, TipoInst));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMarca", DbType.Int16, ParameterDirection.Input, IdMarca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Modelo", DbType.String, ParameterDirection.Input, modelo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, codProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, IdProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Color", DbType.String, ParameterDirection.Input, color));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.Double, ParameterDirection.Input, precio));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarProducto", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Elimina un producto en Bd
        /// </summary>
        /// <param name="producto">Tipo Producto</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarProducto(int IdProd)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProd", DbType.Int32, ParameterDirection.Input, IdProd));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarProducto", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }
    }
}
