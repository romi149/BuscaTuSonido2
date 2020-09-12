using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MPP.Helpers;

namespace MPP
{
    public class MapperProducto
    {
        /// <summary>
        /// Retorna todos los productos de la Bd
        /// </summary>
        /// <returns></returns>
        public static List<ProductoTbl> ListarProductos()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Producto> productos = (from tblProducto in BaseDeDatos.Producto
                                        select tblProducto).Take(10).ToList();

                List<ProductoTbl> lista = new List<ProductoTbl>();

                foreach (var item in productos)
                {
                    lista.Add(ConvertirProducto(item));
                }

                return lista;
            }
            catch (Exception e)
            {

                return new List<ProductoTbl>();
            }
        }


        private static ProductoTbl ConvertirProducto(Producto producto)
        {
            ProductoTbl prod = new ProductoTbl();
            prod.Nombre = producto.Nombre;
            prod.Descripcion = producto.Descripcion;
            prod.Precio = float.Parse(producto.Precio.ToString());
            

            return prod;
        }

        /// <summary>
        /// Inserta un producto en Bd
        /// </summary>
        /// <param name="producto">Tipo Producto</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarProducto(Producto producto)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarProducto(producto.Upc, producto.Nombre, producto.Descripcion,
                producto.Categoria,
                producto.TipoInstrumento,
                producto.IdMarca,
                int.Parse(producto.Modelo),
                producto.CodProveedor,
                producto.IdProveedor,
                producto.Color,
                producto.Estado,
                producto.Precio);
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Actualiza un producto en Bd
        /// </summary>
        /// <param name="producto">Tipo Producto</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool Actualizar(Producto producto)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.ActualizarProducto(producto.IdProd, producto.Upc, producto.Nombre,
                producto.Descripcion,
                producto.Categoria,
                producto.TipoInstrumento,
                producto.IdMarca,
                int.Parse(producto.Modelo),
                producto.CodProveedor,
                producto.IdProveedor,
                producto.Color,
                producto.Estado,
                producto.Precio);
            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina un producto en Bd
        /// </summary>
        /// <param name="producto">Tipo Producto</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public bool Borrar(Producto producto)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.EliminarProducto(producto.IdProd);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
