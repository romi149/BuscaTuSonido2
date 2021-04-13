using BE;
using DAL;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MapperCliente
    {
        /// <summary>
        /// Valida si el email ingresado existe en la base de datos 
        /// y devuelve los datos del cliente
        /// </summary>
        /// <param name="Cliente">Email</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static Cliente ValidarEmail(string email)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("email", DbType.String, ParameterDirection.Input, email));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ValidarEmailCliente", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Cliente
                      {
                          Email = dataRow.Field<string>("Email")

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
        /// Valida si el usuario es un cliente
        /// </summary>
        /// <param name="Cliente">Usuario</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static Cliente ValidarCliente(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ValidarCliente", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Cliente
                      {
                          Usuario = dataRow.Field<string>("Usuario")
                          
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
        /// Inserta un cliente en Bd
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarCliente(Cliente cli)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, cli.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, cli.Apellido));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, cli.Email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, cli.Telefono));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("DomicilioEntrega", DbType.String, ParameterDirection.Input, cli.DomEntrega));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("DomicilioFact", DbType.String, ParameterDirection.Input, cli.DomFacturacion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Pass", DbType.String, ParameterDirection.Input, cli.Pass));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.String, ParameterDirection.Input, cli.Dni));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, cli.Usuario));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarCliente", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Retorna los datos del cliente logueado
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> ListarDatosCliente(string dni, string nombre)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.String, ParameterDirection.Input, dni));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarDatosCliente", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Cliente
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Apellido = dataRow.Field<string>("Apellido"),
                          Email = dataRow.Field<string>("Email"),
                          Telefono = dataRow.Field<string>("Telefono"),
                          DomEntrega = dataRow.Field<string>("DomicilioEntrega"),
                          DomFacturacion = dataRow.Field<string>("DomicilioFact"),
                          Dni = dataRow.Field<string>("Dni"),
                          Usuario = dataRow.Field<string>("Usuario"),
                          CodCliente = dataRow.Field<int>("CodCliente")

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
        /// Actualiza un cliente en Bd
        /// </summary>
        /// <param name="Id">Cliente</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarDatosCliente(Cliente cli)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodCliente", DbType.Int32, ParameterDirection.Input, cli.CodCliente));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, cli.Nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, cli.Apellido));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, cli.Email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, cli.Telefono));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("DomicilioEntrega", DbType.String, ParameterDirection.Input, cli.DomEntrega));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("DomicilioFact", DbType.String, ParameterDirection.Input, cli.DomFacturacion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.String, ParameterDirection.Input, cli.Dni));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, cli.Usuario));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarCliente", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Actualiza la contraseña de un cliente en Bd
        /// </summary>
        /// <param name="Id">Cliente</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarPassCliente(Usuario user, Cliente cli)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdUsuario", DbType.Int32, ParameterDirection.Input, user.IdUsuario));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Password", DbType.String, ParameterDirection.Input, cli.Pass));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodigoCliente", DbType.Int32, ParameterDirection.Input, cli.CodCliente));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarPassCliente", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        public static DataSet ListarComprasCliente(string usuario)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, usuario));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarComprasCliente", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static Cliente ObtenerEmailCliente(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerEmailCliente", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Cliente
                      {
                          Email = dataRow.Field<string>("Email")

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

        public static Cliente ObtenerCodCliente(string user)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerCodCliente", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Cliente
                      {
                          CodCliente = dataRow.Field<Int32>("CodCliente")

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
    }
}
