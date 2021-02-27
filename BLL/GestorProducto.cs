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
                                     string modelo, string codProveedor, string color,
                                     string estado, string precio)
        {
            return MapperProducto.ActualizarProducto(IdProd, upc, nombre, descrip, categ, TipoInst, modelo, 
                                                    codProveedor, color, estado, precio);
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

        public static List<Producto> ListarTipoInstrumentos()
        {
            return MapperProducto.ListarTipoInstrumentos();
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

        public static DataSet ListarTotalPreguntas()
        {
            return MapperProducto.ListarTotalPreguntas();
        }

        public static List<Producto> ListarProductosBuscados(string marca, string categoria, string precio)
        {
            return MapperProducto.ListarProductosBuscados(marca, categoria, precio);
        }

        public static List<Producto> ListarProductosPorMarca(string marca)
        {
            return MapperProducto.ListarProductosPorMarca(marca);
        }

        public static List<Producto> ListarProductosCategoria(string categ)
        {
            return MapperProducto.ListarProductosCategoria(categ);
        }

        public static List<Producto> ListarProductosPorMarcaCat(string marca, string categ)
        {
            return MapperProducto.ListarProductosPorMarcaCategoria(marca, categ);
        }

        public static List<Producto> ListarProductosPorMarcaPrecio(string marca, string precio)
        {
            return MapperProducto.ListarProductosPorMarcaPrecio(marca, precio);
        }

        public static List<Producto> ListarProductosPorCatPrecio(string categoria, string precio)
        {
            return MapperProducto.ListarProductosPorCategoriaPrecio(categoria, precio);
        }

        public static List<Producto> ListarProductosPorPrecio(string precio)
        {
            return MapperProducto.ListarProductosPorPrecio(precio);
        }

        public static bool EliminarPregunta(int Id)
        {
            return MapperProducto.EliminarPregunta(Id);
        }

        public static bool AgregarRespuesta(int Id, string respuesta)
        {
            return MapperProducto.InsertarRespuesta(Id, respuesta);
        }

        public static bool InsertarPreguntaPersonal(string pregunta, string usuariocliente)
        {
            return MapperProducto.InsertarPreguntaPersonalizada(pregunta, usuariocliente);
        }

        public static List<Preguntas> ListarPreguntasCliente(string usuario)
        {
            return MapperProducto.ListarPreguntasPorCliente(usuario);
        }

        public static DataSet ObtenerOpionesProducto(string nombre)
        {
            return MapperProducto.ListarOpinionesProductos(nombre);
        }

        public static List<OpinionUsuario> ListarValoraciones(string nombre)
        {
            return MapperProducto.ListarValoracionesProducto(nombre);
        }

        public static bool AgregarValoracion(int puntaje, string comentario, int idUser, string nombreProd,
                                             string user)
        {
            return MapperProducto.InsertarValoracionProducto(puntaje,comentario,idUser,nombreProd,user);
        }

        public static DataSet ListarReporteTiempoRtaProductos()
        {
            return MapperProducto.ListarReporteTiempoRtaProductos();
        }

        public static DataSet ListarTiempoRtaProdFiltroTotal(string producto, string user,
                                                             string fechadesde, string fechahasta)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroTotal(producto,user,fechadesde,fechahasta);
        }

        public static DataSet ListarTiempoRtaProdFiltroFechaProd(string producto,
                                                             string fechadesde, string fechahasta)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroFechaProd(producto, fechadesde, fechahasta);
        }

        public static DataSet ListarTiempoRtaProdFiltroFechaUser(string user,
                                                             string fechadesde, string fechahasta)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroFechaUser(user, fechadesde, fechahasta);
        }

        public static DataSet ListarTiempoRtaProdFiltroFechas(string fechadesde, string fechahasta)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroFechas(fechadesde, fechahasta);
        }

        public static DataSet ListarTiempoRtaProdFiltroProdUser(string producto, string user)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroProdUser(producto, user);
        }

        public static DataSet ListarTiempoRtaProdFiltroProd(string producto)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroProd(producto);
        }

        public static DataSet ListarTiempoRtaProdFiltroUser(string user)
        {
            return MapperProducto.ListarTiempoRtaProdFiltroUser(user);
        }

        public static DataSet ListarReporteTiempoRtaClientes()
        {
            return MapperProducto.ListarReporteTiempoRtaClientes();
        }

        public static DataSet ListarTiempoRtaClienteFiltroTotal(string user,
                                                             string fechadesde, string fechahasta)
        {
            return MapperProducto.ListarTiempoRtaClienteFiltroTotal(user, fechadesde, fechahasta);
        }

        public static DataSet ListarTiempoRtaClienteFiltroFechas(string fechadesde, string fechahasta)
        {
            return MapperProducto.ListarTiempoRtaClienteFiltroFechas(fechadesde, fechahasta);
        }

        public static DataSet ListarTiempoRtaClientesFiltroUser(string user)
        {
            return MapperProducto.ListarTiempoRtaClientesFiltroUser(user);
        }

        public static string ObtenerPrecioProducto(string prod)
        {
            return MapperProducto.ObtenerPrecioProducto(prod);
        }
    }
}
