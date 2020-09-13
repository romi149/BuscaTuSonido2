using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorPrecio
    {
        public static List<Precio> ObtenerPrecios()
        {
            return MapperPrecio.ListarPrecios();

        }

        public static bool Agregar(DateTime fecha, float precioCompra, float precioAnterior,
                                        float precioPublicado, string descrip)
        {
            return MapperPrecio.InsertarPrecio(fecha,precioCompra,precioAnterior, precioPublicado,descrip);
        }

        public static bool Modificar(int IdPrecio, DateTime fecha, float precioCompra, float precioAnterior,
                                        float precioPublicado, string descrip)
        {
            return MapperPrecio.ActualizarPrecio(IdPrecio, fecha, precioCompra, precioAnterior, precioPublicado, descrip);
        }

        public static bool Eliminar(int IdPrecio)
        {
            return MapperPrecio.EliminarPrecio(IdPrecio);
        }
    }
}
