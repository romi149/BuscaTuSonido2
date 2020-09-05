using DAL;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MapperUsuario
    {
       public static UsuarioTbl ValidarUsuario(string user, string pass)
        {
            try
            {
                BTSDataContext BaseDatos = new BTSDataContext();
                var listausuarios = (from lista in BaseDatos.Usuario
                                     select lista).ToList();

                foreach (var item in listausuarios)
                {
                    if (item.Usuario1.Equals(user.Trim()) && item.Usuario1.Equals(pass.Trim()))
                    {
                        return ConvertirUsuario(item);
                    }
                }

                return null;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        private static UsuarioTbl ConvertirUsuario(Usuario usuario)
        {
            UsuarioTbl user = new UsuarioTbl();
            user.Usuario1 = usuario.Usuario1;
            user.Nombre = usuario.Nombre;
            user.Apellido = usuario.Apellido;
            user.IdIdioma = usuario.IdIdioma;
            user.Dni = usuario.Dni;

            return user;
        }
    }
}
