using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using BE;
using Servicios;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;

namespace MAP
{
    public class MPPPaciente : IGestorXML<BEPaciente>
    {
        private string _doc = GestorArchivos.ObtenerRutaArchivo("pacientes.xml");
        public BEPaciente BuscarXML(int id)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                BEPaciente bEPaciente = new BEPaciente();
     
                var consulta =
                    from p in doc.Elements("Paciente")
                    where int.Parse(p.Attribute("Codigo").Value) == id
                    select new
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value,
                        Apellido = p.Element("Apellido").Value,
                        DNI = int.Parse(p.Element("DNI").Value),
                        Telefono = long.Parse(p.Element("Telefono").Value),
                        FechaNacimiento = DateTime.TryParse(p.Element("FechaNacimiento")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn) 
                                                                                                  ? fn : DateTime.MinValue,
                        Estado = p.Element("Estado").Value,

                        

                    };
                //si encuentra un paciente con ese id, lo mapea a BEPaciente y busca su obra social
                if (consulta.Count() > 0)
                {
                    foreach (var p in consulta)
                    {
                        bEPaciente.Nombre = p.Nombre;
                        bEPaciente.Apellido = p.Apellido;
                        bEPaciente.DNI = p.DNI;
                        bEPaciente.Telefono = p.Telefono;
                        bEPaciente.FechaNacimiento = p.FechaNacimiento;
                        bEPaciente.Estado = p.Estado;
                        bEPaciente.Codigo = p.Codigo;
                    }            

                    //Retornamos el paciente
                    return bEPaciente;

                }

                else
                {
                    throw new Exception("No se encontro un paciente con ese ID");
                }
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
           

          
        }

        public bool EliminarXML(BEPaciente paciente)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                bool flag = false;
                var consulta =
                         from pac in doc.Elements("Paciente")
                         select pac;
                foreach (var p in consulta)
                {
                    if (int.Parse(p.Attribute("Codigo").Value) == paciente.Codigo)
                    {
                        p.Element("Estado").Value = "Discontinuado";
                        p.Element("FechaBaja").Value = DateTime.Now.ToString("yyyy-MM-dd");
                        doc.Save(_doc);
                        flag = true; break;
                    }
                }

                return flag;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }

        public bool GuardarXML(BEPaciente Paciente)
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Pacientes"));
                    BDXML.Save(_doc);
                  
                }
              
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (Paciente.Codigo == -1)
                    {
                        Paciente.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Pacientes").Add(
                        new XElement("Paciente",
                    new XAttribute("Codigo", Paciente.Codigo),
                    new XElement("Nombre", Paciente.Nombre),
                    new XElement("Apellido", Paciente.Apellido),
                    new XElement("DNI", Paciente.DNI),
                    new XElement("Telefono", Paciente.Telefono),
                    new XElement("FechaNacimiento", Paciente.FechaNacimiento.ToString("yyyy-MM-dd")),
                    new XElement("Estado", Paciente.Estado),
                    new XElement("Observaciones", Paciente.Observaciones),
                    new XElement("Correo", Paciente.Correo),
                    new XElement("FechaIngreso",Paciente.FechaIngreso.ToString("yyyy-MM-dd")),
                    new XElement("FechaBaja", 0)
                    ));
                    }
                    xmlDoc.Save(_doc);

                    return true;
                
            }
            catch (XmlException ex)
            { throw ex; }
            catch (Exception)
            {
                return false;
            }
        }
                
       
        public List<BEPaciente> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Pacientes"));
                    BDXML.Save(_doc);
                    return new List<BEPaciente>();

                }
                XElement doc = XElement.Load(_doc);

         
                var consulta =
                    from p in doc.Elements("Paciente")
                    select new
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value,
                        Apellido = p.Element("Apellido").Value,
                        DNI = int.Parse(p.Element("DNI").Value),
                        Telefono = long.Parse(p.Element("Telefono").Value),
                        FechaNacimiento = DateTime.TryParse(p.Element("FechaNacimiento")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn)
                                                                                                  ? fn : DateTime.MinValue,
                        Estado = p.Element("Estado").Value,
                        Correo = p.Element("Correo").Value,
                        Observaciones = p.Element("Observaciones").Value,
                        FechaIngreso = DateTime.TryParse(p.Element("FechaIngreso")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fi)
                                                                                                                     ? fi : DateTime.MinValue,
                        FechaDeBaja = DateTime.TryParse(p.Element("FechaBaja")?.Value, out DateTime bajaTemp)
                                                                                        ? bajaTemp
                                                                                         : DateTime.MinValue
                     };

                List<BEPaciente> lista_pacientes = new List<BEPaciente>();


                foreach (var p in consulta)
                {
                    BEPaciente paciente = new BEPaciente(
                        p.Nombre,
                        p.Apellido,
                        p.DNI,
                        p.Telefono,
                        p.FechaNacimiento,
                        p.Correo,
                        p.FechaIngreso
                        
                        );
                    paciente.Observaciones = p.Observaciones;
                    paciente.Codigo = p.Codigo;
                    paciente.Estado = p.Estado;
                    paciente.FechaDeBaja = p.FechaDeBaja;
            

                    lista_pacientes.Add(paciente);
                }


                return lista_pacientes;
            }
            catch (XmlException ex)
            { 

                throw ex;
            }
            

        }

        public bool ModificarXML(BEPaciente paciente)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from pac in doc.Elements("Paciente")
                         where int.Parse(pac.Attribute("Codigo").Value) == paciente.Codigo
                         select pac;

                foreach (var p in consulta)
                {
                    p.Element("Nombre").Value = paciente.Nombre;
                    p.Element("Apellido").Value = paciente.Apellido;
                    p.Element("DNI").Value = paciente.DNI.ToString();
                    p.Element("Telefono").Value = paciente.Telefono.ToString();
                    p.Element("FechaNacimiento").Value = paciente.FechaNacimiento.ToString("yyyy-MM-dd");
                    p.Element("Estado").Value = paciente.Estado;
                    p.Element("Correo").Value= paciente.Correo;
                    p.Element("FechaIngreso").Value = paciente.FechaIngreso.ToString("yyyy-MM-dd");
                    p.Element("Observaciones").Value = paciente.Observaciones;

                    //Generamos este bloque en el caso de que el usuario modificado tenga fecha de baja nula
                    try { p.Element("FechaBaja").Value = paciente.FechaDeBaja.ToString("yyyy-MM-dd"); }
                    catch { throw new Exception("La fecha de baja fue nula, por lo que no se guardó"); }
                    finally 
                    {
                        doc.Save(_doc);
                    }
                    

                   

                }

                return true;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }
        public bool ExisteDni(int dni) 
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                var consulta =
                         from pac in doc.Elements("Paciente")
                         where int.Parse(pac.Element("DNI").Value) == dni
                         select pac;
                return consulta.Count() != 0;
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
                         from r in doc.Elements("Paciente")
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
        public bool DarAltaXML(BEPaciente paciente) 
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                bool flag = false;
                var consulta =
                         from pac in doc.Elements("Paciente")
                         select pac;
                foreach (var p in consulta)
                {
                    if (int.Parse(p.Attribute("Codigo").Value) == paciente.Codigo)
                    {
                        p.Element("Estado").Value = "Activo";
                        p.Element("FechaBaja").Value = "0";
                        doc.Save(_doc);
                        flag = true; break;
                    }
                }

                return flag;

            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }

    }
}
