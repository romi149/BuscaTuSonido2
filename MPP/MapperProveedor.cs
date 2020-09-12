using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperProveedor
    {
        /// <summary>
        /// Retorna todos los proveedores de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Proveedor> ListarProveedores()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Proveedor> proveedores = (from tblProveedor in BaseDeDatos.Proveedor
                                          select tblProveedor).ToList();
                return proveedores;
            }
            catch (Exception e)
            {

                return new List<Proveedor>();
            }
        }

        /// <summary>
        /// Inserta un Proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo Proveedor</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarProveedor(Proveedor proveedor)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarProveedor(proveedor.CodProveedor, proveedor.NombreEmpresa,
                proveedor.RazonSocial, proveedor.Domicilio, proveedor.Email, proveedor.Telefono, proveedor.Descripcion,
                int.Parse(proveedor.Cuit.ToString()));

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Actualiza un proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo proveedor</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool Actualizar(Proveedor proveedor)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.ActualizarProveedor(proveedor.IdProveedor, proveedor.CodProveedor,
                proveedor.NombreEmpresa, proveedor.RazonSocial, proveedor.Domicilio, proveedor.Email, proveedor.Telefono,
                proveedor.Descripcion, proveedor.Cuit?.ToString());

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina un proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo Proveedor</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public bool Eliminar(Proveedor proveedor)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.EliminarProveedor(proveedor.IdProveedor);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
