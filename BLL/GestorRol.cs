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

        public static bool Agregar(BE.Rol rol)
        {
            return MapperRol.InsertarRol(rol);
        }

        public static bool Modificar(BE.Rol rol)
        {
            return MapperRol.ActualizarRol(rol);
        }

        public static bool Eliminar(int IdRol)
        {
            return MapperRol.EliminarRol(IdRol);
        }
    }
}
