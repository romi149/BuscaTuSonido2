using BE;
using MPP;
using System;
using System.Collections.Generic;
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

        public static bool Agregar(string nombre, string apellido, string email, string tel,
                                   string domEntrega, int domFact, string pass, int dni)
        {
            return MapperCliente.InsertarCliente(nombre,apellido,email,tel,domEntrega,domFact,pass,dni);
        }

    }
}
