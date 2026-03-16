using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPlantillaCorreo : Entidad
    {
        public string Asunto { get; set; }

        public string Mensaje { get; set; }

        public string Estado { get; set; }
    }
}
