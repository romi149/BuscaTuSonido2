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
    public class MapperMarca
    {
        /// <summary>
        /// Retorna todas las marcas de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Marca> ListarMarcas()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarMarcas", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Marca
                      {
                          IdMarca = dataRow.Field<Int32>("IdMarca"),
                          Nombre = dataRow.Field<string>("Nombre"),
                          Descripcion = dataRow.Field<string>("Descripcion")
                          
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

        public static int ObtenerIdMarca(string nombreMarca)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreMarca", DbType.String, ParameterDirection.Input, nombreMarca));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerIdMarca", ListaParametros);
                if (respuesta != null)
                {
                    {
                        var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<int>("IdMarca");

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
        /// Retorna todos las marcas de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarMarcasDT()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarMarcas", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Inserta una marca en Bd
        /// </summary>
        /// <param name="marca"></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarMarca(Marca marca)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, marca.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, marca.Descripcion));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarMarca", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza una marca en Bd
        /// </summary>
        /// <param name="marca"></param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarMarca(Marca marca)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMarca", DbType.String, ParameterDirection.Input, marca.IdMarca));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, marca.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, marca.Descripcion));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarMarca", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Elimina una marca en Bd
        /// </summary>
        /// <param name="marca"></param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarMarca(int Id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMarca", DbType.Int32, ParameterDirection.Input, Id));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarMarca", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }
    }
}
