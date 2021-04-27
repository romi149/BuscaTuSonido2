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
    public class GestorNewsletter
    {
        public static DataSet ListarNoticias()
        {
            return MapperNewsletter.ListarNoticias();
        }
        public static bool Agregar(Newsletter news)
        {
            return MapperNewsletter.InsertarNoticia(news);
        }

        public static bool ModificarNoticia(Newsletter news)
        {
            return MapperNewsletter.ActualizarNoticia(news);
        }

        public static bool Eliminar(int id)
        {
            return MapperNewsletter.EliminarNoticia(id);
        }

        public static bool AgregarRutaImagen(string url, string nombreImg)
        {
            return MapperNewsletter.InsertarUrlImagen(url,nombreImg);
        }

        public static List<Newsletter> ListarNoticiaParaPublicar()
        {
            return MapperNewsletter.ListarNoticiaParaPublicar();
        }
    }
}
