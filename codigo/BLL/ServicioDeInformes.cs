using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;

namespace BLL
{
    public class ServicioDeInformes
    {
        MPPInforme mppInforme;
   
        public bool GuardarInformeDeSesiones(BEInforme beInforme)
        {
            mppInforme = new MPPInforme();
            return mppInforme.GuardarInforme(beInforme);

        }

        public List<BEInforme> retornarInformesParaValidar() 
        {
            mppInforme = new MPPInforme();
            return mppInforme.listarInformesActivos().Where(i => i.Estado == "Generado").ToList(); 
        }

        public List<BEInforme> retornarInformesActivos() 
        {
            mppInforme = new MPPInforme();
            return mppInforme.listarInformesActivos().Where(i => i.Estado == "Validado").ToList(); ;
        }

        public List<BEInforme> retornarInformesRechazados()
        {
            mppInforme = new MPPInforme();
            return mppInforme.listarInformesRechazados();
        }

        public bool ModificarInforme(BEInforme beInforme)
        {
            mppInforme = new MPPInforme();
            return mppInforme.ModificarInforme(beInforme);
        }
        
    }
}
