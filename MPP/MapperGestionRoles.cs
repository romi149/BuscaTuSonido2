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
    public class MapperGestionRoles
    {
        /// <summary>
        /// Retorna todos los roles de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Rol> ListarRoles()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarRoles", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Rol
                      {
                          NombreRol = dataRow.Field<string>("nombre"),
                          Descripcion = dataRow.Field<string>("descrip"),
                          TipoRol = dataRow.Field<string>("tipoRol")

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
        /// Inserta un rol en Bd
        /// </summary>
        /// <param name="rol">Tipo Rol</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarRol(string nombre, string descrip, string tipoRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoRol", DbType.String, ParameterDirection.Input, tipoRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un rol en Bd
        /// </summary>
        /// <param name="rol">Tipo Rol</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarRol(int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve la lista de roles que tiene asignado el usuaro seleccionado
        /// </summary>
        /// <returns></returns>
        public static List<Rol> ListarRolesAsignados(int IdUser)
        {

            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUser", DbType.Int32, ParameterDirection.Input, IdUser));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarRolesAsignados", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Rol
                      {
                          NombreRol = dataRow.Field<string>("nombre"),
                          Descripcion = dataRow.Field<string>("descrip"),
                          TipoRol = dataRow.Field<string>("tipoRol")

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
        /// Crea un nuevo registro en la tabla UsuarioRol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static bool AsignarRol(int IdUser, int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.Int32, ParameterDirection.Input, IdUser));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("AsginarRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un Rol asociado al usuario, se borra un registro de la tabla UsuarioRol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static bool EliminarRolAsignado(int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("DesasignarRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve una lista de todos los perfiles que existen en la base de datos
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
                          NombrePermiso = dataRow.Field<string>("nombre"),
                          Descripcion = dataRow.Field<string>("descrip"),
                          TipoPermiso = dataRow.Field<string>("tipoPermiso")

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
        /// Devuelve la lista de Permisos que tiene asignado el rol seleccionado
        /// </summary>
        /// <returns></returns>
        public static List<Permiso> ListarPermisosAsignados(int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPermisosAsignadosaRol", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Permiso
                      {
                          NombrePermiso = dataRow.Field<string>("nombre"),
                          Descripcion = dataRow.Field<string>("descrip"),
                          TipoPermiso = dataRow.Field<string>("tipoPermiso")

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
        /// Crea un nuevo registro en la tabla PermisoRol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static bool AsignarPermiso(int IdPermiso, int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPermiso", DbType.Int32, ParameterDirection.Input, IdPermiso));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("AsignarPermisoaRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un Permiso asociado al rol, se borra un registro de la tabla PermisoRol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static bool EliminarPermisoAsignado(int IdPermiso)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdPermiso", DbType.Int32, ParameterDirection.Input, IdPermiso));
                var respuesta = Conexion.GetInstance.EjecutarStore("DesasignarPermiso", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

    }
}
