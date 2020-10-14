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
    public class MapperSuscripcion
    {
        /// <summary>
        /// Retorna todos las suscripciones registradas
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarSuscripciones()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarSuscripciones", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }



        /// <summary>
        /// Inserta una suscripcion en Bd
        /// </summary>
        /// <param name=""></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarSuscripcion(string email, string nombre, string estado)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarSuscripcion", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
