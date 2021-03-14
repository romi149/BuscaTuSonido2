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
    public class MapperBackup
    {
        public static bool RealizarRestore(string ruta)
        {
            try
            {
                return Conexion.GetInstance.RealizarRestore(ruta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool RealizarBackup(string destino)
        {
            //try
            //{
            //    return Conexion.GetInstance.RealizarBackup();
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Ruta_Archivos", DbType.String, ParameterDirection.Input, destino));
                var respuesta = Conexion.GetInstance.EjecutarStore("GenerarBackup", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }
    }
}
