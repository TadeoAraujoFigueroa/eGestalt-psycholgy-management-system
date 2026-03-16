using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using BE;
using Servicios;
using Xceed.Words.NET;

namespace MAP
{
    public class MPPRol : IGestorXML<BERol>
    {
        private string _doc_permisos = GestorArchivos.ObtenerRutaArchivo("permisos.xml");
        private string _doc_roles = GestorArchivos.ObtenerRutaArchivo("roles.xml");
        private string _doc_rol_permisos = GestorArchivos.ObtenerRutaArchivo("rolespermisos.xml");
        private string _doc_rol_rol = GestorArchivos.ObtenerRutaArchivo("rolrol.xml");
        public BERol BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        //ABM
        public bool EliminarXML(BERol beRol)
        {
            try
            {
                XDocument doc = XDocument.Load(_doc_roles);

                XElement rol = doc.Root.Elements("Rol").FirstOrDefault
                    (
                    r => r.Attribute("Codigo").Value == beRol.Codigo.ToString()
                    );

                if (rol != null) 
                {
                    //Eliminamos y guardamos
                    rol.Remove();
                    doc.Save(_doc_roles);

                    return true;
                }

                return false;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }

        public bool GuardarXML(BERol beRol)
        {
            try
            {
                if (!File.Exists(_doc_roles)) 
                {
                    var BDXML = new XDocument(new XElement("Roles"));
                    BDXML.Save(_doc_roles);
                    
                }
               
                    XDocument xmlDoc = XDocument.Load(_doc_roles);

                    if (beRol.Codigo == -1)
                    {
                        beRol.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Roles").Add(
                        new XElement("Rol",
                        new XAttribute("Codigo", beRol.Codigo.ToString()),
                         new XElement("Nombre", beRol.Nombre
                    )));
                    }

                    xmlDoc.Save(_doc_roles);

                    return true;
                
                 
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }

        public bool ModificarXML(BERol beRol)
        {
            try
            {
                XElement doc = XElement.Load(_doc_roles);

                var rolModificar =
                         from r in doc.Elements("Rol")
                         where (int)r.Attribute("Codigo") == beRol.Codigo
                         select r;

                    foreach (var r in rolModificar)
                    {
                        r.Element("Nombre").Value = beRol.Nombre;
                        doc.Save(_doc_roles);
                    }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Listar
        public List<BERol> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc_roles))
                {
                    var BDXML = new XDocument(new XElement("Roles"));
                    BDXML.Save(_doc_roles);
                    return new List<BERol>();

                }
                //Leemos todos los roles existentes
                XDocument doc = XDocument.Load(_doc_roles);
                
                var consulta =
                    from r in doc.Root.Elements("Rol")
                    select new BERol
                    {
                        Codigo = int.Parse(r.Attribute("Codigo").Value),
                        Nombre = r.Element("Nombre").Value
                    };

                return consulta.ToList();
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }

