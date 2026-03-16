using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETurno : Entidad
    {

        public BEPaciente PacienteAsociado { get; set; }
        public BEPsicologo PsicologoAsociado { get; set; }
        public DateTime Fecha { get; set; }
        public string Sala { get; set; }
        public int Hora { get; set; }
        public string Dia { get; set; }
        public string Estado { get; set; } // Ejemplo: "Programado", "Completado", "Cancelado"
        public string Observaciones { get; set; }
    }
}
