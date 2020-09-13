using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MPP.Helpers
{
    public class StoreProcedureHelper
    {
        public static SqlParameter SetParameter(string NombreParametro, DbType tipoParametro, ParameterDirection direction, object valor)
        {
            return new SqlParameter
            {
                Direction = direction,
                ParameterName = NombreParametro,
                DbType = tipoParametro,
                Value = valor
            };
        }
    }
}
