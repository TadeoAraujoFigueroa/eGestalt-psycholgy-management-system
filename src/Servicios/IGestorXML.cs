using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IGestorXML<T>
    {
        bool EliminarXML(T objeto);

        bool GuardarXML(T objeto);

        bool ModificarXML(T objeto);

        List<T> ListarXML();

        T BuscarXML(int id);

        int ObtenerUltimoId();
    }
}
