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

        public static DataSet ListarMarcas()
        {
            return MapperMarca.ListarMarcasDT();

        }

        public static bool Agregar(string nombre, string descrip)
        {
            return MapperMarca.InsertarMarca(nombre, descrip);
        }

        public static bool Modificar(int Id, string nombre, string descrip)
        {
            return MapperMarca.ActualizarMarca(Id, nombre, descrip);
        }

        public static bool Eliminar(int Id)
        {
            return MapperMarca.EliminarMarca(Id);
        }
    }
}
