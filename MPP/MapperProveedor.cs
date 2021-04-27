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
    public class MapperProveedor
    {
        /// <summary>
        /// Retorna todos los proveedores de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarProveedores()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProveedores", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public static int ObtenerIdProveedor(string Nombre)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreEmpresa", DbType.String, ParameterDirection.Input, Nombre));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerIdProveedor", ListaParametros);
                if (respuesta != null)
                {
                    {
                        var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<int>("IdProveedor");

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

        public static string ObtenerCodProveedor(string Nombre)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreEmpresa", DbType.String, ParameterDirection.Input, Nombre));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerCodProveedor", ListaParametros);
                if (respuesta != null)
                {
                    {
                        var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<string>("CodProveedor");

                        return empList;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Proveedor> ListarProveedor()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProveedores", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Proveedor
                      {
                          IdProveedor = dataRow.Field<int>("IdProveedor"),
                          CodProveedor = dataRow.Field<string>("CodProveedor"),
                          NombreEmpresa = dataRow.Field<string>("NombreEmpresa"),
                          RazonSocial = dataRow.Field<string>("RazonSocial"),
                          Domicilio = dataRow.Field<string>("Domicilio"),
                          Email = dataRow.Field<string>("Email")

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
        /// Inserta un Proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo Proveedor</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarProveedor(Proveedor prov)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, prov.CodProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreEmpresa", DbType.String, ParameterDirection.Input, prov.NombreEmpresa));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("RazonSocial", DbType.String, ParameterDirection.Input, prov.RazonSocial));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Domicilio", DbType.String, ParameterDirection.Input, prov.Domicilio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, prov.Email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, prov.Telefono));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, prov.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Cuit", DbType.String, ParameterDirection.Input, prov.Cuit));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarProveedor", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo proveedor</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarProveedor(Proveedor prov)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, prov.IdProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, prov.CodProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreEmpresa", DbType.String, ParameterDirection.Input, prov.NombreEmpresa));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("RazonSocial", DbType.String, ParameterDirection.Input, prov.RazonSocial));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Domicilio", DbType.String, ParameterDirection.Input, prov.Domicilio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, prov.Email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, prov.Telefono));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, prov.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Cuit", DbType.String, ParameterDirection.Input, prov.Cuit));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarProveedor", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo Proveedor</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarProveedor(int IdProveedor)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, IdProveedor));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarProveedor", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
