using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperMarca
    {
        /// <summary>
        /// Retorna todas las marcas de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Marca> ListarMarcas()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Marca> marcas = (from tblMarca in BaseDeDatos.Marca
                                        select tblMarca).ToList();
                return marcas;
            }
            catch (Exception e)
            {

                return new List<Marca>();
            }
        }

        /// <summary>
        /// Inserta una marca en Bd
        /// </summary>
        /// <param name="marca">Tipo Marca</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarMarca(Marca marca)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarMarca(marca.Nombre, marca.Descripcion);
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Actualiza una marca en Bd
        /// </summary>
        /// <param name="marca">Tipo Marca</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool Actualizar(Marca marca)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.ActualizarMarca(marca.IdMarca, marca.Nombre, marca.Descripcion);
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina una marca en Bd
        /// </summary>
        /// <param name="marca">Tipo Marca</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public bool Borrar(Marca marca)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.EliminarMarca(marca.IdMarca);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
