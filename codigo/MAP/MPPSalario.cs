using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class MPPSalario
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("salarios.xml");
        private string _doc_psico = GestorArchivos.ObtenerRutaArchivo("psicologos.xml");

        public bool GuardarSalario(BESalario beSalario) 
        {
            try
            {
                if(!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Cupones"));
                    BDXML.Save(_doc);
                    
                }
              
                    if (beSalario.Codigo == -1)
                    {
                        beSalario.Codigo = ObtenerUltimoId() + 1;

                        XElement doc = XElement.Load(_doc);

                        doc.Add(
                            new XElement("Salario",
                                new XAttribute("Codigo", beSalario.Codigo),
                                new XElement("Fecha", beSalario.Fecha.ToString("yyyy-MM-dd")),
                                new XElement("Monto", beSalario.Monto),
                                new XElement("PsicologoDNI", beSalario.Psicologo.DNI)
                            )
                        );

                        doc.Save(_doc);
                    }

                    return true;
                
              
            }
            catch (XmlException ex)
            {

                throw ex;
            }
         
        }
        public List<BESalario> RetornarSalario() 
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Cupones"));
                    BDXML.Save(_doc);
                    return new List<BESalario>();
                }
            

                XElement doc = XElement.Load(_doc);
                XElement doc_dos = XElement.Load(_doc_psico);

               

                var consulta =
                    from sal in doc.Elements("Salario")
                    select new BESalario
                    {
                        Codigo = int.Parse(sal.Attribute("Codigo").Value),
                        Fecha = DateTime.TryParse(sal.Element("Fecha")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn) ? fn : DateTime.MinValue,
                        Monto = decimal.Parse(sal.Element("Monto").Value),
                        Psicologo = new BE.BEPsicologo
                        {
                            DNI = int.Parse(sal.Element("PsicologoDNI").Value)
                        }
                    };

                var consulta_dos =
                    from p in doc_dos.Elements("Psicologo")
                    select new BEPsicologo
                    {
                        DNI = int.Parse(p.Element("DNI").Value),
                        Nombre = p.Element("Nombre").Value,
                        Apellido = p.Element("Apellido").Value,
                        Telefono = long.Parse(p.Element("Telefono").Value),
                        FechaNacimiento = DateTime.TryParse(p.Element("FechaNacimiento")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn) ? fn : DateTime.MinValue,
                        Corriente = p.Element("Corriente").Value,
                        Dia = p.Element("Dia").Value,
                        Jornada = p.Element("Jornada").Value,
                        Sala = p.Element("Sala").Value,
                        Estado = bool.Parse(p.Element("Estado").Value),
                        Correo = p.Element("Correo").Value,
                        CodigoDeAcceso = int.Parse(p.Element("CodigoDeAcceso").Value)
                    };

                List<BESalario> list_salario = new List<BESalario>();
                foreach (var sal in consulta)
                {
                    List<BEPsicologo> lista_psico = consulta_dos.Where(p => p.DNI == sal.Psicologo.DNI).ToList();

                    foreach (var p in lista_psico) 
                    {
                        sal.Psicologo = p;
                        

                    }
                    list_salario.Add(sal);
                }

                return list_salario;

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
                         from r in doc.Elements("Salario")
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
