using DAL;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace MPP
{
    public class MapperUsuario
    {
        public static Usuario ValidarUsuario(string user, string pass)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("password", DbType.String, ParameterDirection.Input, pass));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ValidarUsuario", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Usuario
                      {
                          User = dataRow.Field<string>("Usuario"),
                          Nombre = dataRow.Field<string>("Nombre"),
                          Apellido = dataRow.Field<string>("Apellido"),
                          Dni = dataRow.Field<int>("Dni")

                      }).ToList();
                    return empList.FirstOrDefault();
                }


                return null;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Retorna todos los usuarios de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarUsuarios()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarUsuarios", ListaParametros);
 
                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }



        /// <summary>
        /// Inserta un usuario en Bd
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarUsuario(string user, string nombre, string ape, string pass, string estado,
                                            int Ididioma, int dni)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, ape));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, pass));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdIdioma", DbType.Int16, ParameterDirection.Input, Ididioma));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.Int32, ParameterDirection.Input, dni));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarUsuario", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un usuario en Bd
        /// </summary>
        /// <param name="usuario">Tipo Producto</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarUsuario(int IdUser, string user, string nombre, string ape, string pass, string estado,
                                            int Ididioma, int dni)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.String, ParameterDirection.Input, IdUser));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, ape));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, pass));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdIdioma", DbType.Int16, ParameterDirection.Input, Ididioma));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.Int32, ParameterDirection.Input, dni));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarUsuario", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Elimina un usuario en Bd
        /// </summary>
        /// <param name="usuario">Tipo Producto</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarUsuario(int IdUser)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.Int32, ParameterDirection.Input, IdUser));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarUsuario", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }


        /// <summary>
        /// Retorna todos los usuarios de la Bd según el filtro aplicado
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarUsuariosFiltrados(string username, string dni, string status)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, username));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.String, ParameterDirection.Input, dni));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("status", DbType.String, ParameterDirection.Input, status));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("FiltrarUsuarios", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Retorna todos los usuarios de la Bd según el filtro
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarUsuariosFiltroTotal(string username, string dni)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, username));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.String, ParameterDirection.Input, dni));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarUsuariosFiltroTotal", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }



}

