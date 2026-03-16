using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFactura : Entidad
    {
        public DateTime Fecha { get; set; }
        public string formaDePago { get; set; }
        public decimal Monto { get; set; }

        public int NumeroPago { get; set; }
        public int NumeroFactura { get; set; }

        public int PuntoVenta { get; set; }
    }
}
