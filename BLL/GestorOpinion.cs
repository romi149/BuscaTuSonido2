using BE;
using MPP;
using System;
using System.Collections.Generic;
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

        //public static bool Modificar()
        //{
        //    return MapperUsuario.ActualizarUsuario();
        //}

        public static List<Opinion> ListarEncuestas()
        {
            return MapperOpinion.ListarEncuestasSemana();

        }
    }
}
