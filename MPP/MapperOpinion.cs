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
    public class MapperOpinion
    {
        public static bool InsertarOpinion(int NroPregunta, string Pregunta, int Puntaje, string tipo)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPregunta", DbType.Int32, ParameterDirection.Input, NroPregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombrePregunta", DbType.String, ParameterDirection.Input, Pregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Puntuacion", DbType.Int32, ParameterDirection.Input, Puntaje));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Tipo", DbType.String, ParameterDirection.Input, tipo));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarOpinion", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
