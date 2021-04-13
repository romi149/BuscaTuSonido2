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
    public class GestorMarca
    {
        public static List<Marca> Listar()
        {
            return MapperMarca.ListarMarcas() ;

        }

        public static int ObtenerId(string nombreMarca)
        {
            return MapperMarca.ObtenerIdMarca(nombreMarca);
        }

        public static DataSet ListarMarcas()
        {
            return MapperMarca.ListarMarcasDT();

        }

        public static bool Agregar(Marca marca)
        {
            return MapperMarca.InsertarMarca(marca);
        }

        public static bool Modificar(Marca marca)
        {
            return MapperMarca.ActualizarMarca(marca);
        }

        public static bool Eliminar(int Id)
        {
            return MapperMarca.EliminarMarca(Id);
        }
    }
}
