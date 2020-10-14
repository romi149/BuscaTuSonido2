using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorSuscripcion
    {
        static public DataSet Listar()
        {
            return MapperSuscripcion.ListarSuscripciones();
        }

        
        static public bool Agregar(string email, string nombre, string estado)
        {
            return MapperSuscripcion.InsertarSuscripcion(email, nombre, estado);
        }
    }
}
