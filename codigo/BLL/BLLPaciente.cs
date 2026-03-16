using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Servicios;
using MAP;

namespace BLL
{
    public class BLLPaciente : IGestor<BEPaciente>, IListarEstado<BEPaciente>
    {
        MPPPaciente mPPPaciente;
        public bool Baja(BEPaciente objeto)
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.EliminarXML(objeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        public bool Activar(BEPaciente objeto)
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.DarAltaXML(objeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public bool Guardar(BEPaciente paciente)
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.GuardarXML(paciente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<BEPaciente> ListarActivo()
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.ListarXML().FindAll(p => p.Estado == "Activo" || p.Estado == "En espera");
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public List<BEPaciente> ListarInactivo()
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.ListarXML().FindAll(p => p.Estado == "Discontinuado");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<BEPaciente> ListarTodo()
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.ListarXML();
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public bool Modificar(BEPaciente objeto)
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.ModificarXML(objeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool ExisteDni(int dni)
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.ExisteDni(dni);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public int ObtenerUltimoId() 
        {
            try
            {
                mPPPaciente = new MPPPaciente();
                return mPPPaciente.ObtenerUltimoId();
            }
            catch (Exception ex) 
            {

                throw ex;
            }
           
        }
    }
}
