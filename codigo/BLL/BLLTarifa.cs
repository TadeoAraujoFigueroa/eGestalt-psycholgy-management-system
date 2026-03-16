using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;

namespace BLL
{
    public class BLLTarifa
    {
        private MPPTarifa mppTarifa;
        public void CalcularTarifa()
        {
            throw new NotImplementedException();
        }

        public bool GuardarNuevaTarifa(BETarifa beTarifa)
        {
            mppTarifa = new MPPTarifa();
            return mppTarifa.GuardarNuevaTarifa(beTarifa);
        }

        public BETarifa RetornarTarifaActual()
        {
            mppTarifa = new MPPTarifa();
            return mppTarifa.RetornarTarifa();
        }

        public List<BETarifa> ListarTarifas()
        {
            mppTarifa = new MPPTarifa();
            return mppTarifa.ListarTarifas();
        }
    }
}
