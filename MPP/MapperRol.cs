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
    public class MapperRol
    {
        /// <summary>
        /// Retorna todos los roles de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarRolesDS()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarRoles", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }
        }

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
                          IdRol = dataRow.Field<Int32>("IdRol"),
                          NombreRol = dataRow.Field<string>("Nombre"),
                          Descripcion = dataRow.Field<string>("Descripcion"),
                          TipoRol = dataRow.Field<string>("TipoRol")

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
        public static bool InsertarRol(BE.Rol rol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, rol.NombreRol));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, rol.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoRol", DbType.String, ParameterDirection.Input, rol.TipoRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un rol en Bd
        /// </summary>
        /// <param name="rol">Tipo Rol</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarRol(BE.Rol rol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, rol.IdRol));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, rol.NombreRol));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, rol.Descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoRol", DbType.String, ParameterDirection.Input, rol.TipoRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarRol", ListaParametros);

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
    }
}
