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

        public static bool Agregar(string nombre, string descrip, string tipoPermiso)
        {
            return MapperPermiso.InsertarPermiso(nombre, descrip, tipoPermiso);
        }

        public static bool Modificar(int IdPermiso, string nombre, string descrip, string tipoPermiso)
        {
            return MapperPermiso.ActualizarPermiso(IdPermiso, nombre, descrip, tipoPermiso);
        }

        public static bool Eliminar(int IdPermiso)
        {
            return MapperPermiso.EliminarPermiso(IdPermiso);
        }

        public static bool AgregarPermisoRol(int idPermiso, int idRol)
        {
            return MapperPermiso.InsertarPermisoRol(idPermiso, idRol);
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
