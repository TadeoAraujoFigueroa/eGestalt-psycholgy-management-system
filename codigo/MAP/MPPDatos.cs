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
    public class MPPDatos
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("salas.xml");
        private string _doc_dos = GestorArchivos.ObtenerRutaArchivo("jornadas.xml");
        private string _doc_tres = GestorArchivos.ObtenerRutaArchivo("dias.xml");
        public List<BEDatos> retornarDias() 
        {
            try
            {
                XElement xDocument = XElement.Load(_doc_tres);

                var consulta =
                    from s in xDocument.Elements("Dia")
                    select new BEDatos
                    {
                        Codigo = int.Parse(s.Attribute("Codigo").Value),
                        Nombre = s.Element("Nombre").Value

                    };

                return consulta.ToList();
            }
            catch (XmlException ex)
            {

                throw ex;
            }
           


        }
        public List<BEDatos> retornarJornada()
        {
            try
            {
                XElement xDocument = XElement.Load(_doc_dos);

                var consulta =
                    from s in xDocument.Elements("Jornada")
                    select new BEDatos
                    {
                        Codigo = int.Parse(s.Attribute("Codigo").Value),
                        Nombre = s.Element("Nombre").Value

                    };

                return consulta.ToList();
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }
        public List<BEDatos> retornarSalas()
        {
            try
            {
                XElement xDocument = XElement.Load(_doc);

                var consulta =
                    from s in xDocument.Elements("Sala")
                    select new BEDatos
                    {
                        Codigo = int.Parse(s.Attribute("Codigo").Value),
                        Nombre = s.Element("Nombre").Value

                    };

                return consulta.ToList();
            }
            catch (XmlException ex)
            {

                throw ex; 
            }
          
        }
            
        public bool CrearXml() 
        {
            try
            {
                //Creamos el archivo con las salas
                if (!File.Exists(_doc))
                {
                    XDocument XMLSalas = new XDocument(new XElement("Salas"));

                    XMLSalas.Save(_doc);

                    //Cargamos los datos
                    XElement XMLS = XElement.Load(_doc);

                    XMLS.Add(new XElement("Sala",
                        new XAttribute("Codigo", 0),
                        new XElement("Nombre", "Sala Uno")));
                    XMLS.Add(new XElement("Sala",
                        new XAttribute("Codigo", 1),
                        new XElement("Nombre", "Sala Dos")));
                    XMLS.Add(new XElement("Sala",
                        new XAttribute("Codigo", 2),
                        new XElement("Nombre", "Sala Tres")));
                    XMLS.Add(new XElement("Sala",
                        new XAttribute("Codigo", 3),
                        new XElement("Nombre", "Sala Cuatro")));
                    XMLS.Add(new XElement("Sala",
                        new XAttribute("Codigo", 4),
                        new XElement("Nombre", "Sala Cinco")));
                    XMLS.Add(new XElement("Sala",
                        new XAttribute("Codigo", 5),
                        new XElement("Nombre", "Sala Seis")));

                    XMLS.Save(_doc);
                }

                //Creamos el archivo con las salas
                if (!File.Exists(_doc_dos))
                {
                    XDocument XMLSalas = new XDocument(new XElement("Jornadas"));

                    XMLSalas.Save(_doc_dos);

                    //Cargamos los datos
                    XElement XMLS = XElement.Load(_doc_dos);

                    XMLS.Add(new XElement("Jornada",
                        new XAttribute("Codigo", 0),
                        new XElement("Nombre", "Mañana")));
                    XMLS.Add(new XElement("Jornada",
                        new XAttribute("Codigo", 1),
                        new XElement("Nombre", "Tarde")));
              

                    XMLS.Save(_doc_dos);
                }

                //Creamos el archivo con los días
                if (!File.Exists(_doc_tres))
                {
                    XDocument XMLSalas = new XDocument(new XElement("Dias"));

                    XMLSalas.Save(_doc_tres);

                    //Cargamos los datos
                    XElement XMLS = XElement.Load(_doc_tres);

                    XMLS.Add(new XElement("Dia",
                        new XAttribute("Codigo", 0),
                        new XElement("Nombre", "Lunes")));
                    XMLS.Add(new XElement("Dia",
                        new XAttribute("Codigo", 1),
                        new XElement("Nombre", "Martes")));
                    XMLS.Add(new XElement("Dia",
                        new XAttribute("Codigo", 2),
                        new XElement("Nombre", "Miercoles")));
                    XMLS.Add(new XElement("Dia",
                        new XAttribute("Codigo", 3),
                        new XElement("Nombre", "Jueves")));
                    XMLS.Add(new XElement("Dia",
                        new XAttribute("Codigo", 4),
                        new XElement("Nombre", "Viernes")));

                    XMLS.Save(_doc_tres);
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
