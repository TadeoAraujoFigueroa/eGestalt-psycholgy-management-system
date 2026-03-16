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
    public class BLLSalario : IGestor<BESalario>
    {
        MPPSalario mppSalario;
        public bool Baja(BESalario objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BESalario beSalario)
        {
            mppSalario = new MPPSalario();
            return mppSalario.GuardarSalario(beSalario);
        }

        public List<BESalario> ListarTodo()
        {
            mppSalario = new MPPSalario();
            return mppSalario.RetornarSalario();
        }

        public bool Modificar(BESalario objeto)
        {
            throw new NotImplementedException();
        }
    }
}
