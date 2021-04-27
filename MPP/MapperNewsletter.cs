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
    public class MapperNewsletter
    {
        public static DataSet ListarNoticias()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarNoticias", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static bool InsertarNoticia(Newsletter nw)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Titulo1", DbType.String, ParameterDirection.Input, nw.Titulo1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Texto1", DbType.String, ParameterDirection.Input, nw.Texto1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Titulo2", DbType.String, ParameterDirection.Input, nw.Titulo2));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreImg", DbType.String, ParameterDirection.Input, nw.Img));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaPub", DbType.String, ParameterDirection.Input, nw.FechaPub));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaFin", DbType.String, ParameterDirection.Input, nw.FechaFin));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarNoticia", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ActualizarNoticia(Newsletter news)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.String, ParameterDirection.Input, news.Id));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Titulo1", DbType.String, ParameterDirection.Input, news.Titulo1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Texto1", DbType.String, ParameterDirection.Input, news.Texto1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Titulo2", DbType.String, ParameterDirection.Input, news.Titulo2));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaPub", DbType.String, ParameterDirection.Input, news.FechaPub));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaFin", DbType.String, ParameterDirection.Input, news.FechaFin));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarNoticia", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool EliminarNoticia(int Id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.Int32, ParameterDirection.Input, Id));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarNoticia", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static bool InsertarUrlImagen(string url, string nombreImg)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Url", DbType.String, ParameterDirection.Input, url));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreImg", DbType.String, ParameterDirection.Input, nombreImg));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarURLImagen", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Newsletter> ListarNoticiaParaPublicar()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarNoticiaAPublicar", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Newsletter
                      {
                          Id = dataRow.Field<Int32>("Id"),
                          Titulo1 = dataRow.Field<string>("Titulo1"),
                          Texto1 = dataRow.Field<string>("Texto1"),
                          Titulo2 = dataRow.Field<string>("Titulo2"),
                          //Texto2 = dataRow.Field<string>("Texto2"),
                          Img = dataRow.Field<string>("Img"),
                          //AltoImg = dataRow.Field<Int32>("AltoImg"),
                          //AnchoImg = dataRow.Field<Int32>("AnchoImg"),
                          FechaPub = dataRow.Field<DateTime>("FechaPublicacion"),
                          FechaFin = dataRow.Field<DateTime>("FechaFin")

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
