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

        public static bool Agregar(BE.Menu menu)
        {
            return MapperMenus.InsertarMenu(menu);
        }

        public static bool Modificar(BE.Menu menu)
        {
            return MapperMenus.ActualizarMenu(menu);
        }

        public static bool Eliminar(int Id)
        {
            return MapperMenus.EliminarMenu(Id);
        }
    }
}
