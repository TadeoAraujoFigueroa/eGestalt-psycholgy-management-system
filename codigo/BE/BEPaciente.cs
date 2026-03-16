using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPaciente : BEUsuario
    {
        public BEPaciente() : base() { }
        public BEPaciente(string nombre, string apellido, int dni, long tel, DateTime fecha_nacimiento, string correo, DateTime fechaIngreso) : base(nombre, apellido, dni, tel, fecha_nacimiento, correo, fechaIngreso){}
        public string Observaciones { get; set; }
        public string Estado { get; set; }

        //Atributo que determina cuando el usuario fue descontinuado
        public DateTime FechaDeBaja { get; set; }
  
    }
}
