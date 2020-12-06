using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorCliente
    {
        public static Cliente ValidadMailCliente(string email)
        {
            return MapperCliente.ValidarEmail(email);
        }

        public static Cliente ValidadRolCliente(string user)
        {
            return MapperCliente.ValidarCliente(user);
        }

        public static bool Agregar(string nombre, string apellido, string email, string tel,
                                   string domEntrega, string domFact, string pass, string dni, string user)
        {
            return MapperCliente.InsertarCliente(nombre,apellido,email,tel,domEntrega,domFact,pass,dni,user);
        }

        public static List<Cliente> ObtenerDatosCliente(string dni, string nombre)
        {
            return MapperCliente.ListarDatosCliente(dni, nombre);

        }

        public static bool Actualizar(int codCliente, string nombre, string apellido, string email, string tel,
                                  string domEntrega, string domFact, string dni, string user)
        {
            return MapperCliente.ActualizarDatosCliente(codCliente, nombre, apellido, email, tel, domEntrega, domFact, dni, user);
        }

        public static bool ModificarPassCliente(int IdUser, string pass, int codigoCliente)
        {
            return MapperCliente.ActualizarPassCliente(IdUser, pass, codigoCliente);
        }

        public static DataSet ListarCompras(string usuario)
        {
            return MapperCliente.ListarComprasCliente(usuario);
        }

        public static Cliente ObtenerEmailCliente(string user)
        {
            return MapperCliente.ObtenerEmailCliente(user);
        }

        public static Cliente ObtenerCodCliente(string user)
        {
            return MapperCliente.ObtenerCodCliente(user);
        }
    }
}
