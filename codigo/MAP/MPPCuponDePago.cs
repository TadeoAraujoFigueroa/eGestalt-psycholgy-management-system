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
    public class MPPCuponDePago : IGestorXML<BECuponDePago>
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("cupones.xml");
        private string _doc_dos = GestorArchivos.ObtenerRutaArchivo("pacientes.xml");
        public BECuponDePago BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        public bool EliminarXML(BECuponDePago beCupon)
        {
            throw new NotImplementedException();
        }

        public bool GuardarXML(BECuponDePago beCupon)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Cupones"));
                    BDXML.Save(_doc);
                  
                }
               
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (beCupon.NumeroDeCupon == -1)
                    {
                        beCupon.NumeroDeCupon = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Cupones").Add(
                            new XElement("Cupon",
                            new XAttribute("NumeroDeCupon", beCupon.NumeroDeCupon),
                            new XElement("FechaDeEmision", beCupon.FechaDeEmision.ToString("yyyy-MM-dd")),
                            new XElement("PacienteAsociado", beCupon.PacienteAsociado.DNI.ToString()),
                            new XElement("FechaVencimiento", 0),
                            new XElement("Monto", beCupon.Monto.ToString())
                    ));
                    }

                    xmlDoc.Save(_doc);
                    return true;
                
                
            }
            catch (XmlException)
            {
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<BECuponDePago> ListarXMLSinVencimiento()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Cupones"));
                    BDXML.Save(_doc);
                    return new List<BECuponDePago>();

                }

                XElement doc = XElement.Load(_doc);
                XElement doc_dos = XElement.Load(_doc_dos);

                var consulta =
                    from c in doc.Elements("Cupon") where c.Element("FechaVencimiento").Value == "0"
                    select new BECuponDePago()
                    {
                        NumeroDeCupon = int.Parse(c.Attribute("NumeroDeCupon").Value),
                        FechaDeEmision = DateTime.Parse(c.Element("FechaDeEmision").Value),
                        FechaVencimiento = new DateTime(2005, 1, 1),
                        Monto = decimal.Parse(c.Element("Monto").Value),
                        PacienteAsociado = new BEPaciente
                        {
                            DNI = (int.Parse(c.Element("PacienteAsociado").Value))
                        }


                    };
                var consulta_dos =
                         from p in XElement.Load(_doc_dos).Elements("Paciente")
                         select new
                         {
                             Codigo = int.Parse(p.Attribute("Codigo").Value),
                             Nombre = p.Element("Nombre").Value,
                             Apellido = p.Element("Apellido").Value,
                             DNI = int.Parse(p.Element("DNI").Value),
                             Telefono = long.Parse(p.Element("Telefono").Value),
                             FechaNacimiento = DateTime.Parse(p.Element("FechaNacimiento").Value),
                             Estado = p.Element("Estado").Value,
                             Observaciones = p.Element("Observaciones").Value,
                             Correo = p.Element("Correo").Value
                         };

                List<BECuponDePago> list_cupon = new List<BECuponDePago>();
                foreach (var c in consulta)
                {
                    var lista_paciente = consulta_dos.Where(p => p.DNI == c.PacienteAsociado.DNI).ToList();

                    foreach (var p in lista_paciente)
                    {
                        BEPaciente bePaciente = new BEPaciente();
                        bePaciente.Codigo = p.Codigo;
                        bePaciente.Nombre = p.Nombre;
                        bePaciente.Apellido = p.Apellido;
                        bePaciente.DNI = p.DNI;
                        bePaciente.FechaNacimiento = p.FechaNacimiento;
                        bePaciente.Correo = p.Correo;
                        bePaciente.Observaciones = p.Observaciones;
                        bePaciente.Telefono = p.Telefono;
                        bePaciente.Estado = p.Estado;

                        c.PacienteAsociado = bePaciente;

                        if(c.FechaVencimiento < DateTime.Now) 
                        {
                            list_cupon.Add(c);
                        }
                      

                    }
                }

                return list_cupon;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }

        public List<BECuponDePago> ListarXMLConVencimiento() 
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Cupones"));
                    BDXML.Save(_doc);
                    return new List<BECuponDePago>();

                }

                var consulta =
                    from c in doc.Elements("Cupon")
                    select new BECuponDePago()
                    {
                        NumeroDeCupon = int.Parse(c.Attribute("NumeroDeCupon").Value),
                        FechaDeEmision = DateTime.Parse(c.Element("FechaDeEmision").Value),
                        FechaVencimiento = DateTime.Parse(c.Element("FechaVencimiento").Value),
                        Monto = decimal.Parse(c.Element("Monto").Value),
                        PacienteAsociado = new BEPaciente
                        {
                            DNI = (int.Parse(c.Element("PacienteAsociado").Value))
                        }

                    };
                var consulta_dos =
                         from p in XElement.Load("pacientes.xml").Elements("Paciente")
                         select new
                         {
                             Codigo = int.Parse(p.Attribute("Codigo").Value),
                             Nombre = p.Element("Nombre").Value,
                             Apellido = p.Element("Apellido").Value,
                             DNI = int.Parse(p.Element("DNI").Value),
                             Telefono = long.Parse(p.Element("Telefono").Value),
                             FechaNacimiento = DateTime.Parse(p.Element("FechaNacimiento").Value),
                             Estado = p.Element("Estado").Value,
                             ObraSocial = p.Element("ObraSocial").Value,
                             Observaciones = p.Element("Observaciones").Value,
                             Correo = p.Element("Correo").Value
                         };

                List<BECuponDePago> list_cupon = new List<BECuponDePago>();
                foreach (var c in consulta)
                {
                    var lista_paciente = consulta_dos.Where(p => p.DNI == c.PacienteAsociado.DNI).ToList();

                    foreach (var p in lista_paciente)
                    {
                        BEPaciente bePaciente = new BEPaciente();
                        bePaciente.Codigo = p.Codigo;
                        bePaciente.Nombre = p.Nombre;
                        bePaciente.Apellido = p.Apellido;
                        bePaciente.DNI = p.DNI;
                        bePaciente.FechaNacimiento = p.FechaNacimiento;
                        bePaciente.Correo = p.Correo;
                        bePaciente.Observaciones = p.Observaciones;
                        bePaciente.Telefono = p.Telefono;
                        bePaciente.Estado = p.Estado;

                        c.PacienteAsociado = bePaciente;
                        list_cupon.Add(c);

                    }
                }

                return list_cupon;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
           
        }

        public bool ModificarXML(BECuponDePago beCupon)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from c in doc.Elements("Cupon")
                         where int.Parse(c.Attribute("NumeroDeCupon").Value) == beCupon.NumeroDeCupon
                         select c;

                foreach (var c in consulta)
                {
                    c.Element("FechaVencimiento").Value = beCupon.FechaVencimiento.ToString("yyyy-MM-dd");
                    doc.Save(_doc);

                }

                return true;
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
                         from r in doc.Elements("Cupon")
                         select int.Parse(r.Attribute("NumeroDeCupon").Value);

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

        public List<BECuponDePago> ListarXML()
        {
            throw new NotImplementedException();
        }
    }
}
