using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperRol
    {
        /// <summary>
        /// Retorna todos los roles de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Rol> ListarRoles()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Rol> roles = (from tblRol in BaseDeDatos.Rol
                                          select tblRol).ToList();
                return roles;
            }
            catch (Exception e)
            {

                return new List<Rol>();
            }
        }

        /// <summary>
        /// Inserta un rol en Bd
        /// </summary>
        /// <param name="rol">Tipo Rol</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarRol(Rol rol)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarRol(rol.Nombre, rol.Descripcion, rol.TipoRol);
                
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Actualiza un rol en Bd
        /// </summary>
        /// <param name="rol">Tipo Rol</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool Actualizar(Rol rol)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.ActualizarRol(rol.IdRol, rol.Nombre, rol.Descripcion, rol.TipoRol);
                
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina un rol en Bd
        /// </summary>
        /// <param name="rol">Tipo Rol</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public bool Eliminar(Rol rol)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.EliminarRol(rol.IdRol);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
