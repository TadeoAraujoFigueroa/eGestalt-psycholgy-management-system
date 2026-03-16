using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;

namespace BLL
{
    public class BLLMetodoDePago
    {
        private MPPMetodoDePago MPPMetodoDePago;

        public List<BEMetodoDePago> retornarMetodosDePago() 
        {
            MPPMetodoDePago = new MPPMetodoDePago();
            return MPPMetodoDePago.ListarMetodosDePago();
        }

        public bool CrearXml() 
        {
            MPPMetodoDePago = new MPPMetodoDePago();
            return MPPMetodoDePago.CrearXml();
        }

    }
}
