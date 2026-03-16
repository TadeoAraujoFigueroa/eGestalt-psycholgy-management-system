using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;
using Servicios;

namespace BLL
{
    public class ServicioDeFacturas : IGestor<BEFactura>
    {
        MPPServicioDeFactura mppFactura;
        public int RetornarID() 
        {
            mppFactura = new MPPServicioDeFactura();
            return mppFactura.ObtenerUltimoId() + 1;
        }

        public int ObtenerPuntoDeVenta()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["PtoVenta"]);
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int RetornarNroFactura()
        {
            mppFactura = new MPPServicioDeFactura();
            return mppFactura.ObtenerNumeroFactura() + 1;
        }
        public string GenerarComprobante(BEPago bePago, BEFactura beFactura, BEPaciente bePaciente) 
        {
            mppFactura = new MPPServicioDeFactura();
            return mppFactura.GenerarComprobante(bePago, beFactura, bePaciente);
        }

        public string GenerarCuponDePago(BECuponDePago beCupon, BEPaciente bePaciente, decimal tarifa) 
        {
            mppFactura = new MPPServicioDeFactura();
            return mppFactura.GenerarCuponDePago(bePaciente, beCupon, tarifa);
        }

        public bool Guardar(BEFactura bEFactura)
        {
            mppFactura = new MPPServicioDeFactura();
            return mppFactura.GuardarXML(bEFactura);
        }

        public List<BEFactura> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BEFactura beFactura)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BEFactura beFactura)
        {
            throw new NotImplementedException();
        }
    }
}
