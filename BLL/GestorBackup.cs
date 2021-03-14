using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorBackup
    {
        public static bool RealizarRestore(string ruta)
        {
            try
            {
                return MapperBackup.RealizarRestore(ruta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool RealizarBackup(string destino)
        {
            try
            {
                return MapperBackup.RealizarBackup(destino);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
