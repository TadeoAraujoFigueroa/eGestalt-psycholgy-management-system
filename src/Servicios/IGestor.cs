using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IGestor<T>
    {
        bool Baja(T objeto);

        bool Guardar(T objeto);

        List<T> ListarTodo();

        bool Modificar(T objeto);
       
    }
}
