using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPago : Entidad
    {
        public BEMetodoDePago MetodoDePago { get; set; }
        public DateTime Fecha { get; set; }

        //Numero del QR o Numero de Cupon de la tarjeta
        public int NumeroDePago { get; set; }

        public override string ToString()
        {
            return $"{this.NumeroDePago}";
        }
    }
}
