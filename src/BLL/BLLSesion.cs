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
    public class BLLSesion : IGestor<BESesion>
    {
        private MPPSesion mppSesion;
        public bool Baja(BESesion objeto)
        {
            mppSesion = new MPPSesion();
            return mppSesion.EliminarXML(objeto);
        }
        public bool Guardar(BESesion objeto)
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.GuardarXML(objeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<BESesion> ListarPorPaciente(int dni)
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.ListarXML().Where(s => s.PacienteAsociado.DNI == dni).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public List<BESesion> ListarPorPsicologo(int dni)
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.ListarXML().Where(s => s.PsicologoAsociado.DNI == dni).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<BESesion> ListarTodo()
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.ListarXML();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public bool Modificar(BESesion beSesion)
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.ModificarXML(beSesion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public int RetornarSesionesNoAbonadas(BEPaciente bEPaciente) 
        {
            try
            {
                mppSesion = new MPPSesion();

                var lista_sesiones_no_abonadas = mppSesion.ListarXML().Where(s => s.PacienteAsociado.DNI == bEPaciente.DNI).ToList();

                lista_sesiones_no_abonadas = lista_sesiones_no_abonadas.Where(s => s.Estado == "No Abonado" || s.Estado == "Cupón Emitido").ToList();

                return lista_sesiones_no_abonadas.Count();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            
        }
        public bool ActualizarPaciente(BEPaciente bePaciente) 
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.ActualizarPaciente(bePaciente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
             
            
        }
        public bool ActualizarPsicologo(BEPsicologo bEPsicologo) 
        {
            try
            {
                mppSesion = new MPPSesion();
                return mppSesion.ActualizarPsicologo(bEPsicologo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
   
}
