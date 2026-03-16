using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BE;
using Servicios;

namespace MAP
{
    public class MPPUsuarioSistema : IGestorXML<BEUsuarioSistema>
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("usuarios.xml");

        private string _doc_dos = GestorArchivos.ObtenerRutaArchivo("permisosusuarios.xml");

        private string _doc_tres = GestorArchivos.ObtenerRutaArchivo("permisos.xml");

        private string _doc_cuatro = GestorArchivos.ObtenerRutaArchivo("rolesusuario.xml");

        private string _doc_cinco = GestorArchivos.ObtenerRutaArchivo("roles.xml");

        public BEUsuarioSistema BuscarXML(int id)
        {
            throw new NotImplementedException();
        }
        public bool EliminarXML(BEUsuarioSistema beUsuario)
        {
            try
            {
                XDocument doc = XDocument.Load(_doc);

                XElement usuario = doc.Root.Elements("Usuario").FirstOrDefault
                    (
                    u => u.Attribute("Codigo").Value == beUsuario.Codigo.ToString()
                    );

                if (usuario != null)
                {
                    //Eliminamos y guardamos
                    usuario.Element("Estado").Value = "False";
                    doc.Save(_doc);

                    return true;
                }

                return false;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public bool GuardarXML(BEUsuarioSistema beUsuario)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Usuarios"));
                    BDXML.Save(_doc);
                   
                }
                
                    XDocument doc = XDocument.Load(_doc);

                    if (beUsuario.Codigo == -1)
                    {
                        beUsuario.Codigo = ObtenerUltimoId() + 1;

                        doc.Element("Usuarios").Add(
                            new XElement("Usuario",
                            new XAttribute("Codigo", beUsuario.Codigo.ToString()),
                            new XElement("Nombre", beUsuario.Nombre),
                            new XElement("Clave", beUsuario.Clave),
                            new XElement("Estado", beUsuario.Estado.ToString()
                            )));


                    }
                    doc.Save(_doc);

                    return true;
                
                
            }
            catch (XmlException ex)
            {

                throw ex; 
            }
        }
        public bool ModificarXML(BEUsuarioSistema beUsuario)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var usuarioModificar =
                         from u in doc.Elements("Usuario")
                         where (int)u.Attribute("Codigo") == beUsuario.Codigo
                         select u;

                foreach (var r in usuarioModificar)
                {
                    r.Element("Nombre").Value = beUsuario.Nombre;
                    r.Element("Clave").Value = beUsuario.Clave;
                    r.Element("Estado").Value = beUsuario.Estado.ToString();
                    doc.Save(_doc);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool VincularUsuarioPermiso(BEUsuarioSistema beUsuario, BEPermisoSimple bePermiso) 
        {
            try
            {
                if (!File.Exists(_doc_dos))
                {
                    var BDXML = new XDocument(new XElement("PermisosUsuarios"));
                    BDXML.Save(_doc_dos);

                }

                //Traemos el documento que contiene las relaciones entre permisos y roles
                XDocument doc = XDocument.Load(_doc_dos);

                

                //Creamos la relación que representa que el rol contiene al permiso
                XElement nuevaRelacion = new XElement("Relacion",
                        new XAttribute("idUsuario", beUsuario.Codigo.ToString()),
                        new XAttribute("idPermiso", bePermiso.Codigo.ToString()));



                //Corroboramos la existencia de dicha relación para evitar duplicados
                bool existe = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idUsuario") == beUsuario.Codigo &&
                         (int)r.Attribute("idPermiso") == bePermiso.Codigo);

                if (!existe)
                {
                    doc.Element("PermisosUsuarios").Add(nuevaRelacion);
                    doc.Save(_doc_dos);
                    return true;
                }
                else
                {
                    throw new Exception("El permiso ya se encuentra asociado al usuario");
                }
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public bool DesvincularUsuarioPermiso(BEUsuarioSistema beUsuario, BEPermisoSimple bePermiso)
        {
            try
            {
                //Traemos el documento que contiene las relaciones entre permisos y roles
                XDocument doc = XDocument.Load(_doc_dos);


              
                //Corroboramos la existencia de dicha relación para evitar duplicados
                var relacion = doc.Root.Elements("Relacion")
                    .FirstOrDefault(r => (int)r.Attribute("idUsuario") == beUsuario.Codigo &&
                         (int)r.Attribute("idPermiso") == bePermiso.Codigo);

                if (relacion != null)
                {
                    relacion.Remove();
                    doc.Save(_doc_dos);
                    return true;
                }
                else
                {
                    throw new Exception("El permiso no esta asociado al usuario");
                }
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public bool VincularUsuarioRol(BEUsuarioSistema beUsuario, BERol beRol)
        {
            try
            {
                if (!File.Exists(_doc_cuatro))
                {
                    var BDXML = new XDocument(new XElement("RolesUsuarios"));
                    BDXML.Save(_doc_cuatro);

                }
                //Traemos el documento que contiene las relaciones entre usuarios y roles
                XDocument doc = XDocument.Load(_doc_cuatro);

        

                //Creamos la relación que representa que el rol contiene al permiso
                XElement nuevaRelacion = new XElement("Relacion",
                        new XAttribute("idUsuario", beUsuario.Codigo.ToString()),
                        new XAttribute("idRol", beRol.Codigo.ToString()));



                //Corroboramos la existencia de dicha relación para evitar duplicados
                bool existe = doc.Root.Elements("Relacion")
                    .Any(r => (int)r.Attribute("idUsuario") == beUsuario.Codigo &&
                         (int)r.Attribute("idRol") == beRol.Codigo);

                if (!existe)
                {
                    doc.Element("RolesUsuarios").Add(nuevaRelacion);
                    doc.Save(_doc_cuatro);
                    return true;
                }
                else
                {
                    throw new Exception("El rol ya se encuentra asociado al usuario");
                }
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public bool DesvincularUsuarioRoles(BEUsuarioSistema beUsuario, BERol beRol)
        {
            try
            {
                //Traemos el documento que contiene las relaciones entre usuarios y roles
                XDocument doc = XDocument.Load(_doc_cuatro);

                //Corroboramos la existencia de dicha relación para evitar duplicados
                var relacion = doc.Root.Elements("Relacion")
                    .FirstOrDefault(r => (int)r.Attribute("idUsuario") == beUsuario.Codigo &&
                         (int)r.Attribute("idRol") == beRol.Codigo);

                if (relacion != null)
                {
                    relacion.Remove();
                    doc.Save(_doc_cuatro);
                    return true;
                }
                else
                {
                    throw new Exception("El rol no esta asociado al usuario");
                }
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public List<BEUsuarioSistema> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Usuarios"));
                    BDXML.Save(_doc);
                    return new List<BEUsuarioSistema>();

                }

                XDocument doc = XDocument.Load(_doc);

                var consulta =
                    from u in doc.Root.Elements("Usuario")
                    select new BEUsuarioSistema
                    {
                        Codigo = int.Parse(u.Attribute("Codigo").Value),
                        Nombre = u.Element("Nombre").Value,
                        Clave = u.Element("Clave").Value,
                        Estado = bool.Parse(u.Element("Estado").Value)
                    };

                return consulta.ToList();
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public List<BEPermisoSimple> ListarPermisosUsuario(BEUsuarioSistema beUsuario) 
        {
            try
            {
                if (!File.Exists(_doc_tres))
                {
                    var BDXML = new XDocument(new XElement("Permisos"));
                    BDXML.Save(_doc_tres);

                }

                XDocument doc = XDocument.Load(_doc_dos);
                XDocument doc_Dos = XDocument.Load(_doc_tres);

               
                //Filtramos los ID's de los permisos que coincidan con el ID del usuario
                //En la tabla intermedia
                var consulta =
                    from id in doc.Root.Elements("Relacion")
                    where
                     id.Attribute("idUsuario").Value == beUsuario.Codigo.ToString()
                    select int.Parse(id.Attribute("idPermiso").Value);

                //Traemos todos los permisos para filtrarlos y devolverlos
                var consulta_dos =
                    from p in doc_Dos.Root.Elements("Permiso")
                    select new BEPermisoSimple
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value
                    };

                List<BEPermisoSimple> permisosUsuario = new List<BEPermisoSimple>();

                //Recorremos todos los permisos existentes
                foreach (var p in consulta_dos)
                {
                    //Cada permiso choca contra los id recolectados
                    foreach (var id in consulta)
                    {
                        //Si hay coincidencia, el permiso se agrega
                        if (p.Codigo == id)
                        {
                            permisosUsuario.Add(p);
                            break;
                        }
                    }
                }

                //Devolvemos los permisos
                return permisosUsuario;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            

        }
        public List<BERol> ListarRolesUsuario(BEUsuarioSistema beUsuario)
        {
            try
            {

                if (!File.Exists(_doc_cinco))
                {
                    var BDXML = new XDocument(new XElement("Roles"));
                    BDXML.Save(_doc_cinco);

                }
                if (!File.Exists(_doc_cuatro))
                {
                    var BDXML = new XDocument(new XElement("RolesUsuarios"));
                    BDXML.Save(_doc_cuatro);

                }

                XDocument doc = XDocument.Load(_doc_cuatro);
                XDocument doc_Dos = XDocument.Load(_doc_cinco);

              
                //Filtramos los ID's de los permisos que coincidan con el ID del usuario
                //En la tabla intermedia
                var consulta =
                    from id in doc.Root.Elements("Relacion")
                    where
                     id.Attribute("idUsuario").Value == beUsuario.Codigo.ToString()
                    select int.Parse(id.Attribute("idRol").Value);

                //Traemos todos los permisos para filtrarlos y devolverlos
                var consulta_dos =
                    from p in doc_Dos.Root.Elements("Rol")
                    select new BERol
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value
                    };

                List<BERol> rolesUsuario = new List<BERol>();

                //Recorremos todos los roles existentes
                foreach (var r in consulta_dos)
                {
                    //Cada permiso choca contra los id recolectados
                    foreach (var id in consulta)
                    {
                        //Si hay coincidencia, el rol se agrega
                        if (r.Codigo == id)
                        {
                            rolesUsuario.Add(r);
                            break;
                        }
                    }
                }

                //Devolvemos los permisos
                return rolesUsuario;
            }
            catch (XmlException ex)
            {

                throw ex;
            }


        }
        public int ObtenerUltimoId()
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from r in doc.Elements("Usuario")
                         select int.Parse(r.Attribute("Codigo").Value);

                if (consulta.Any())
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
        public bool CrearXml()
        {
            try
            {
                //Creamos, si no existe, el archivo y el usuario SuperAdmin
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Usuarios"));
                    BDXML.Save(_doc);

                    XElement xDoc = XElement.Load(_doc);

                    xDoc.Add(new XElement("Usuario",
                        new XAttribute("Codigo", 0),
                        new XElement("Nombre", "SuperAdmin"),
                        new XElement("Clave", "UwB1AHAAZQByAEEAZABtAGkAbgA="),
                        new XElement("Estado", "True")
                        )
                        );

                    xDoc.Save(_doc);
                }
                    

                    if (!File.Exists(_doc_dos)) 
                    {
                        var XML = new XDocument(new XElement("PermisosUsuarios"));
                        XML.Save(_doc_dos);

                        XElement xDoc_dos = XElement.Load(_doc_dos);
                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 0)));
                        
                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 1)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 2)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 3)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 4)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 5)));
                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 6)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 7)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 8)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 9)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 10)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 11)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 12)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 13)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 14)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 15)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 16)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 17)));

                        xDoc_dos.Add(new XElement("Relacion",
                         new XAttribute("idUsuario", 0),
                         new XAttribute("idPermiso", 18)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 19)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 20)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 21)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 22)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 23)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 24)));

                        xDoc_dos.Add(new XElement("Relacion",
                        new XAttribute("idUsuario", 0),
                        new XAttribute("idPermiso", 25)));

                        xDoc_dos.Save(_doc_dos);


                    }
                    return true;
    
            }
            catch (Exception)
            {

                return false;
            }
        
        }
    }
}
