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
    public class GestorRol
    {
        public static DataSet Listar()
        {
            return MapperRol.ListarRolesDS();
        }

        public static List<Rol> ObtenerListadoRoles()
        {
            return MapperRol.ListarRoles();
        }

        public static bool Agregar(string nombre, string descrip, string tipoRol)
        {
            return MapperRol.InsertarRol(nombre,descrip,tipoRol);
        }

        public static bool Modificar(int IdRol, string nombre, string descrip, string tipoRol)
        {
            return MapperRol.ActualizarRol(IdRol,nombre,descrip,tipoRol);
        }

        public static bool Eliminar(int IdRol)
        {
            return MapperRol.EliminarRol(IdRol);
        }
    }
}
