using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAP;

namespace BLL
{
    public class BLLGestorBD
    {
        MPPGestorBD mppGestorBd;
        public bool CrearBackUp() 
        {
            try
            {
                mppGestorBd = new MPPGestorBD();
                return mppGestorBd.CrearBackUp();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public bool RealizarRestore(DateTime fecha) 
        {
            try
            {
                mppGestorBd = new MPPGestorBD();
                return mppGestorBd.RealizarRestore(fecha);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
