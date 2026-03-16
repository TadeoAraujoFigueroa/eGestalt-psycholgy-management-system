using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECuponDePago : BEMetodoDePago
    {
        public BEPaciente PacienteAsociado { get; set; }
        public DateTime FechaDeEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int NumeroDeCupon { get; set; }
        public decimal Monto { get; set; }  
    }
}
