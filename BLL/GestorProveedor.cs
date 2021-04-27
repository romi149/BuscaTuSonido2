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
    public class GestorProveedor
    {
        public static DataSet Listar()
        {
            return MapperProveedor.ListarProveedores();
        }

        public static int ObtenerId(string NombreEmpresa)
        {
            return MapperProveedor.ObtenerIdProveedor(NombreEmpresa);
        }

        public static string ObtenerCod(string NombreEmpresa)
        {
            return MapperProveedor.ObtenerCodProveedor(NombreEmpresa);
        }

        public static List<Proveedor> ListarProveedor()
        {
            return MapperProveedor.ListarProveedor();
        }

        public static bool Agregar(Proveedor prov)
        {
            return MapperProveedor.InsertarProveedor(prov);
        }

        public static bool Modificar(Proveedor prov)
        {
            return MapperProveedor.ActualizarProveedor(prov);
        }

        public static bool Eliminar(int IdProveedor)
        {
            return MapperProveedor.EliminarProveedor(IdProveedor);
        }
    }
}

