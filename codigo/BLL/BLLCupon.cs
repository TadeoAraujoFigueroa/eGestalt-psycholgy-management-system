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
    public class BLLCupon : IGestor<BECuponDePago>
    {
        MPPCuponDePago mppCupon;
        public bool Baja(BECuponDePago beCupon)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BECuponDePago beCupon)
        {
            mppCupon = new MPPCuponDePago();
            return mppCupon.GuardarXML(beCupon);
        }

        public List<BECuponDePago> ListarCuponesSinVencimiento()
        {
            mppCupon = new MPPCuponDePago();
            return mppCupon.ListarXMLSinVencimiento();
        }

        public List<BECuponDePago> ListarCuponesConVencimiento()
        {
            mppCupon = new MPPCuponDePago();
            return mppCupon.ListarXMLConVencimiento();
        }

        public bool Modificar(BECuponDePago beCupon)
        {
            mppCupon= new MPPCuponDePago();
            return mppCupon.ModificarXML(beCupon);
        }

        public List<BECuponDePago> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }

}
