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
    public class MPPInforme
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("informes.xml");

        public bool GuardarInforme(BEInforme  beInforme) 
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Informes"));
                    BDXML.Save(_doc);
                    
                }

               
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (beInforme.Codigo == -1)
                    {
                        beInforme.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Informes").Add(
                        new XElement("Informe",
                        new XAttribute("Codigo", beInforme.Codigo),
                    new XElement("ContenidoBytes", Convert.ToBase64String(beInforme.ContenidoBytes)),
                    new XElement("Estado", beInforme.Estado),
                    new XElement("FechaGeneracion", beInforme.FechaGeneracion.ToString("yyyy-MM-dd")),
                    new XElement("Observaciones", beInforme.Observaciones
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

        public List<BEInforme> listarInformesActivos() 
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Informes"));
                    BDXML.Save(_doc);
                    return new List<BEInforme>();
                }

                List<BEInforme> listaInformes = new List<BEInforme>();
                XElement doc = XElement.Load(_doc);

               
                var consulta =
                         from informe in doc.Elements("Informe")
                         where informe.Element("Estado").Value == "Validado" ||
                         informe.Element("Estado").Value == "Generado"
                         select new BEInforme
                         {
                             Codigo = (int)informe.Attribute("Codigo"),
                             ContenidoBytes = Convert.FromBase64String((string)informe.Element("ContenidoBytes")),
                             Estado = (string)informe.Element("Estado"),
                             FechaGeneracion = DateTime.Parse((string)informe.Element("FechaGeneracion")),
                             Observaciones = (string)informe.Element("Observaciones")
                         };

                listaInformes = consulta.ToList();
                return listaInformes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public List<BEInforme> listarInformesRechazados()
        {
            try
            {
                List<BEInforme> listaInformes = new List<BEInforme>();
                XElement doc = XElement.Load(_doc);
                var consulta =
                         from informe in doc.Elements("Informe")
                         where informe.Element("Estado").Value == "Rechazado"
                         select new BEInforme
                         {
                             Codigo = (int)informe.Attribute("Codigo"),
                             Estado = (string)informe.Element("Estado"),
                             FechaGeneracion = DateTime.Parse((string)informe.Element("FechaGeneracion")),
                             Observaciones = (string)informe.Element("Observaciones")
                         };

                listaInformes = consulta.ToList();
                return listaInformes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool ModificarInforme(BEInforme beInforme) 
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var informeModificar =
                         from informe in doc.Elements("Informe")
                         where (int)informe.Attribute("Codigo") == beInforme.Codigo
                         select informe;

                if (beInforme.Estado == "Validado")
                {
                    beInforme.Observaciones = beInforme.Observaciones + $" Informe validado el {DateTime.Now.ToShortDateString()} por el usuario actual.";

                    foreach (var informe in informeModificar)
                    {
                        informe.Element("ContenidoBytes").Value = Convert.ToBase64String(beInforme.ContenidoBytes);
                        informe.Element("Estado").Value = beInforme.Estado;
                        informe.Element("FechaGeneracion").Value = beInforme.FechaGeneracion.ToString("yyyy-MM-dd");
                        informe.Element("Observaciones").Value = beInforme.Observaciones;
                        doc.Save(_doc);
                    }

                }
                //Esto significa que el informe fue rechazado
                else
                {
                    foreach (var informe in informeModificar)
                    {
                        //Eliminamos el contenido, ya no interesá guardarlo
                        informe.Element("ContenidoBytes").Value = "0";
                        informe.Element("Estado").Value = beInforme.Estado;
                        informe.Element("FechaGeneracion").Value = beInforme.FechaGeneracion.ToString("yyyy-MM-dd");
                        informe.Element("Observaciones").Value = beInforme.Observaciones;
                        doc.Save(_doc);
                        doc.Save(_doc);
                    }
                }

                return true;
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
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from r in doc.Elements("Informe")
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
