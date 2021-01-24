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
    public class MapperBusqueda
    {
        public static List<Busqueda> ListarUrlPaginasFront(string dato)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dato", DbType.String, ParameterDirection.Input, dato));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("BuscarEnFrontEnd", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                    .Select(dataRow => new Busqueda
                    {
                        UrlPagina = dataRow.Field<string>("UrlPagina")

                    }).ToList();

                    return empList;
                }

                List<Busqueda> lista = new List<Busqueda>();
                return lista;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static List<Busqueda> ListarUrlPaginasBack(string dato)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Dato", DbType.String, ParameterDirection.Input, dato));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("BuscarEnBackEnd", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                    .Select(dataRow => new Busqueda
                    {
                        UrlPagina = dataRow.Field<string>("UrlPagina")

                    }).ToList();

                    return empList;
                }

                List<Busqueda> lista = new List<Busqueda>();
                return lista;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
