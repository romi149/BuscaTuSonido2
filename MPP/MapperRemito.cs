using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperRemito
    {
        /// <summary>
        /// Retorna todos los remitos de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Remito> ListarRemitos()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Remito> remitos = (from tblRemito in BaseDeDatos.Remito
                                          select tblRemito).ToList();
                return remitos;
            }
            catch (Exception e)
            {

                return new List<Remito>();
            }
        }

        /// <summary>
        /// Inserta un Remito en Bd
        /// </summary>
        /// <param name="remito">Tipo Remito</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool InsertarRemito(Remito remito)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.InsertarRemito(remito.Fecha, remito.NroPedido, remito.NroFactura,
                remito.Descripcion, remito.Notas, remito.Estado);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Anula un remito en Bd
        /// </summary>
        /// <param name="remito">Tipo remito</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool AnularRemito(Remito remito)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.AnularRemito(remito.NroRemito, remito.Estado);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }

        
    }
}
