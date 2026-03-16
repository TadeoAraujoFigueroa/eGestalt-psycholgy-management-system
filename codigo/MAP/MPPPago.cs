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
    public class MPPPago : IGestorXML<BEPago>
    {
        string _doc = GestorArchivos.ObtenerRutaArchivo("pagos.xml");
        public BEPago BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        public bool CrearXml() 
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Pagos"));
                    BDXML.Save(_doc);

                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public bool EliminarXML(BEPago objeto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarXML(BEPago bePago)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Pagos"));
                    BDXML.Save(_doc);
              
                }
              
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (bePago.Codigo == -1)
                    {
                        bePago.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Pagos").Add(
                        new XElement("Pago",
                    new XAttribute("Codigo", bePago.Codigo),
                    new XElement("Fecha", bePago.Fecha.ToString("yyyy-MM-dd")),
                    new XElement("NumeroDePago", bePago.NumeroDePago),
                    new XElement("MetodoDePago", bePago.MetodoDePago.ToString()
                    )));
                    }

                    xmlDoc.Save(_doc);

                    return true;

                
             
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }

        public List<BEPago> ListarXML()
        {
            throw new NotImplementedException();
        }

        public bool ModificarXML(BEPago objeto)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoId()
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from r in doc.Elements("Pago")
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
