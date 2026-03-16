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
    public class BLLPsicologo : IGestor<BEPsicologo>
    {
        MPPPsicologo mPPPsicologo;
        public bool Baja(BEPsicologo objeto)
        {
            mPPPsicologo = new MPPPsicologo();
            return mPPPsicologo.EliminarXML(objeto);
        }

        public bool Guardar(BEPsicologo objeto)
        {
            mPPPsicologo = new MPPPsicologo();
            return mPPPsicologo.GuardarXML(objeto);
        }

        public List<BEPsicologo> ListarTodo()
        {
            mPPPsicologo = new MPPPsicologo();
            return mPPPsicologo.ListarXML();
        }

        public bool Modificar(BEPsicologo bePsico)
        {
            //Primero verificamos que, en el caso de que el psicólogo pase de Inactivo a Activo
            //No exista un psicologo activo que este ocupando la misma sala, jornada y dia

            //Si existe un psicologo con el mismo código que el que vamos a modificar y el estado es falso
            //Y el estado del psicólogo que queremos modificar es verdadero

            if(this.ListarTodo().Exists(u => u.Codigo  == bePsico.Codigo && u.Estado == false && bePsico.Estado == true)) 
            {
                //En ese caso, verificamos la existencia de otro psicologo
                if(this.ExistePsicologo(bePsico.Jornada, bePsico.Dia, bePsico.Sala) != null) 
                {
                    return false;
                }
            }
            mPPPsicologo = new MPPPsicologo();
            return mPPPsicologo.ModificarXML(bePsico);
        }

        public bool ExisteDni(int dni)
        {
            mPPPsicologo = new MPPPsicologo();
            return mPPPsicologo.ExisteDni(dni);
        }

        public bool ExisteCodigoDeAcceso(int codigo)
        {
            mPPPsicologo = new MPPPsicologo();
            return mPPPsicologo.ExisteCodigoDeAcceso(codigo);
        }

        public BEPsicologo ExistePsicologo(string jornada, string dia, string sala) 
        {
            BEPsicologo psico;

            psico = this.ListarTodo().FirstOrDefault(p => p.Jornada == jornada &&
                                                                     p.Sala == sala
                                                                     && p.Dia == dia
                                                                     && p.Estado == true);

            return psico;
        }
    }
    
}
