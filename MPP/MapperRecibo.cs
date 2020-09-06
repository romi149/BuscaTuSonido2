using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MapperRecibo
    {
        /// <summary>
        /// Retorna todos los recibos de la Bd
        /// </summary>
        /// <returns></returns>
        public List<Recibo> ListarRecibos()
        {
            try
            {
                BTSDataContext BaseDeDatos = new BTSDataContext();
                List<Recibo> recibos = (from tblRecibo in BaseDeDatos.Recibo
                                        select tblRecibo).ToList();
                return recibos;
            }
            catch (Exception e)
            {

                return new List<Recibo>();
            }
        }

        /// <summary>
        /// Inserta un Recibo en Bd
        /// </summary>
        /// <param name="recibo">Tipo Recibo</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public bool GenerarRecibo(Recibo recibo)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.GenerarRecibo(recibo.Fecha, recibo.CodCliente, recibo.Descripcion,
                recibo.ImporteTotal, recibo.Notas, recibo.Estado, recibo.NroFactura);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Anula un recibo en Bd
        /// </summary>
        /// <param name="recibo">Tipo recibo</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public bool AnularRecibo(Recibo recibo)
        {
            BTSDataContext BaseDeDatos = new BTSDataContext();
            int filasAFECTADAS = BaseDeDatos.AnularRecibo(recibo.NroRecibo);

            if (filasAFECTADAS > 0)
            {
                return true;
            }

            return false;
        }
    }
}
