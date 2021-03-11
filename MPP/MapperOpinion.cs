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

        public static bool InsertarEncuesta(int NroPregunta, string Pregunta, string tipo,
                                            string fechaInicio, string fechaFin, string opcion1,
                                            string opcion2, string img1, string img2)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NroPregunta", DbType.Int32, ParameterDirection.Input, NroPregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombrePregunta", DbType.String, ParameterDirection.Input, Pregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Tipo", DbType.String, ParameterDirection.Input, tipo));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaInicio", DbType.String, ParameterDirection.Input, fechaInicio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaFin", DbType.String, ParameterDirection.Input, fechaFin));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Opcion1", DbType.String, ParameterDirection.Input, opcion1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Opcion2", DbType.String, ParameterDirection.Input, opcion2));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Img1", DbType.String, ParameterDirection.Input, img1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Img2", DbType.String, ParameterDirection.Input, img2));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarEncuesta", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool Eliminar(int id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.Int32, ParameterDirection.Input, id));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarEncuesta", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static List<Opinion> ListarEncuestasSemana()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarEncuestasDelaSemana", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Opinion
                      {
                          Id = dataRow.Field<Int32>("Id"),
                          NombrePregunta = dataRow.Field<string>("NombrePregunta"),
                          Tipo = dataRow.Field<string>("Tipo"),
                          Opcion1 = dataRow.Field<string>("Opcion1"),
                          Opcion2 = dataRow.Field<string>("Opcion2"),
                          UrlOpcion1 = dataRow.Field<string>("UrlImagen1"),
                          UrlOpcion2 = dataRow.Field<string>("UrlImagen2")

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

        public static int ObtenerPuntajeEncuesta1(int idEncuesta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdEncuesta", DbType.Int32, ParameterDirection.Input, idEncuesta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerPuntajeEncuestaValor1", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<int>("Valor1");

                    return empList;
                }

                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public static int ObtenerPuntajeEncuesta2(int idEncuesta)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdEncuesta", DbType.Int32, ParameterDirection.Input, idEncuesta));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerPuntajeEncuestaValor2", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable().FirstOrDefault().Field<int>("Valor2");

                    return empList;
                }

                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public static bool InsertarPuntaje(int idEncuesta, string opcion)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdEncuesta", DbType.Int32, ParameterDirection.Input, idEncuesta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Opcion", DbType.String, ParameterDirection.Input, opcion));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPuntajeEncuesta", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static DataSet ListarTodasEncuestas()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarTodasLasEncuestas", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static DataSet VerificarFechaEncuesta(string fechaIncio)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaInicio", DbType.String, ParameterDirection.Input, fechaIncio));
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("VerificarFechaInicioEncuesta", ListaParametros);
                if (respuesta != null)
                {
                    return respuesta;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static bool ActualizarEncuesta(int id, string Pregunta, string fechaInicio,
                                            string fechaFin, string opcion1,
                                            string opcion2, string img1, string img2)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdEncuesta", DbType.Int32, ParameterDirection.Input, id));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombrePregunta", DbType.String, ParameterDirection.Input, Pregunta));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaInicio", DbType.String, ParameterDirection.Input, fechaInicio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaFin", DbType.String, ParameterDirection.Input, fechaFin));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Opcion1", DbType.String, ParameterDirection.Input, opcion1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Opcion2", DbType.String, ParameterDirection.Input, opcion2));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("UrlImagen1", DbType.String, ParameterDirection.Input, img1));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("UrlImagen2", DbType.String, ParameterDirection.Input, img2));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarEncuesta", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static DataSet ObtenerResultPregunta1()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ObtenerResultadosPregunta1", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
