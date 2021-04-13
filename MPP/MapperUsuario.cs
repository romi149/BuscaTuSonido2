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
                           Dni = dataRow.Field<int>("Dni"),
                           Estado = dataRow.Field<string>("Estado")

                       }).ToList();
                    if (empList.FirstOrDefault() != null && empList.FirstOrDefault().Estado == EstadoCliente.CONFIRMADO)
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
        public static bool InsertarUsuario(Usuario user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user.User));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, user.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, user.Apellido));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, user.Pass));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, user.Estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdIdioma", DbType.Int16, ParameterDirection.Input, user.IdIdioma));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.Int32, ParameterDirection.Input, user.Dni));
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
        public static bool ActualizarUsuario(Usuario user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.String, ParameterDirection.Input, user.IdUsuario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user.User));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, user.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, user.Apellido));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, user.Pass));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, user.Estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdIdioma", DbType.Int16, ParameterDirection.Input, user.IdIdioma));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.Int32, ParameterDirection.Input, user.Dni));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarUsuario", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Actualiza la contraseña de un usuario en Bd
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarPass(Usuario user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.String, ParameterDirection.Input, user.IdUsuario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, user.Pass));
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


        public static bool ConfirmacionUsuario(string user, string hashRecibido)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("User", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("VerificarRegistro", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new VerificacionUsuario
                      {
                          Hash = dataRow.Field<string>("codSeguridad"),
                          Fecha = dataRow.Field<DateTime>("fecha")

                      }).ToList();
                    DateTime fechaF = empList.FirstOrDefault().Fecha;
                    DateTime FechAc = DateTime.Now.Date;
                    double minutosTrascurridos = (FechAc - fechaF).TotalMinutes;

                    if (empList.FirstOrDefault() != null && empList.FirstOrDefault().Hash == hashRecibido && minutosTrascurridos <= 30)
                    {
                        ListaParametros.Clear();
                        ListaParametros.Add(StoreProcedureHelper.SetParameter("userName", DbType.String, ParameterDirection.Input, user));
                        bool respuestaUpdate = Conexion.GetInstance.EjecutarStore("ActualizarEstado", ListaParametros);
                        if (respuestaUpdate)
                            return true;

                    }
                }

                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }


        public static string RecuperarHashUsuario(string user)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("User", DbType.String, ParameterDirection.Input, user));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("VerificarRegistro", ListaParametros);
            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                  .Select(dataRow => new VerificacionUsuario
                  {
                      Hash = dataRow.Field<string>("codSeguridad"),
                      Fecha = dataRow.Field<DateTime>("fecha")

                  }).ToList();

                return empList.FirstOrDefault()?.Hash;
            }
            return null;
        }


        public static bool ConfirmacionCambioPass(string user, string hashRecibido, string pass)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("User", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("VerificarRegistro", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new VerificacionUsuario
                      {
                          Hash = dataRow.Field<string>("codSeguridad"),
                          Fecha = dataRow.Field<DateTime>("fecha")

                      }).ToList();
                    DateTime fechaF = empList.FirstOrDefault().Fecha;
                    DateTime FechAc = DateTime.Now;
                    double minutosTrascurridos = (fechaF - FechAc).TotalMinutes;

                    if (empList.FirstOrDefault() != null && empList.FirstOrDefault().Hash == hashRecibido && minutosTrascurridos <= 30)
                    {
                        ListaParametros.Clear();
                        ListaParametros.Add(StoreProcedureHelper.SetParameter("User", DbType.String, ParameterDirection.Input, user));
                        ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, pass));
                        bool respuestaUpdate = Conexion.GetInstance.EjecutarStore("ActualizarPassClientebyEmail", ListaParametros);
                        if (respuestaUpdate)

                            return true;

                    }
                }

                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public static bool CrearHashCliente(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.EjecutarStore("CrearHashEmailCliente", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static List<Usuario> ListaDeUsuarios()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarUsuarios", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Usuario
                      {
                          IdUsuario = dataRow.Field<Int32>("IdUsuario"),
                          User = dataRow.Field<string>("Usuario"),
                          Nombre = dataRow.Field<string>("Nombre"),
                          Apellido = dataRow.Field<string>("Apellido")
                          
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

        public static DataSet ListarUsuariosRol()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarUsuariosRol", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static bool EliminarUsuarioRol(int IdUser, int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.Int32, ParameterDirection.Input, IdUser));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarUsuarioRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static bool InsertarUsuarioRol(int IdUsuario, int IdRol)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.Int16, ParameterDirection.Input, IdUsuario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarUsuarioRol", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static int ObtenerRolUsuario(string User)
        {
            List<SqlParameter> ListaParametros = new List<SqlParameter>();
            ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, User));
            var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerRolUsuario", ListaParametros);
            if (respuesta != null)
            {
                var empList = respuesta.Tables[0].AsEnumerable()
                  .Select(dataRow => new Rol
                  {
                      IdRol = dataRow.Field<Int32>("IdRol")

                  }).ToList();

                return empList.FirstOrDefault().IdRol;
            }
            return 0;
        }

        public static List<Permiso> VerificarAccesoUser(int IdRol, string pagina)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdRol", DbType.Int32, ParameterDirection.Input, IdRol));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Pagina", DbType.String, ParameterDirection.Input, pagina));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("VerificarPermisoUser", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Permiso
                      {
                          IdPermiso = dataRow.Field<Int32>("IdPermiso"),
                          NombrePermiso = dataRow.Field<string>("Nombre")
                          
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

