using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHistoriaClinica : Entidad
    {
        public DateTime fechaCierre { get; set; }
        public DateTime fechaInicio { get; set; }
        public string Estado { get; set; }

    }
}
