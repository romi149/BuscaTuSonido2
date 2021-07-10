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

        public static bool Agregar(Publicidad pub)
        {
            return MapperPublicidad.InsertarPublicidad(pub);
        }

        public static bool Modificar(Publicidad pub)
        {
            return MapperPublicidad.ActualizarPublicidad(pub);
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

