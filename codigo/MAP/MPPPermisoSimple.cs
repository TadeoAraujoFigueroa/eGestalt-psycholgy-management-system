using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Servicios;

namespace MAP
{
    public class MPPPermisoSimple
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("permisos.xml");
        public List<BEPermisoSimple> listarTodos() 
        {
            try
            {
                XDocument doc = XDocument.Load(_doc);

                var consulta =
                    from p in doc.Root.Elements("Permiso")
                    select new BEPermisoSimple
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value
                    };

                return consulta.ToList();
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
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Permisos"));
                    BDXML.Save(_doc);

                    XElement xDoc = XElement.Load(_doc);

                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 0),
                        new XElement("Nombre", "AltaPacientes")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 1),
                        new XElement("Nombre", "PacientesActivos")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 2),
                        new XElement("Nombre", "PacientesDescontinuados")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 3),
                        new XElement("Nombre", "PacientesEnEspera")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 4),
                        new XElement("Nombre", "AltaPsicologos")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 5),
                        new XElement("Nombre", "VerListaPsicologos")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 6),
                        new XElement("Nombre", "Turnero")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 7),
                        new XElement("Nombre", "TabladeTurnos")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 8),
                        new XElement("Nombre", "TabladeSesiones")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 9),
                        new XElement("Nombre", "CalcularNuevaTarifa")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 10),
                        new XElement("Nombre", "HistoriasClinicas")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 11),
                        new XElement("Nombre", "CalculodeHonorarios")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 12),
                        new XElement("Nombre", "TabladeSalarios")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 13),
                        new XElement("Nombre", "CuponesSolicitados")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 14),
                        new XElement("Nombre", "RealizarBackUp")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 15),
                        new XElement("Nombre", "RealizarRestore")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 16),
                        new XElement("Nombre", "Bitácora")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 17),
                        new XElement("Nombre", "GestordeRolesyPermisos")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 18),
                        new XElement("Nombre", "ABMUsuarios")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 19),
                        new XElement("Nombre", "EnviarMail")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 20),
                        new XElement("Nombre", "RealizarReportedeSesiones")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 21),
                        new XElement("Nombre", "VerInformesaValidar")
                    ));
                    xDoc.Add(new XElement("Permiso",
                        new XAttribute("Codigo", 22),
                        new XElement("Nombre", "VerInformesRealizados")
                    ));
                    xDoc.Add(new XElement("Permiso",
                       new XAttribute("Codigo", 23),
                       new XElement("Nombre", "VerDashBoard")
                   ));
                    xDoc.Add(new XElement("Permiso",
                       new XAttribute("Codigo", 24),
                       new XElement("Nombre", "CerrarSesión")
                   ));
                    xDoc.Add(new XElement("Permiso",
                       new XAttribute("Codigo", 25),
                       new XElement("Nombre", "SalirdelSistema")
                   ));

                    xDoc.Save(_doc);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
