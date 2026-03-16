using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESalario : Entidad
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public  BEPsicologo Psicologo { get; set; }
    }
}
