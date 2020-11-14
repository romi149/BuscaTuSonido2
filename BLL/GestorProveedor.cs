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

        public static int ObtenerId(string codProv)
        {
            return MapperProveedor.ObtenerIdProveedor(codProv);
        }

        public static List<Proveedor> ListarProveedor()
        {
            return MapperProveedor.ListarProveedor();
        }

        public static bool Agregar(string codProveedor, string nombreEmpesa, string razonSocial, string dom,
                                   string email, string tel, string descrip, string cui)
        {
            return MapperProveedor.InsertarProveedor(codProveedor,nombreEmpesa,razonSocial,dom,email,
                                                        tel,descrip,cui);
        }

        public static bool Modificar(int IdProveedor, string codProveedor, string nombreEmpesa, string razonSocial, 
                                    string dom, string email, string tel, string descrip, string cui)
        {
            return MapperProveedor.ActualizarProveedor(IdProveedor, codProveedor, nombreEmpesa, razonSocial, dom, 
                                                        email,tel, descrip, cui);
        }

        public static bool Eliminar(int IdProveedor)
        {
            return MapperProveedor.EliminarProveedor(IdProveedor);
        }
    }
}

