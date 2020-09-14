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
    public class MapperBitacora
    {
        /// <summary>
        /// Devuelve una lista de registros en bitacora
        /// </summary>
        /// <returns></returns>
        public static List<Bitacora> ListarBitacora()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarBitacora", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Bitacora
                      {
                          Fecha = dataRow.Field<DateTime>("fecha"),
                          TipoEvento = dataRow.Field<string>("tipoEvento"),
                          Usuario = dataRow.Field<string>("user"),
                          EntidadInvolucrada = dataRow.Field<string>("entidadInv")

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
        /// Inserta un registro en bitacora
        /// </summary>
        /// <returns>Devuelve si se insertó o no</returns>
        public static bool InsertarEnBicatora(DateTime fecha, string tipoEvento, string user, string entidadInv)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Fecha", DbType.DateTime, ParameterDirection.Input, fecha));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("TipoEvento", DbType.String, ParameterDirection.Input, tipoEvento));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Usuario", DbType.String, ParameterDirection.Input, user));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("EntidadInvolucrada", DbType.String, ParameterDirection.Input, entidadInv));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarEnBitacora", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
