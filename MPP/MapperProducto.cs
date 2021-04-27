﻿using System;
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
        public static bool InsertarProducto(Producto prod)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Upc", DbType.String, ParameterDirection.Input, prod.Upc));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, prod.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, prod.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, prod.Categoria));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoInstrumento", DbType.String, ParameterDirection.Input, prod.TipoInstrumento));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMarca", DbType.Int16, ParameterDirection.Input, prod.IdMarca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Modelo", DbType.String, ParameterDirection.Input, prod.Modelo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, prod.CodProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, prod.IdProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Color", DbType.String, ParameterDirection.Input, prod.Color));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, prod.Estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, prod.Precio));
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
        public static bool ActualizarProducto(Producto prod)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProd", DbType.String, ParameterDirection.Input, prod.Id));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Upc", DbType.String, ParameterDirection.Input, prod.Upc));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, prod.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, prod.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, prod.Categoria));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoInstrumento", DbType.String, ParameterDirection.Input, prod.TipoInstrumento));
                //ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMarca", DbType.Int16, ParameterDirection.Input, prod.IdMarca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Modelo", DbType.String, ParameterDirection.Input, prod.Modelo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, prod.CodProveedor));
                //ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, prod.IdProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Color", DbType.String, ParameterDirection.Input, prod.Color));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, prod.Estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, prod.Precio));
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
            var urlND = "/imagenes/NoDisponible.jpg";
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
                
                return urlND;
            }
            catch (Exception e)
            {
                return urlND;
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

        public static bool InsertarRespuesta(int id, string respuestaACliente)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.Int32, ParameterDirection.Input, id));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("RespuestaACliente", DbType.String, ParameterDirection.Input, respuestaACliente));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarRespuesta", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina una pregunta en Bd
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarPregunta(int Id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.Int32, ParameterDirection.Input, Id));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarPregunta", ListaParametros);

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
                          FechaPregunta = dataRow.Field<DateTime>("FechaPregunta"),
                          Respuesta = dataRow.Field<string>("Respuesta"),
                          FechaRespuesta = dataRow.Field<DateTime>("FechaRespuesta"),
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

        public static DataSet ListarTotalPreguntas()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPreguntas", ListaParametros);

                return respuesta;
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
        /// Retorna los tipos de instrumentos de productos para llenar 
        /// el combo tipo de instrumento en el ABMC 
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ListarTipoInstrumentos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTipoInstrumentos", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          TipoInstrumento = dataRow.Field<string>("TipoInstrumento")

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
        public static List<Producto> ListarProductosBuscados(string marca, string categoria, string precio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, marca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categoria));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, precio));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosBuscados", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static List<Producto> ListarProductosCategoria(string categoria)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categoria));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductoCategoria", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static List<Producto> ListarProductosPorMarca(string nombre)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosPorMarca", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static List<Producto> ListarProductosPorMarcaCategoria(string marca, string categoria)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Marca", DbType.String, ParameterDirection.Input, marca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categoria));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosPorMarcaCategoria", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static List<Producto> ListarProductosPorMarcaPrecio(string marca, string precio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Marca", DbType.String, ParameterDirection.Input, marca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, precio));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosPorMarcaPrecio", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static List<Producto> ListarProductosPorCategoriaPrecio(string categoria, string precio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Categoria", DbType.String, ParameterDirection.Input, categoria));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, precio));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosPorCategoriaPrecio", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static List<Producto> ListarProductosPorPrecio(string precio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Precio", DbType.String, ParameterDirection.Input, precio));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProductosPorPrecio", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Producto
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          Precio = dataRow.Field<string>("Precio"),
                          //Descripcion = dataRow.Field<string>("Descripcion"),
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

        public static bool InsertarPreguntaPersonalizada(string pregunta, string usuario)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Pregunta ", DbType.String, ParameterDirection.Input, pregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario  ", DbType.String, ParameterDirection.Input, usuario));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPreguntaPersonalizada", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Preguntas> ListarPreguntasPorCliente(string usuario)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, usuario));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPreguntasPorCliente", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Preguntas
                      {
                          Id = dataRow.Field<int>("id"),
                          Modelo = dataRow.Field<string>("Modelo"),
                          NombreProducto = dataRow.Field<string>("NombreProducto"),
                          Pregunta = dataRow.Field<string>("Pregunta"),
                          FechaPregunta = dataRow.Field<DateTime>("FechaPregunta"),
                          Respuesta = dataRow.Field<string>("Respuesta"),
                          FechaRespuesta = dataRow.Field<DateTime>("FechaRespuesta"),
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

        public static List<OpinionUsuario> ListarValoracionesProducto(string nombreP)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreP", DbType.String, ParameterDirection.Input, nombreP));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerValoracionProductos", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new OpinionUsuario
                      {
                          Valoracion = dataRow.Field<Int32>("Valoracion")
                          
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

        
        public static DataSet ListarOpinionesProductos(string nombreP)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreP", DbType.String, ParameterDirection.Input, nombreP));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerValoracionProductos", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static bool InsertarValoracionProducto(int puntaje, string comentario, int idUser, 
                                                     string nombreProd, string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Valoracion", DbType.Int32, ParameterDirection.Input, puntaje));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Comentario", DbType.String, ParameterDirection.Input, comentario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUser", DbType.Int32, ParameterDirection.Input, idUser));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto", DbType.String, ParameterDirection.Input, nombreProd));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarValoracionProducto", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static DataSet ListarReporteTiempoRtaProductos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductos", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroTotal(string producto, string user,
                                                             string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto", DbType.String, ParameterDirection.Input, producto));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroTotal", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroFechaProd(string producto,
                                                             string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto", DbType.String, ParameterDirection.Input, producto));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroFechaProd", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroFechaUser(string user,
                                                             string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroFechaUser", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroFechas(string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroFechas", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroProdUser(string producto, string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto", DbType.String, ParameterDirection.Input, producto));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroProdUser", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroProd(string producto)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreProducto", DbType.String, ParameterDirection.Input, producto));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroProd", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaProdFiltroUser(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaProductosFiltroUser", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarReporteTiempoRtaClientes()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaClientes", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet ListarTiempoRtaClienteFiltroTotal(string user,
                                                             string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaClienteFiltroTotal", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        
        public static DataSet ListarTiempoRtaClienteFiltroFechas(string fechadesde, string fechahasta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaDesde", DbType.DateTime, ParameterDirection.Input, fechadesde));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaHasta", DbType.DateTime, ParameterDirection.Input, fechahasta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaClienteFiltroFechas", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        
        public static DataSet ListarTiempoRtaClientesFiltroUser(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTiempoRtaClienteFiltroUser", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static string ObtenerPrecioProducto(string prod)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Producto", DbType.String, ParameterDirection.Input, prod));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerPrecioProducto", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<string>("Precio");

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
