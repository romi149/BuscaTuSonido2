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
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());


        public DataTable Leer(string comando)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = comando;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(tabla);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            conexion.Close();

            return tabla;
        }

        public int Escribir(string comando)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = comando;

            int filas;

            try
            {
                filas = cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                filas = -1;
            }

            conexion.Close();
            return filas;
        }

    }
}
