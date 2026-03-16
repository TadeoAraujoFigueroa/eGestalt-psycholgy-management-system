using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using BE;
using Servicios;

namespace MAP
{
    public class MPPPlantilla : IGestorXML<BEPlantillaCorreo>
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("plantillas.xml");
        public BEPlantillaCorreo BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        public bool EliminarXML(BEPlantillaCorreo bePlantilla)
        {
            try
            {
                XElement xmlDoc = XElement.Load(_doc);

                var consulta =
                    from p in xmlDoc.Elements("Plantilla")
                    select p;

                foreach (var p in consulta)
                {
                    if (int.Parse(p.Attribute("Codigo").Value) == bePlantilla.Codigo)
                    {
                        p.Element("Estado").Value = "Inactivo";
                        xmlDoc.Save(_doc);
                        return true;
                    }
                }

                return false;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }

        public bool GuardarXML(BEPlantillaCorreo bePlantilla)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Plantillas"));
                    BDXML.Save(_doc);
                    
                }
              
                    if (bePlantilla.Codigo == -1)
                    {
                        bePlantilla.Codigo = ObtenerUltimoId() + 1;

                        XElement doc = XElement.Load(_doc);

                        doc.Add(
                            new XElement("Plantilla",
                                new XAttribute("Codigo", bePlantilla.Codigo),
                                new XElement("Asunto", bePlantilla.Asunto),
                                new XElement("Mensaje", bePlantilla.Mensaje),
                                new XElement("Estado", bePlantilla.Estado)
                            )
                        );

                        doc.Save(_doc);
                    }

                    return true;
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<BEPlantillaCorreo> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Plantillas"));
                    BDXML.Save(_doc);
                    return new List<BEPlantillaCorreo>();

                }


                XElement xdoc = XElement.Load(_doc);

               
                var consulta =
                    from p in xdoc.Elements("Plantilla")
                    select new BEPlantillaCorreo
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Asunto = p.Element("Asunto").Value,
                        Mensaje = p.Element("Mensaje").Value,
                        Estado = p.Element("Estado").Value
                    };

                return consulta.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }

        public bool ModificarXML(BEPlantillaCorreo bePlantilla)
        {
            try
            {
                XElement xmlDoc = XElement.Load(_doc);

                var consulta =
                    from p in xmlDoc.Elements("Plantilla")
                    select p;

                foreach (var p in consulta)
                {
                    if (p.Attribute("Codigo").Value == bePlantilla.Codigo.ToString())
                    {
                        p.Element("Asunto").Value = bePlantilla.Asunto;
                        p.Element("Mensaje").Value = bePlantilla.Mensaje;
                        p.Element("Estado").Value = bePlantilla.Estado;

                        xmlDoc.Save(_doc);
                        return true;
                    }
                }
                return false;
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
                         from r in doc.Elements("Plantilla")
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
