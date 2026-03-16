using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuarioSistema
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public  string Clave { get; set; }

        public bool Estado { get; set; }    
        //Lo que puede hacer el usuario
        private List<BEPermisoBase> permisos;

        public List<BEPermisoBase> retornarPermisos() 
        {
            return permisos;
        }

        public void AgregarPermiso(BEPermisoBase permiso) 
        {
            permisos.Add(permiso);
        }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }
    }
}
