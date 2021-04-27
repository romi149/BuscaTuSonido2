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
    public class GestorOpinion
    {
        public static bool Agregar(Opinion op)
        {
            return MapperOpinion.InsertarOpinion(op);
        }

        public static bool AgregarEncuesta(Opinion op)
        {
            return MapperOpinion.InsertarEncuesta(op);
        }

        public static bool ModificarEncuesta(Opinion op)
        {
            return MapperOpinion.ActualizarEncuesta(op);
        }

        public static bool Eliminar(int id)
        {
            return MapperOpinion.Eliminar(id);
        }

        public static DataSet VerificarFechaEncuesta(string fechaInicio)
        {
            return MapperOpinion.VerificarFechaEncuesta(fechaInicio);
        }

        public static List<Opinion> ListarEncuestas()
        {
            return MapperOpinion.ListarEncuestasSemana();

        }

        public static DataSet ListarTodasEncuestas()
        {
            return MapperOpinion.ListarTodasEncuestas();
        }

        public static int ObtenerPuntaje1(int IdEncuesta)
        {
            return MapperOpinion.ObtenerPuntajeEncuesta1(IdEncuesta);
        }

        public static int ObtenerPuntaje2(int IdEncuesta)
        {
            return MapperOpinion.ObtenerPuntajeEncuesta2(IdEncuesta);
        }

        public static bool AgregarVoto(int IdEncuesta, string opcion)
        {
            return MapperOpinion.InsertarPuntaje(IdEncuesta, opcion);
        }

        //public static DataSet ObtenerResultadosPregunta1()
        //{
        //    return MapperOpinion.ObtenerResultPregunta1();
        //}

        public static List<OpinionReporte> ObtenerResultadosPregunta1()
        {
            return MapperOpinion.ObtenerResultPregunta1();
        }

        public static List<OpinionReporte> ObtenerResultadosPregunta2()
        {
            return MapperOpinion.ObtenerResultPregunta2();
        }

        public static List<OpinionReporte> ObtenerResultadosPregunta3()
        {
            return MapperOpinion.ObtenerResultPregunta3();
        }

        public static List<OpinionReporte> ObtenerResultadosPregunta4()
        {
            return MapperOpinion.ObtenerResultPregunta4();
        }

        public static string ObtenerPregunta(int Id)
        {
            return MapperOpinion.ObtenerPregunta(Id);
        }

        public static List<Opinion> ObtenerFechaInicio(int Id)
        {
            return MapperOpinion.ObtenerFechaInicio(Id);
        }

        public static List<Opinion> ObtenerFechaFin(int Id)
        {
            return MapperOpinion.ObtenerFechaFin(Id);
        }
    }
}