        public List<BEPermisoBase> ListarPermisosRol(BERol beRol)
        {
            try
            {
                //Corroboramos la existencia del archivo
                if (!File.Exists(_doc_rol_permisos))
                {
                    var BDXML = new XDocument(new XElement("RolesPermisos"));
                    BDXML.Save(_doc_rol_permisos);
                }

                if (!File.Exists(_doc_rol_rol))
                {
                    var BDXML = new XDocument(new XElement("RolRol"));
                    BDXML.Save(_doc_rol_rol);
                }

                if (!File.Exists(_doc_permisos))
                {
                    var BDXML = new XDocument(new XElement("Permisos"));
                    BDXML.Save(_doc_permisos);
                }
                if (!File.Exists(_doc_roles))
                {
                    var BDXML = new XDocument(new XElement("Roles"));
                    BDXML.Save(_doc_roles);
                }

                XDocument doc_rol_permisos = XDocument.Load(_doc_rol_permisos);
                XDocument doc_rol_rol = XDocument.Load(_doc_rol_rol);
                XDocument doc_permisos = XDocument.Load(_doc_permisos);
                XDocument doc_roles = XDocument.Load(_doc_roles);

                    //Permisos que corresponden al rol
                    var rol_permisos =
                from id in doc_rol_permisos.Root.Elements("Relacion")
                where
                 id.Attribute("idRol").Value == beRol.Codigo.ToString()
                select int.Parse(id.Attribute("idPermiso").Value);

               
                    //Roles que corresponden al rol
                    var rol_rol =
                from id in doc_rol_rol.Root.Elements("Relacion")
                where
                 id.Attribute("idRolPadre").Value == beRol.Codigo.ToString()
                select int.Parse(id.Attribute("idRolHijo").Value);

               
                var permisos =
                from p in doc_permisos.Root.Elements("Permiso")
                select new BEPermisoSimple
                {
                    Codigo = int.Parse(p.Attribute("Codigo").Value),
                    Nombre = p.Element("Nombre").Value
                };

               
                var roles =
                    from r in doc_roles.Root.Elements("Rol")
                    where r.Attribute("Codigo").Value != beRol.Codigo.ToString()
                    select new BERol
                    {
                        Codigo = int.Parse(r.Attribute("Codigo").Value),
                        Nombre = r.Element("Nombre").Value
                    };

                //Recorremos todos los roles existentes
                foreach (var r in roles)
                {
                
                    //Recorro los id's en donde existio coincidencia con el rol seleccionado
                    foreach (var rid in rol_rol)
                    {
                        if(rol_rol.Contains(r.Codigo) == false) 
                        {
                            //Evitamos buscar si la lista de id's obtenidos no contiene el rol
                            break;
                        }
                        //Lo que pasa aca es que hay coincidencia entre los roles existentes y los roles que contiene
                        //El rol seleccionado, por lo que un rol contiene otro rol.
                        //Guardamos el Rol en cuestión y lo mandamos a llenar utilizando esta misma función
                        //De forma recursiva
                        if (r.Codigo == rid)
                        {
                            ListarPermisosRol(r);
                            //Una vez 'lleno' el rol, lo agregamos a este rol
                            beRol.AgregarHijo(r);
                        }
                    }
                }

                //Recorremos los permisos y lo chocamos contra los id's obtenidos 
                foreach (var p in permisos)
                {
                    if (rol_permisos.Contains(p.Codigo))
                    {
                        //Recorremosl los id obtenidos en la consulta
                        foreach (var pid in rol_permisos)
                        {
                            if (p.Codigo == pid)
                            {
                                if (beRol.RetornarPermisos().Contains(p))
                                {
                                    break;
                                }
                                else
                                {
                                    foreach (var permiso in beRol.RetornarPermisos())
                                    {
                                        if (permiso.Codigo == p.Codigo)
                                        {
                                            break;
                                        }
                                    }

                                    beRol.AgregarHijo(p);

                                }

                            }
                        }
                    }
                                  
                }
                return beRol.RetornarPermisos().ToList();
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            catch (Exception ex_uno) 
            {
                throw ex_uno;
            }
          
        }
       
        //Agregar o quitar permiso
        public bool AgregarPermisoRol(BEPermisoSimple bePermiso, BERol beRol) 
        {
            try
            {
                if (!File.Exists(_doc_rol_permisos))
                {
                    var BDXML = new XDocument(new XElement("RolesPermisos"));
                    BDXML.Save(_doc_rol_permisos);

                }

                //Traemos el documento que contiene las relaciones entre permisos y roles
                XDocument doc= XDocument.Load(_doc_rol_permisos);

               

                //Creamos la relación que representa que el rol contiene al permiso
                XElement nuevaRelacion = new XElement("Relacion",
                        new XAttribute("idRol", beRol.Codigo.ToString()),
                        new XAttribute("idPermiso", bePermiso.Codigo.ToString()));



                //Corroboramos la existencia de dicha relación para evitar duplicados
                bool existe = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idRol") == beRol.Codigo &&
                         (int)r.Attribute("idPermiso") == bePermiso.Codigo);

                if (!existe) 
                {
                    doc.Element("RolesPermisos").Add(nuevaRelacion);
                    doc.Save(_doc_rol_permisos);
                    return true;
                }
                else 
                {
                    throw new Exception("El rol ya se encuentra asociado al permiso");
                }

    
            }
            catch (Exception ex)
            {

                throw ex;
            }
   
        }

