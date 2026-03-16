using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MAP;

namespace BLL
{
    public class BLLPermisoSimple
    {
        MPPPermisoSimple mppPermisoSimple;

        public List<BEPermisoSimple> listarTodo() 
        {
            mppPermisoSimple = new MPPPermisoSimple();
            return mppPermisoSimple.listarTodos();
        }

        public bool CrearXml() 
        {
            mppPermisoSimple = new MPPPermisoSimple();
            return mppPermisoSimple.CrearXml();
        }
    }
}
