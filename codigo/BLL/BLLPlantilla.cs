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
    public class BLLPlantilla : IGestor<BEPlantillaCorreo>
    {
        MPPPlantilla mppPlantilla;
        public bool Baja(BEPlantillaCorreo bePlantilla)
        {
            mppPlantilla = new MPPPlantilla();
            return mppPlantilla.EliminarXML(bePlantilla);
        }

        public bool Guardar(BEPlantillaCorreo bePlantilla)
        {
            mppPlantilla= new MPPPlantilla();
            return mppPlantilla.GuardarXML(bePlantilla);
        }

        public List<BEPlantillaCorreo> ListarTodo()
        {
            mppPlantilla = new MPPPlantilla();
            return mppPlantilla.ListarXML();
        }

        public bool Modificar(BEPlantillaCorreo bePlantilla)
        {
            mppPlantilla = new MPPPlantilla();
            return mppPlantilla.ModificarXML(bePlantilla);
        }
    }
}
