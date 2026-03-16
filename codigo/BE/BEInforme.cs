using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEInforme : Entidad
    {
        public byte[] ContenidoBytes { get; set; }

        public string Estado { get; set; }

        public DateTime FechaGeneracion { get; set; }

        public string Observaciones { get; set; }
    }
}
