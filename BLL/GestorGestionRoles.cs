using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorGestionRoles
    {
        static public List<Rol> ListarRoles()
        {
            return MapperGestionRoles.ListarRoles();
        }

        static public bool AgregarRol(string nombre, string descrip, string tipoRol)
        {
            return MapperGestionRoles.InsertarRol(nombre, descrip, tipoRol);
        }

        static public bool EliminarRol(int IdRol)
        {
            return MapperGestionRoles.EliminarRol(IdRol);
        }

        static public List<Rol> ListarRolesAsignados(int IdUser)
        {
            return MapperGestionRoles.ListarRolesAsignados(IdUser);
        }

        static public List<Permiso> ListarPermisos()
        {
            return MapperGestionRoles.ListarPermisos();
        }

        static public List<Permiso> ListarPermisosAsignados(int IdRol)
        {
            return MapperGestionRoles.ListarPermisosAsignados(IdRol);
        }

        static public bool AsignarRol(int IdRol, int IdUser)
        {
            return MapperGestionRoles.AsignarRol(IdRol, IdUser);
        }

        static public bool EliminarRolAsignado(int IdRol)
        {
            return MapperGestionRoles.EliminarRolAsignado(IdRol);
        }

        static public bool AsignarPermisos(int IdPermiso, int IdRol)
        {
            return MapperGestionRoles.AsignarPermiso(IdPermiso, IdRol);
        }

        static public bool EliminarPermisoAsignado(int IdPermiso)
        {
            return MapperGestionRoles.EliminarPermisoAsignado(IdPermiso);
        }
    }
}
