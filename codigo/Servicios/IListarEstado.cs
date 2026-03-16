using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IListarEstado<T>
    {
        List<T> ListarActivo();

        List<T> ListarInactivo();
    }
}
