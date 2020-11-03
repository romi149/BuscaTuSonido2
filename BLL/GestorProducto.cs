using BE;
using MPP;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorProducto
    {
        public static List<Producto> ObtenerCatalogo()
        {
            return MapperProducto.ListarProductosTOP();

        }

        public static bool Agregar(string upc, string nombre, string descrip, string categ, string TipoInst,
                                     int IdMarca, string modelo, string codProveedor, int IdProveedor, string color,
                                     string estado, string precio)
        {
            return MapperProducto.InsertarProducto(upc,nombre,descrip,categ,TipoInst,IdMarca,modelo,codProveedor,
                                                    IdProveedor,color,estado,precio);
        }

        public static bool Modificar(int IdProd, string upc, string nombre, string descrip, string categ, string TipoInst,
                                     int IdMarca, string modelo, string codProveedor, int IdProveedor, string color,
                                     string estado, string precio)
        {
            return MapperProducto.ActualizarProducto(IdProd, upc, nombre, descrip, categ, TipoInst, IdMarca, modelo, codProveedor,
                                                    IdProveedor, color, estado, precio);
        }

        public static bool Eliminar(int IdProd)
        {
            return MapperProducto.EliminarProducto(IdProd);
        }

        public static Producto ListarDetalleProducto(string nombre, string modelo)
        {
            return MapperProducto.ListarDetalleProducto(nombre, modelo);
        }

        public static DataSet ListarProductos()
        {
            return MapperProducto.ListarProductos();
        }

        public static List<Producto> ListarProdCuerdas()
        {
            return MapperProducto.ListarInstCuerdas();
        }

        public static List<Producto> ListarProdViento()
        {
            return MapperProducto.ListarInstViento();
        }

        public static List<Producto> ListarProdPercusion()
        {
            return MapperProducto.ListarInstPercusion();
        }

        public static List<Producto> ListarProdElectronicos(string nombre)
        {
            return MapperProducto.ListarInstElectronicos(nombre);
        }

        public static string GestionImagen(string NombreImg, string Categoria)
        {
            return MapperProducto.ObtenerRutaImagen(NombreImg, Categoria);
        }

        public static bool AgregarImg(string nombre, string categ, string url)
        {
            return MapperProducto.InsertarImagen(nombre, categ, url);
        }
    }
}
