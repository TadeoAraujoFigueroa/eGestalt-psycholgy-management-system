using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacora : Entidad
    {
        public string FechaRegistro { get; set; }

        public string Detalle { get; set; }

        public BEUsuarioSistema beUsuario { get; set; }

    }
}
