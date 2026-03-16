using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESesion : Entidad
    {
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        public string Observaciones { get; set; }
        public BEPaciente PacienteAsociado { get; set; }
        public BEPsicologo PsicologoAsociado { get; set; }
        public BETarifa Tarifa { get; set; }
        public BEPago Pago { get; set; }

        public string Estado { get; set; }
    }
}
