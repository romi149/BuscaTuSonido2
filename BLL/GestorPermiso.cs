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
    public class GestorPermiso
    {
        public static List<Permiso> ObtenerPermisos()
        {
            return MapperPermiso.ListarPermisos();

        }

        public static DataSet Listar()
        {
            return MapperPermiso.ListarPermisosDS();
        }

        public static bool Agregar(Permiso per)
        {
            return MapperPermiso.InsertarPermiso(per);
        }

        public static bool Modificar(Permiso per)
        {
            return MapperPermiso.ActualizarPermiso(per);
        }

        public static bool Eliminar(int IdPermiso)
        {
            return MapperPermiso.EliminarPermiso(IdPermiso);
        }

        public static bool AgregarPermisoRol(Permiso per, Rol rol)
        {
            return MapperPermiso.InsertarPermisoRol(per, rol);
        }

        public static bool EliminarPermisoRol(int idPermisoRol)
        {
            return MapperPermiso.EliminarPermisoRol(idPermisoRol);
        }

        public static DataSet ListarPermisoRol()
        {
            return MapperPermiso.ListarPermisosRolDS();
        }

    }
}
