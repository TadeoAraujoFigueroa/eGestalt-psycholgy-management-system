using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;

namespace BLL
{
    public class BLLDatos
    {
        MPPDatos mppDatos;

        public List<BEDatos> retornarDias() 
        {
            mppDatos = new MPPDatos();
            return mppDatos.retornarDias();
        }
        public List<BEDatos> retornarJornada()
        {
            mppDatos = new MPPDatos();
            return mppDatos.retornarJornada();
        }
        public List<BEDatos> retornarSalas()
        {
            mppDatos = new MPPDatos();
            return mppDatos.retornarSalas();
        }

        public bool CrearXml()
        {
            try
            {
                mppDatos = new MPPDatos();
                return mppDatos.CrearXml();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
