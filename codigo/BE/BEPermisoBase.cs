using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEPermisoBase
    {
        public abstract BEPermisoBase[] RetornarPermisos();

        protected List<BEPermisoBase> permisos;

        public abstract void AgregarHijo(BEPermisoBase bePermiso);

        public abstract void EliminarHijo(BEPermisoBase bePermiso);
        public string Nombre { get; set; }

        public int Codigo { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }

    }

    public class BERol : BEPermisoBase
    {
        public BERol() 
        {
            this.permisos = new List<BEPermisoBase>();
        }
        public override void AgregarHijo(BEPermisoBase bePermiso)
        {
            this.permisos.Add(bePermiso);   
        }

        public override void EliminarHijo(BEPermisoBase bePermiso)
        {
            this.permisos.Remove(bePermiso);
        }

        public override BEPermisoBase[] RetornarPermisos()
        {
            //Retornamos un array para garantizar seguridad
            return this.permisos.ToArray();
        }
    }

    public class BEPermisoSimple : BEPermisoBase
    {

        //Funciones no implementadas
        public override void AgregarHijo(BEPermisoBase bePermiso)
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo(BEPermisoBase bePermiso)
        {
            throw new NotImplementedException();
        }

        public override BEPermisoBase[] RetornarPermisos()
        {
            return null;
        }
    }
}
