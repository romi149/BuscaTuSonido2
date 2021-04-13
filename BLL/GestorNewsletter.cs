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
        public static bool Agregar(string titulo1, string texto1, string titulo2, string texto2,
                                    string NombreImg, int altoImg, int anchoImg, string fechaPub,
                                    string fechaFin)
        {
            return MapperNewsletter.InsertarNoticia(titulo1,texto1,titulo2,texto2,NombreImg,altoImg,
                                                    anchoImg,fechaPub,fechaFin);
        }

        public static bool ModificarNoticia(int id, string titulo1, string texto1, string titulo2, 
                                            string texto2, int altoImg, int anchoImg, 
                                            string fechaPub,string fechaFin)
        {
            return MapperNewsletter.ActualizarNoticia(id,titulo1, texto1, titulo2, texto2,altoImg,
                                                    anchoImg, fechaPub, fechaFin);
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
