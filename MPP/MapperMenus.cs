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
    public class MapperMenus
    {
        /// <summary>
        /// Retorna todos los menus de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarMenus()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarMenus", ListaParametros);

                return respuesta;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Retorna los menus que forman el menu vertical de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<Menu> ListarMenuVertical()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarMenuVertical", ListaParametros);
                if (respuesta != null)
                {
                    var empList = respuesta.Tables[0].AsEnumerable()
                      .Select(dataRow => new Menu
                      {
                          NombreMenu = dataRow.Field<string>("NombreControl")

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
        /// Inserta un menu en Bd
        /// </summary>
        /// <param name="menu"></param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarMenu(string nombre, string descripcion, string ubicacion)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreMenu", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("UbicacionMenu", DbType.String, ParameterDirection.Input, ubicacion));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarMenu", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un menu en Bd
        /// </summary>
        /// <param name="Id">Menu</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarMenu(int Id, string nombre, string descripcion, string ubicacion)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMenu", DbType.String, ParameterDirection.Input, Id));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreMenu", DbType.String, ParameterDirection.Input, nombre));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descripcion));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("UbicacionMenu", DbType.String, ParameterDirection.Input, ubicacion));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarMenu", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }


        }

        /// <summary>
        /// Elimina un menu en Bd
        /// </summary>
        /// <param name="Id">Menu</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarMenu(int Id)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdMenu", DbType.Int32, ParameterDirection.Input, Id));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarMenu", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }

        }
    }
}
