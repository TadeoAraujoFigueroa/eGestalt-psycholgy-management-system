using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Servicios;
using Xceed.Words.NET;

namespace MAP
{
    public class MPPBitacora : IGestorXML<BEBitacora>
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("bitacoras.xml");

        private string _doc_usuarios = GestorArchivos.ObtenerRutaArchivo("usuarios.xml");
        public BEBitacora BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        public bool EliminarXML(BEBitacora beBitacora)
        {
            throw new NotImplementedException();
        }

        public bool GuardarXML(BEBitacora beBitacora)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Bitacoras"));
                    BDXML.Save(_doc);
                  
                }

              
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (beBitacora.Codigo == -1)
                    {
                        beBitacora.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Bitacoras").Add(
                            new XElement("Bitacora",
                            new XAttribute("Codigo", beBitacora.Codigo.ToString()),
                            new XElement("FechaRegistro", beBitacora.FechaRegistro),
                            new XElement("Detalle", beBitacora.Detalle),
                            new XElement("Usuario", beBitacora.beUsuario.Codigo.ToString()
                    )));
                    }

                    xmlDoc.Save(_doc);
                    return true;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BEBitacora> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Bitacoras"));
                    BDXML.Save(_doc);
                    return new List<BEBitacora>();
                }

                else
                {
                    XDocument xmlDoc = XDocument.Load(_doc);
                    XDocument xmlDocDos = XDocument.Load(_doc_usuarios);

                    var consulta =
                        from b in xmlDoc.Root.Elements("Bitacora")
                        select new BEBitacora
                        {
                            Codigo = int.Parse(b.Attribute("Codigo").Value),
                            FechaRegistro = b.Element("FechaRegistro").Value,
                            Detalle = b.Element("Detalle").Value,
                            beUsuario = new BEUsuarioSistema
                            {
                                Codigo = int.Parse(b.Element("Usuario").Value)
                            }
                        };

                    var consulta_usuarios =

                          from u in xmlDocDos.Root.Elements("Usuario")
                          select new BEUsuarioSistema
                          {
                              Codigo = int.Parse(u.Attribute("Codigo").Value),
                              Nombre = u.Element("Nombre").Value,
                              Clave = u.Element("Clave").Value,
                              Estado = bool.Parse(u.Element("Estado").Value)
                          };

                    List<BEBitacora> listaBitacoras = new List<BEBitacora>();

                    foreach(var b in consulta) 
                    {
                        foreach(var u in consulta_usuarios) 
                        {
                            if(b.beUsuario.Codigo == u.Codigo) 
                            {
                                b.beUsuario = u;
                                listaBitacoras.Add(b);
                            }
                        }
                    }

                    return listaBitacoras;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool ModificarXML(BEBitacora beBitacora)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoId()
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from r in doc.Elements("Bitacora")
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
    }
}
