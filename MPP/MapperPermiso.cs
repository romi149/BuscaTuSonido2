using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperPermiso
    {
        /// <summary>
        /// Retorna todos los permisos de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ListarPermisos()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Permiso> permisos = (from tblPermiso in BaseDeDatos.Permiso
                                   select tblPermiso).ToList();
                return permisos;
            }
            catch (Exception e)
            {

                return new List<Permiso>();
            }
        }

        /// <summary>
        /// Inserta un Permiso en Bd
        /// </summary>
        /// <param name="permiso">Tipo Permiso</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarPermiso(Permiso permiso)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarPermiso(permiso.Nombre, permiso.Descripcion, permiso.TipoPermiso);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Actualiza un permiso en Bd
        /// </summary>
        /// <param name="permiso">Tipo permiso</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool Actualizar(Permiso permiso)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.ActualizarPermiso(permiso.IdPermiso, permiso.Nombre, permiso.Descripcion, 
                permiso.TipoPermiso);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina un permiso en Bd
        /// </summary>
        /// <param name="permiso">Tipo Permiso</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public bool Eliminar(Permiso permiso)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.EliminarPermiso(permiso.IdPermiso);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
