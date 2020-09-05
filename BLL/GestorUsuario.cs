using MPP;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorUsuario
    {
        public static UsuarioTbl ObtenerUsuario(string user, string pass)
        {
           var respuesta = MapperUsuario.ValidarUsuario(user, pass);

            if(respuesta != null)
            {

            }

            return respuesta;
        }

       
    }
}
