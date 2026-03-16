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
    public class BLLTurno : IGestor<BETurno>
    {
        MPPTurnos mPPTurno;
        public bool Baja(BETurno beTurno)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.EliminarXML(beTurno);
        }

        public bool Guardar(BETurno objeto)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.GuardarXML(objeto);
        }

        public List<BETurno> ListarPorPaciente(int dni)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ListarXML().Where(t => t.PacienteAsociado.DNI == dni && t.Estado == "Programado").ToList();
        }

        public List<BETurno> ListarPorPsicologo(int dni)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ListarXML().Where(t => t.PacienteAsociado.DNI == dni).ToList();
        }

        public List<BETurno> ListarTodo()
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ListarXML();
        }

        public bool Modificar(BETurno turno)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ModificarXML(turno);

        }

        public int TurnosRegistrados(BEPsicologo bePsicologo) 
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ListarXML().Where(t => t.Estado == "Programado" && t.PsicologoAsociado.DNI == bePsicologo.DNI).ToList().Count;
        }

        public bool CancelarTurnosPaciente(BEPaciente bEPaciente) 
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.CancelarTurnosPaciente(bEPaciente);
        }

        public bool CancelarTurnosPsicologo(BEPsicologo bePsicologo)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.CancelarTurnosPsicologo(bePsicologo);
        }

        public List<BETurno> ListarPorFecha(DateTime fecha)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ListarXML().Where(p => p.Fecha.ToShortDateString() == fecha.ToShortDateString()).ToList();
        }

            

        public bool ActualizarPaciente(BEPaciente bePaciente)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ActualizarPaciente(bePaciente);


        }

        public bool ActualizarPsicologo(BEPsicologo bEPsicologo)
        {
            mPPTurno = new MPPTurnos();
            return mPPTurno.ActualizarPsicologo(bEPsicologo);
        }
    }
}
