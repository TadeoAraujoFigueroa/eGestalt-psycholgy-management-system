using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEMetodoDePago : Entidad
    {
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"{Nombre}";
        }

    }
    public class BETarjeta : BEMetodoDePago
    {
     
    }
    public class BEQR : BEMetodoDePago
    {

    }
}
