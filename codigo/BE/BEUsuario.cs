using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEUsuario : Entidad
    {
        public BEUsuario() { }
        public BEUsuario(string nombre, string apellido, int dni, long tel, DateTime fecha_nacimiento, string correo, DateTime fechaIngreso)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.DNI = dni;
            this.Telefono = tel;
            this.FechaNacimiento = fecha_nacimiento;
            this.Correo = correo;
            this.FechaIngreso = fechaIngreso;
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public long Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Atributo que nos permite determinar cuando ingreso en el sistema en el usuario
        //Clave para los gráficos del DashBoard
        public DateTime FechaIngreso { get; set; }
        public string Correo { get; set; }
        public override string ToString()
        {
            return $"{Apellido}, {Nombre}";
        }
    }
}
