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

        public static List<Producto> ListarCategorias()
        {
            return MapperProducto.ListarCategorias();
        }

        public static List<Producto> ListarProdPorCategoria(string nombre)
        {
            return MapperProducto.ListarProductosPorCategoria(nombre);
        }

        public static string GestionImagen(string NombreImg, string Categoria)
        {
            return MapperProducto.ObtenerRutaImagen(NombreImg, Categoria);
        }

        public static bool AgregarImg(string nombre, string categ, string url)
        {
            return MapperProducto.InsertarImagen(nombre, categ, url);
        }

        public static List<Producto> ListarProductosAComparar(string nombre)
        {
            return MapperProducto.ListarProductosAComparar(nombre);
        }

        public static bool InsertarPregunta(string NombreProducto, string modelo, string pregunta, string usuario)
        {
            return MapperProducto.InsertarPregunta(NombreProducto, modelo, pregunta, usuario);
        }

        public static List<Preguntas> ListarPreguntas(string nombre, string modelo)
        {
            return MapperProducto.ListarPreguntas(nombre, modelo);
        }

        public static List<Producto> ListarProductosBuscados(string marca, string categoria)
        {
            return MapperProducto.ListarProductosBuscados(marca, categoria);
        }
    }
}
