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
        public static bool Agregar(int NroPregunta, string Pregunta, int Puntaje, string tipo)
        {
            return MapperOpinion.InsertarOpinion(NroPregunta, Pregunta, Puntaje, tipo);
        }

        public static bool AgregarEncuesta(int NroPregunta, string Pregunta, string tipo,
                                            string fechaInicio, string fechaFin, string opcion1,
                                            string opcion2, string img1, string img2)
        {
            return MapperOpinion.InsertarEncuesta(NroPregunta, Pregunta, tipo, fechaInicio,
                                                 fechaFin, opcion1, opcion2, img1, img2);
        }

        public static bool ModificarEncuesta(int id, string Pregunta, string fechaInicio, 
                                            string fechaFin, string opcion1,
                                            string opcion2, string img1, string img2)
        {
            return MapperOpinion.ActualizarEncuesta(id, Pregunta, fechaInicio, fechaFin, 
                                                    opcion1, opcion2, img1, img2);
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
    }
}
