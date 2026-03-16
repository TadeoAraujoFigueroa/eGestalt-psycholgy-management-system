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
    public class BLLBitacora : IGestor<BEBitacora>
    {
        MPPBitacora mppBitacora;
        public bool Baja(BEBitacora beBitacora)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEBitacora beBitacora)
        {
            mppBitacora = new MPPBitacora();
            return mppBitacora.GuardarXML(beBitacora);
        }

        public List<BEBitacora> ListarTodo()
        {
            mppBitacora = new MPPBitacora();
            return mppBitacora.ListarXML();
        }

        public bool Modificar(BEBitacora beBitacora)
        {
            throw new NotImplementedException();
        }
    }
}
