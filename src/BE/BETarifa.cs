using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETarifa : Entidad
    {
        //public int Descuento { get; set; }
        //public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public decimal HonorarioPsicologo { get; set; }

        public decimal RetencionUno { get; set; }

        public decimal RetencionDos { get; set; }

        public DateTime Fecha { get; set; }

        public override string ToString()
        {
            return $"{this.Total}";
        }
    }
}
