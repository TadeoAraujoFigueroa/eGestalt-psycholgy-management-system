using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;
using Servicios;
using Seguridad;
using System.Security.Claims;

namespace BLL
{
    public class BLLUsuarioSistema : IGestor<BEUsuarioSistema>
    {
        
        MPPUsuarioSistema mppUsuario;
        public bool Baja(BEUsuarioSistema beUsuario)
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.EliminarXML(beUsuario);
        }

        public bool Guardar(BEUsuarioSistema beUsuario)
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.GuardarXML(beUsuario);
        }

        public List<BEUsuarioSistema> ListarTodo()
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.ListarXML();
        }

        public bool Modificar(BEUsuarioSistema beUsuario)
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.ModificarXML(beUsuario);
        }

        public bool VincularUsuarioPermiso(BEUsuarioSistema beUsuario, BEPermisoSimple bePermiso) 
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.VincularUsuarioPermiso(beUsuario, bePermiso);
        }
        public bool DesvincularUsuarioPermiso(BEUsuarioSistema beUsuario, BEPermisoSimple bePermiso)
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.DesvincularUsuarioPermiso(beUsuario, bePermiso);
        }

        public bool VincularUsuarioRol(BEUsuarioSistema beUsuario, BERol beRol)
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.VincularUsuarioRol(beUsuario, beRol);
        }
        public bool DesvincularUsuarioRol(BEUsuarioSistema beUsuario, BERol beRol)
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.DesvincularUsuarioRoles(beUsuario, beRol);
        }

        public List<BEPermisoSimple> ListarPermisosUsuario(BEUsuarioSistema beUsuario) 
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.ListarPermisosUsuario(beUsuario);

        }

        public List<BERol> ListarRolesDelUsuario (BEUsuarioSistema beUsuario) 
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.ListarRolesUsuario(beUsuario);
        }
        public BEUsuarioSistema CorroborarAcceso(BEUsuarioSistema beUsuario) 
        {
            try
            {
             mppUsuario = new MPPUsuarioSistema();

                //Obtenemos la encriptación de la contraseña ingresada para realizar la comparación

                string clave = Encriptacion.Encriptar(beUsuario.Clave);

                //Devuelve si hubo una coincidencia

                return mppUsuario.ListarXML().FirstOrDefault(u => u.Nombre == beUsuario.Nombre && u.Clave == clave);

            }
            catch (Exception ex)
            {

                throw ex;
            }
     
        }

        public bool ValidarCreacion(string nombre) 
        {
            return this.ListarTodo().Exists(u => u.Nombre == nombre);
        }

        public bool CrearXml() 
        {
            mppUsuario = new MPPUsuarioSistema();
            return mppUsuario.CrearXml();
        }
    }
}