        public bool DesvincularPermisoDeRol(BEPermisoSimple bePermiso, BERol beRol)
        {
            try
            {
                //Traemos el documento que contiene las relaciones entre permisos y roles
                XDocument doc = XDocument.Load(_doc_rol_permisos);

                //Corroboramos la existencia de dicha relación para asegurarnos
                bool existe = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idRol") == beRol.Codigo &&
                         (int)r.Attribute("idPermiso") == bePermiso.Codigo);

                if (existe)
                {
                    //Seleccionamos la relación a eliminar
                    XElement relacion = doc.Root.Elements("Relacion").FirstOrDefault(r =>
                (int)r.Attribute("idRol") == beRol.Codigo &&
                (int)r.Attribute("idPermiso") == bePermiso.Codigo
                     );

                    //Eliminamos    
                    relacion.Remove();

                    doc.Save(_doc_rol_permisos);

                    return true;
                }
                else
                {
                    throw new Exception("El permiso no está asociado al rol");
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AgregarRolRol(BERol beRolPadre, BERol beRolHijo)
        {
            try
            {
                //Traemos el documento que contiene las relaciones entre permisos y roles
                XDocument doc = XDocument.Load(_doc_rol_rol);

                if (!File.Exists(_doc_rol_rol))
                {
                    var BDXML = new XDocument(new XElement("RolRol"));
                    BDXML.Save(_doc_rol_rol);
                }

                    //Corroboramos la existencia de dicha relación en inversa 
                    //Es decir, que el rol seleccionado como hijo no contenga al rol seleccionado como padre
                    //Ya que esto generaria un bucle infinito (StackOverFlow)

                    bool existe_uno = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idRolPadre") == beRolHijo.Codigo &&
                         (int)r.Attribute("idRolHijo") == beRolPadre.Codigo);

                if (existe_uno) 
                {
                    return false;
                }

                //Creamos la relación que representa que el rol contiene al permiso
                XElement nuevaRelacion = new XElement("Relacion",
                        new XAttribute("idRolPadre", beRolPadre.Codigo.ToString()),
                        new XAttribute("idRolHijo", beRolHijo.Codigo.ToString()));



                //Corroboramos la existencia de dicha relación para evitar duplicados
                bool existe = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idRolPadre") == beRolPadre.Codigo &&
                         (int)r.Attribute("idRolHijo") == beRolHijo.Codigo);

                if (!existe)
                {
                    doc.Element("RolRol").Add(nuevaRelacion);
                    doc.Save(_doc_rol_rol);
                    return true;
                }
                else
                {
                    throw new Exception("El rol padre ya contiene al rol hijo");
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool DesvincularRolDeRol(BERol beRolPadre, BERol beRolHijo)
        {
            try
            {
                //Traemos el documento que contiene las relaciones entre permisos y roles
                XDocument doc = XDocument.Load(_doc_rol_rol);

                //Corroboramos la existencia de dicha relación para asegurarnos
                bool existe = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idRolPadre") == beRolPadre.Codigo &&
                         (int)r.Attribute("idRolHijo") == beRolHijo.Codigo);

                if (existe)
                {
                    //Seleccionamos la relación a eliminar
                    XElement relacion = doc.Root.Elements("Relacion").FirstOrDefault(r =>
                (int)r.Attribute("idRolPadre") == beRolPadre.Codigo &&
                (int)r.Attribute("idRolHijo") == beRolHijo.Codigo
                     );

                    //Eliminamos    
                    relacion.Remove();

                    doc.Save(_doc_rol_rol);

                    return true;
                }
                else
                {
                    throw new Exception("El rol hijo no está asociado al rol padre");
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int ObtenerUltimoId()
        {
            try
            {
                XElement doc = XElement.Load(_doc_roles);

                var consulta =
                         from r in doc.Elements("Rol")
                         select int.Parse(r.Attribute("Codigo").Value);

                if(consulta.Any()) 
                {
                    int ultimoId = consulta.Max();
                    return ultimoId;
                }

                else 
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
