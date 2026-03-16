using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;
using Servicios;

namespace BLL
{
    public class BLLPago : IGestor<BEPago>
    {
        private MPPPago mppPago;
        public bool Baja(BEPago objeto)
        {
            throw new NotImplementedException();
        }

        public bool CrearXml() 
        {
            mppPago = new MPPPago();
            return mppPago.CrearXml();
        }
        public bool Guardar(BEPago objeto)
        {
            mppPago = new MPPPago();
            return mppPago.GuardarXML(objeto);
        }

        public List<BEPago> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BEPago objeto)
        {
            throw new NotImplementedException();
        }
    }
}
