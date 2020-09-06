using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperPrecio
    {
        /// <summary>
        /// Retorna todos los precios de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Precio> ListarPrecios()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Precio> precios = (from tblPrecios in BaseDeDatos.Precio
                                          select tblPrecios).ToList();
                return precios;
            }
            catch (Exception e)
            {

                return new List<Precio>();
            }
        }

        /// <summary>
        /// Inserta un precio en Bd
        /// </summary>
        /// <param name="precio">Tipo Precio</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarPrecio(Precio precio)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarPrecio(precio.Fecha, precio.PrecioCompra, precio.PrecioAnterior,
                precio.PorcentajeVenta,
                precio.PrecioPublicado,
                precio.Descripcion);
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Actualiza un precio en Bd
        /// </summary>
        /// <param name="precio">Tipo Precio</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool Actualizar(Precio precio)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.ActualizarPrecio(precio.IdPrecio, precio.Fecha,
                precio.PrecioCompra,
                precio.PrecioAnterior,
                precio.PorcentajeVenta,
                precio.PrecioPublicado,
                precio.Descripcion);
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina un precio en Bd
        /// </summary>
        /// <param name="precio">Tipo Precio</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public bool Borrar(Precio precio)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.EliminarPrecio(precio.IdPrecio);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
