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
    public class MPPMetodoDePago
    {
        string _doc = GestorArchivos.ObtenerRutaArchivo("metodosdepago.xml");

        public bool CrearXml()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("MetodosDePago"));
                    BDXML.Save(_doc);


                    XElement xDoc = XElement.Load(_doc);

                    xDoc.Add(new XElement("MetodoDePago",
                        new XAttribute("Codigo", 0),
                        new XElement("Nombre", "TarjetaDeDebito")
                        )
                        );
                    xDoc.Add(new XElement("MetodoDePago",
                      new XAttribute("Codigo", 1),
                      new XElement("Nombre", "TarjetaDeCredito")
                      )
                      );
                    xDoc.Add(new XElement("MetodoDePago",
                      new XAttribute("Codigo", 2),
                      new XElement("Nombre", "QR")
                      )
                      );

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
        public List<BEMetodoDePago> ListarMetodosDePago()
        {
            try
            {
                var consulta = from m in XElement.Load(_doc).Elements("MetodoDePago")
                               select new
                               {
                                   Codigo = int.Parse(m.Attribute("Codigo").Value),
                                   Nombre = m.Element("Nombre").Value,
                               };

                List<BEMetodoDePago> listaMetodosDePago = new List<BEMetodoDePago>();

                foreach (var item in consulta)
                {
                    BEMetodoDePago metodoDePago = null;

                    if (item.Nombre == "TarjetaDeDebito")
                    {
                        metodoDePago = new BETarjeta();
                    }
                    else if (item.Nombre == "TarjetaDeCredito")
                    {
                        metodoDePago = new BETarjeta();
                    }
                    else if (item.Nombre == "QR")
                    {
                        metodoDePago = new BEQR();
                    }
                    if (metodoDePago != null)
                    {
                        metodoDePago.Codigo = item.Codigo;
                        metodoDePago.Nombre = item.Nombre;

                        listaMetodosDePago.Add(metodoDePago);
                    }
                }

                return listaMetodosDePago;

            }
            catch (XmlException ex)
            {

                throw ex;
            }
          
        }
        

    }
}
