﻿using BE;
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
    public class MapperPublicidad
    {
        public static DataSet ListarPublicidad()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPublicidad", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static bool InsertarPublicidad(Publicidad pub)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("ImageUrl", DbType.String, ParameterDirection.Input, pub.ImageUrl));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NavigateUrl", DbType.String, ParameterDirection.Input, pub.NavigateUrl));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaInicio", DbType.String, ParameterDirection.Input, pub.FechaInicio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaFin", DbType.String, ParameterDirection.Input, pub.FechaFin));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarPublicidad", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ActualizarPublicidad(Publicidad pub)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.Int32, ParameterDirection.Input, pub.Id));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("ImageUrl", DbType.String, ParameterDirection.Input, pub.ImageUrl));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NavigateUrl", DbType.String, ParameterDirection.Input, pub.NavigateUrl));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaInicio", DbType.String, ParameterDirection.Input, pub.FechaInicio));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("FechaFin", DbType.String, ParameterDirection.Input, pub.FechaFin));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarPublicidad", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool EliminarPublicidad(int id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Id", DbType.Int32, ParameterDirection.Input, id));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarPublicidad", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static List<Publicidad> ListarPublicidadActual()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarPublicidadActual", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Publicidad
                      {
                          Id = dataRow.Field<Int32>("Id"),
                          ImageUrl = dataRow.Field<string>("ImageUrl"),
                          NavigateUrl = dataRow.Field<string>("NavigateUrl"),
                          FechaInicio = dataRow.Field<string>("FechaInicio"),
                          FechaFin = dataRow.Field<string>("FechaFin")
                          
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
