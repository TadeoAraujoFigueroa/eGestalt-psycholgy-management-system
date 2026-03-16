using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BELiquidacion : Entidad
    {
        public string Estado { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Monto { get; set; }
    }
}
