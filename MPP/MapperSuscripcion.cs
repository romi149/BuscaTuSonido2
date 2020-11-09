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
        public static bool InsertarSuscripcion(string email, string nombre, string estado, bool ofertas, 
                                               bool eventos, bool noticias)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Nombre", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Estado", DbType.String, ParameterDirection.Input, estado));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CatOfertas", DbType.Boolean, ParameterDirection.Input, ofertas));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CatEventos", DbType.Boolean, ParameterDirection.Input, eventos));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CatNoticias", DbType.Boolean, ParameterDirection.Input, noticias));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarSuscripcion", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina una suscripcion en Bd
        /// </summary>
        /// <param email=""></param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarSuscripcion(string email, string motivo)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Motivo", DbType.String, ParameterDirection.Input, motivo));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarSuscripcion", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
