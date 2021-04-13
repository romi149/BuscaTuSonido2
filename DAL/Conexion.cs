using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Conexion
    {
        //private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());
        private SqlConnection conexion { get; set; }
        private Conexion()
        {
            var config = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString();
            //var config = "Data Source=.;Initial Catalog=BTS;Integrated Security=True";
            conexion = new SqlConnection(config);
        }

        private static Conexion instancia;
        public static Conexion GetInstance
        {
            get
            {
                if (instancia == null)
                    instancia = new Conexion();
                return instancia;
            }
        }
        //public DataTable Leer(string comando)
        //{
        //    DataTable tabla = new DataTable();
        //    try
        //    {
        //        conexion.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conexion;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = comando;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);

        //        da.Fill(tabla);
        //        conexion.Close();
        //        return tabla;
        //    }
        //    catch (SqlException ex)
        //    {
        //        conexion.Close();
        //        throw ex;
        //    }

        //}
        //public int Escribir(string comando)
        //{
        //    try
        //    {
        //        conexion.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conexion;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = comando;
        //        int filas;
        //        filas = cmd.ExecuteNonQuery();
        //        conexion.Close();
        //        return filas;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        public bool EjecutarStore(string nombreStore, List<SqlParameter> Parametros = null)
        {
            bool resultado = false;
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreStore, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Parametros != null)
                {
                    foreach (var item in Parametros)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                int response = cmd.ExecuteNonQuery();
                resultado = true;
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }

            return resultado;
        }
        public DataSet RetornarDataReaderDeStore(string nombreStore, List<SqlParameter> Parametros = null)
        {
            try
            {
                DataSet ds = new DataSet();
                var command = new SqlCommand(nombreStore, conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                if (Parametros != null)
                {
                    foreach (var item in Parametros)
                    {
                        command.Parameters.Add(item);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                conexion.Close();
                return ds;
            }
            catch (Exception e)
            {
                conexion.Close();
                throw e;
            }


        }

        public bool RealizarRestore(String ruta)
        {
            try
            {
                var nombreBaseDeDatos = conexion.Database.ToString();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                string sqlStmt2 = string.Format("USE MASTER RESTORE DATABASE[BTS] FROM  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQL2019\\MSSQL\\Backup\\BTS.bak' WITH  FILE = 5, NOUNLOAD, REPLACE, STATS = 5");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, conexion);
                bu2.ExecuteNonQuery();
                
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                conexion.Close();
                throw new Exception($"No se pudo Realizar Restore se la base de datos en la ruta:" +
                    $"\n Ruta:{ruta} \n MensajeDeError:{e.Message}");
            }
        }

        public bool RealizarBackup()
        {
            try
            {
                var nombreBaseDeDatos = conexion.Database.ToString();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                string sqlStmt2 = string.Format("BACKUP DATABASE [BTS] TO  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQL2019\\MSSQL\\Backup\\BTS.bak' WITH NOFORMAT, NOINIT," +
                    "NAME = N'BTS-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, conexion);
                bu2.ExecuteNonQuery();

                conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                conexion.Close();
                throw new Exception($"No se pudo Realizar el backup \n MensajeDeError:{e.Message}");
            }
        }
    }
}