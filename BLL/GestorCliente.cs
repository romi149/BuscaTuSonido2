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

        public static bool Agregar(Cliente cli)
        {
            return MapperCliente.InsertarCliente(cli);
        }

        public static List<Cliente> ObtenerDatosCliente(string dni, string nombre)
        {
            return MapperCliente.ListarDatosCliente(dni, nombre);

        }

        public static bool Actualizar(Cliente cli)
        {
            return MapperCliente.ActualizarDatosCliente(cli);
        }

        public static bool ModificarPassCliente(Usuario user, Cliente cli)
        {
            return MapperCliente.ActualizarPassCliente(user, cli);
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
