using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPsicologo : BEUsuario
    {
        public BEPsicologo() { }
        public BEPsicologo(string nombre, string apellido, int dni, long tel, DateTime fecha_nacimiento, string corriente, string dia, string jornada, string sala, bool estado, string correo, int codigoDeAcceso, DateTime fecha_ingreso)
        : base(nombre, apellido, dni, tel, fecha_nacimiento, correo, fecha_ingreso)
        {
            this.Corriente = corriente;
            this.Dia = dia;
            this.Jornada = jornada;
            this.Sala = sala;
            this.Estado = estado;
            this.CodigoDeAcceso = codigoDeAcceso;
        }

        public bool Estado { get; set; }
        public string Corriente { get; set; }
        public string Dia { get; set; }
        public string Jornada { get; set; }
        public string Sala { get; set; }
        public int CodigoDeAcceso { get; set; }
    }
}
