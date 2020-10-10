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

        public static bool Agregar(string codProveedor, string nombreEmpesa, string razonSocial, string dom,
                                   string email, string tel, string descrip, long cui)
        {
            return MapperProveedor.InsertarProveedor(codProveedor,nombreEmpesa,razonSocial,dom,email,
                                                        tel,descrip,cui);
        }

        public static bool Modificar(int IdProveedor, string codProveedor, string nombreEmpesa, string razonSocial, 
                                    string dom, string email, string tel, string descrip, long cui)
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

