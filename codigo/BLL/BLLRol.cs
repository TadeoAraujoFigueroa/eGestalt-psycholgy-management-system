using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;
using Servicios;
using Xceed.Pdf.Layout.Text;

namespace BLL
{
    public class BLLRol : IGestor<BERol>
    {
        MPPRol mppRol;
        public bool Baja(BERol beRol)
        {
            mppRol = new MPPRol();
            return mppRol.EliminarXML(beRol);
        }

        public bool Guardar(BERol beRol)
        {
            mppRol = new MPPRol();
            return mppRol.GuardarXML(beRol);
        }

        public bool AgregarPermisoRol(BEPermisoSimple bePermiso, BERol beRol) 
        {
            mppRol = new MPPRol();
            return mppRol.AgregarPermisoRol(bePermiso, beRol);
        }

        public bool DesvincularPermisoDeRol(BEPermisoSimple bePermiso, BERol beRol) 
        {
            mppRol = new MPPRol();
            return mppRol.DesvincularPermisoDeRol(bePermiso, beRol);
        }

        public bool AgregarRolRol(BERol beRolPadre, BERol beRolHijo)
        {
            mppRol = new MPPRol();
            return mppRol.AgregarRolRol(beRolPadre, beRolHijo);
        }
        public bool DesvincularRolDeRol(BERol beRolPadre, BERol beRolHijo)
        {
            mppRol = new MPPRol();
            return mppRol.DesvincularRolDeRol(beRolPadre, beRolHijo);
        }

        public bool ExistenciaRol(BERol beRol) 
        {
            return this.ListarTodo().Exists(r => r.Nombre.ToLower() == beRol.Nombre.ToLower());
        }
        public List<BERol> ListarTodo()
        {
            mppRol = new MPPRol();
            return mppRol.ListarXML();
        }
        public List<BEPermisoBase> ListarPermisosRol(BERol beRol)
        {
            mppRol = new MPPRol();
            return mppRol.ListarPermisosRol(beRol);
        }
        public bool Modificar(BERol beRol)
        {
            mppRol = new MPPRol();
            return mppRol.ModificarXML(beRol);
        }
    }
}
