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
    public class GestorMenu
    {
        public static DataSet Listar()
        {
            return MapperMenus.ListarMenus();
        }

        public static List<Menu> ObtenerMenuVertical()
        {
            return MapperMenus.ListarMenuVertical();

        }

        public static bool Agregar(string nombre, string desc, string ubic)
        {
            return MapperMenus.InsertarMenu(nombre, desc, ubic);
        }

        public static bool Modificar(int Id, string nombre, string desc, string ubi)
        {
            return MapperMenus.ActualizarMenu(Id, nombre, desc, ubi);
        }

        public static bool Eliminar(int Id)
        {
            return MapperMenus.EliminarMenu(Id);
        }
    }
}
