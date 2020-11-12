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
                          Categoria = dataRow.Field<string>("Categoria"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio")

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
        public static DataSet ListarProductos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductos", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        
        
        /// <summary>
        /// Retorna los productos para llenar el catalogo dinamico de productos 
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarProductosPorCategoria(string nombre)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosPorCategoria", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Categoria = dataRow.Field<string>("Categoria"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio")

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
                                     string estado, string precio)
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
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, precio));
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
                                     string estado, string precio)
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
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, precio));
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

        public static Producto ListarDetalleProducto(string nombre, string modelo)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Modelo", DbType.String, ParameterDirection.Input, modelo));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarDetalleProducto", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          //Categoria = dataRow.Field<string>("Categoria"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          Precio = dataRow.Field<string>("Precio")

                      }).ToList().FirstOrDefault();

                    return empList;
                }


                return null;
            }
            catch (Exception e)
            {

                return null;
            }
        }


        public static string ObtenerRutaImagen(string nombreImg, string categoria)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreImagen", DbType.String, ParameterDirection.Input, nombreImg));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categoria));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerImagen", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<string>("Urlimg");

                    return empList;
                }
                //PONER IMAGEN POR DEFECTO
                return null;
            }
            catch (Exception e)
            {
                //PONER IMAGEN POR DEFECTO
                return null;

            }

        }

        /// <summary>
        /// Inserta una imagen en Bd
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarImagen(string nombre, string categ, string url)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categ));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Url", DbType.String, ParameterDirection.Input, url));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarImagen", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna los productos que se seleccionaron para comparar
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarProductosAComparar(string nombre)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosAComparar", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          urlImg = dataRow.Field<string>("urlImg")

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


        public static bool InsertarPregunta(string NombreProducto, string modelo, string pregunta, string usuario)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto ", DbType.String, ParameterDirection.Input, NombreProducto));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("ModeloProducto ", DbType.String, ParameterDirection.Input, modelo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Pregunta ", DbType.String, ParameterDirection.Input, pregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("usuario  ", DbType.String, ParameterDirection.Input, usuario));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPregunta", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Preguntas> ListarPreguntas(string NombreProducto, string modelo)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto ", DbType.String, ParameterDirection.Input, NombreProducto));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Modelo ", DbType.String, ParameterDirection.Input, modelo));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPreguntasPorProducto", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Preguntas
                      {
                          Id = dataRow.Field<int>("id"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          NombreProducto = dataRow.Field<string>("NombreProducto"),
                          Pregunta = dataRow.Field<string>("Pregunta"),
                          Fecha = dataRow.Field<DateTime>("Fecha"),
                          Respuesta = dataRow.Field<string>("Respuesta"),
                          Usuario = dataRow.Field<string>("Usuario")
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
        /// Retorna las categorias de productos para llenar el combo categoria 
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarCategorias()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarCategorias", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Categoria = dataRow.Field<string>("Categoria")
                          
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
        /// Retorna los productos que filtrados por marca y categoria
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarProductosBuscados(string marca, string categoria)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, marca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categoria));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosBuscados", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          urlImg = dataRow.Field<string>("urlImg")

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
    }
}
