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
    public class MapperPermiso
    {
        /// <summary>
        /// Retorna todos los permisos de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Permiso> ListarPermisos()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPermisos", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Permiso
                      {
                          IdPermiso = dataRow.Field<Int32>("IdPermiso"),
                          NombrePermiso = dataRow.Field<string>("Nombre"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          TipoPermiso = dataRow.Field<string>("TipoPermiso")

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
        /// Inserta un Permiso en Bd
        /// </summary>
        /// <param name="permiso">Tipo Permiso</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarPermiso(string nombre, string descrip, string tipoPermiso)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoPermiso", DbType.String, ParameterDirection.Input, tipoPermiso));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPermiso", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un permiso en Bd
        /// </summary>
        /// <param name="permiso">Tipo permiso</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarPermiso(int IdPermiso, string nombre, string descrip, string tipoPermiso)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPermiso", DbType.Int32, ParameterDirection.Input, IdPermiso));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoPermiso", DbType.String, ParameterDirection.Input, tipoPermiso));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarPermiso", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un permiso en Bd
        /// </summary>
        /// <param name="permiso">Tipo Permiso</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarPermiso(int IdPermiso)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPermiso", DbType.Int32, ParameterDirection.Input, IdPermiso));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarPermiso", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static DataSet ListarPermisosDS()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPermisos", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public static bool InsertarPermisoRol(int idPermiso, int idRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPermiso", DbType.Int32, ParameterDirection.Input, idPermiso));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, idRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPermisoRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static DataSet ListarPermisosRolDS()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPermisosPorRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public static bool EliminarPermisoRol(int idPermisoRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPermisoRol", DbType.Int32, ParameterDirection.Input, idPermisoRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarPermisoRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
