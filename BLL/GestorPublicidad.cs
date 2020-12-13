using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorPublicidad
    {
        public static DataSet Listar()
        {
            return MapperPublicidad.ListarPublicidad();

        }

        public static bool Agregar(string imageUrl, string navigateUrl, string fechaInicio,
                                     string fechaFin)
        {
            return MapperPublicidad.InsertarPublicidad(imageUrl, navigateUrl, fechaInicio, fechaFin);
        }

        public static bool Modificar(int Id, string imageUrl, string navigateUrl, string fechaInicio,
                                     string fechaFin)
        {
            return MapperPublicidad.ActualizarPublicidad(Id, imageUrl, navigateUrl, fechaInicio, fechaFin);
        }

        public static bool Eliminar(int Id)
        {
            return MapperPublicidad.EliminarPublicidad(Id);
        }

        public static List<Publicidad> ListarActuales()
        {
            return MapperPublicidad.ListarPublicidadActual();
        }
    }
}

