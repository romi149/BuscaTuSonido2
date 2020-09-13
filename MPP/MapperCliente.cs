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
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ValidarEmail", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Cliente
                      {
                          Nombre = dataRow.Field<string>("Nombre"),
                          Apellido = dataRow.Field<string>("Apellido"),
                          Email = dataRow.Field<string>("email")

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
        public static bool InsertarCliente(string nombre, string apellido, string email, string tel, 
                                            string domEntrega,int domFact, string pass, int dni)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Apellido", DbType.String, ParameterDirection.Input, apellido));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, tel));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("DomicilioEntrega", DbType.Int16, ParameterDirection.Input, domEntrega));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("DomicilioFact", DbType.String, ParameterDirection.Input, domFact));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dni", DbType.Int32, ParameterDirection.Input, dni));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarCliente", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
