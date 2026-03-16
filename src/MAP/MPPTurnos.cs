using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using BE;
using Servicios;
using System.IO;
using System.Globalization;
using Org.BouncyCastle.Asn1;

namespace MAP
{
    public class MPPTurnos : IGestorXML<BETurno>
    {
        string _doc = GestorArchivos.ObtenerRutaArchivo("turnos.xml");
        public BETurno BuscarXML(int id)
        {
            throw new NotImplementedException();
        }
        public bool EliminarXML(BETurno beTurno)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                bool flag = false;
                var consulta =
                         from pac in doc.Elements("Turno")
                         select pac;
                foreach (var p in consulta)
                {
                    if (int.Parse(p.Attribute("Codigo").Value) == beTurno.Codigo)
                    {
                        p.Element("Estado").Value = "Cancelado";
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
        public bool GuardarXML(BETurno turno)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Turnos"));
                    BDXML.Save(_doc);
                    
                }
               

                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (turno.Codigo == -1)
                    {
                        turno.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Turnos").Add(
                        new XElement("Turno",
                    new XAttribute("Codigo", turno.Codigo),
                    new XElement("PacienteDNI", turno.PacienteAsociado.DNI),
                    new XElement("PsicologoDNI", turno.PsicologoAsociado.DNI),
                    new XElement("Fecha", turno.Fecha.ToString("yyyy-MM-dd")),
                    new XElement("Sala", turno.Sala),
                    new XElement("Hora", turno.Hora),
                    new XElement("Dia", turno.Dia),
                    new XElement("Estado", turno.Estado),
                    new XElement("Observaciones", turno.Observaciones
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
        public List<BETurno> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Turnos"));
                    BDXML.Save(_doc);
                    return new List<BETurno>();
                }

                var xDoc = XElement.Load(_doc);
                var consulta =
                         from t in xDoc.Elements("Turno")
                         select new
                         {
                             Codigo = t.Attribute("Codigo").Value,
                             Paciente = t.Element("PacienteDNI").Value,
                             Psicologo = t.Element("PsicologoDNI").Value,
                             Fecha = t.Element("Fecha").Value,
                             Sala = t.Element("Sala").Value,
                             Hora = int.Parse(t.Element("Hora").Value),
                             Dia = t.Element("Dia").Value,
                             Estado = t.Element("Estado").Value,
                             Observaciones = t.Element("Observaciones").Value

                         };
                var xDoc_dos = XElement.Load(GestorArchivos.ObtenerRutaArchivo("pacientes.xml"));
                var consulta_dos = 
                    from p in xDoc_dos.Elements("Paciente")
                    select new BEPaciente
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value,
                        Apellido = p.Element("Apellido").Value,
                        DNI = int.Parse(p.Element("DNI").Value),
                        Telefono = long.Parse(p.Element("Telefono").Value),
                        FechaNacimiento = DateTime.TryParse(p.Element("FechaNacimiento")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn) ? fn : DateTime.MinValue,
                        Estado = p.Element("Estado").Value,
                        Observaciones = p.Element("Observaciones").Value,
                        Correo = p.Element("Correo").Value
                    };

                var xDoc_tres = XElement.Load(GestorArchivos.ObtenerRutaArchivo("psicologos.xml"));
                var consulta_tres = 
                    from p in xDoc_tres.Elements("Psicologo")
                    select new BEPsicologo
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value,
                        Apellido = p.Element("Apellido").Value,
                        DNI = int.Parse(p.Element("DNI").Value),
                        Telefono = long.Parse(p.Element("Telefono").Value),
                        FechaNacimiento = DateTime.TryParse(p.Element("FechaNacimiento")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn) ? fn : DateTime.MinValue,
                        Corriente = p.Element("Corriente").Value,
                        Dia = p.Element("Dia").Value,
                        Jornada = p.Element("Jornada").Value,
                        Sala = p.Element("Sala").Value,
                        Estado = bool.TryParse(p.Element("Estado").Value, out var f) ? f : false,
                        Correo = p.Element("Correo").Value,
                        CodigoDeAcceso = int.Parse(p.Element("CodigoDeAcceso").Value)
                    };

                var turnosRaw = consulta.ToList();

                var pacientes = consulta_dos.ToList();
                var psicologos = consulta_tres.ToList();

                var pacientesPorDni = pacientes
                    .GroupBy(x => x.DNI)
                    .ToDictionary(g => g.Key, g => g.First());

                var psicologosPorDni = psicologos
                    .GroupBy(x => x.DNI)
                    .ToDictionary(g => g.Key, g => g.First());

              

                List<BETurno> list_turnos = new List<BETurno>();

                foreach (var t in turnosRaw) 
                {
                    BETurno turno = new BETurno();

                    BEPaciente pac = null;
                    pacientesPorDni.TryGetValue(int.Parse(t.Paciente), out pac);
                    turno.PacienteAsociado = pac; // o clonar si querés

                    BEPsicologo psi = null;
                    psicologosPorDni.TryGetValue(int.Parse(t.Psicologo), out psi);
                    turno.PsicologoAsociado = psi;

                    turno.Codigo = int.Parse(t.Codigo);
                    turno.Fecha = DateTime.TryParse(t.Fecha ,new CultureInfo("es-AR"), DateTimeStyles.None, out var f) ? f : DateTime.MinValue;
                    turno.Sala = t.Sala;
                    turno.Hora = t.Hora;
                    turno.Dia = t.Dia;
                    turno.Estado = t.Estado;
                    turno.Observaciones = t.Observaciones;
                    list_turnos.Add(turno);
                }

                return list_turnos;

            }
            catch (XmlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ModificarXML(BETurno turno)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from t in doc.Elements("Turno")
                         where int.Parse(t.Attribute("Codigo").Value) == turno.Codigo
                         select t;

                foreach (var t in consulta)
                {
                    t.Element("PacienteDNI").Value = turno.PacienteAsociado.DNI.ToString();
                    t.Element("PsicologoDNI").Value = turno.PsicologoAsociado.DNI.ToString();
                    t.Element("Fecha").Value = turno.Fecha.ToString("yyyy-MM-dd");
                    t.Element("Sala").Value = turno.Sala;
                    t.Element("Hora").Value = turno.Hora.ToString();
                    t.Element("Dia").Value = turno.Dia;
                    t.Element("Estado").Value = turno.Estado;
                    t.Element("Observaciones").Value = turno.Observaciones;

                    doc.Save(_doc);

                }

                return true;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
        }
        public bool ActualizarPaciente(BEPaciente bEPaciente)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                //Nos traemos todas las sesiones
                var consulta =
                      from s in doc.Elements("Turno")
                      select s;

                //Nos traemos todos los pacientes
                var consulta_dos =
                   from p in XElement.Load(GestorArchivos.ObtenerRutaArchivo("pacientes.xml")).Elements("Paciente")
                   select new
                   {
                       Codigo = int.Parse(p.Attribute("Codigo").Value),
                       Nombre = p.Element("Nombre").Value,
                       Apellido = p.Element("Apellido").Value,
                       DNI = int.Parse(p.Element("DNI").Value),
                       Telefono = long.Parse(p.Element("Telefono").Value),
                       FechaNacimiento = DateTime.Parse(p.Element("FechaNacimiento").Value),
                       Estado = p.Element("Estado").Value,
                   };

                //Recorremos los pacientes 
                foreach (var p in consulta_dos)
                {
                    //Si el código de algún paciente coincide con el del paciente modificado
                    if (p.Codigo == bEPaciente.Codigo)
                    {
                        //Ingresamos a las sesiones
                        foreach (var s in consulta)
                        {
                            //Si encuentra algun paciente que coincida con el DNI (desactualizado) del paciente
                            if (s.Element("PacienteDNI").Value == p.DNI.ToString())
                            {
                                //Actualizamos el dato del paciente asociado con el nuevo dni
                                s.Element("PacienteDNI").Value = bEPaciente.DNI.ToString();
                                doc.Save(_doc);
                            }
                        }
                    }
                }

                return true;
            }
            catch (XmlException ex)
            { throw ex; }
        }
        public bool ActualizarPsicologo(BEPsicologo bePsicologo)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                //Nos traemos todas las sesiones
                var consulta =
                      from s in doc.Elements("Turno")
                      select s;

                //Nos traemos todos los pacientes
                var consulta_dos =
                     from p in XElement.Load(GestorArchivos.ObtenerRutaArchivo("psicologos.xml")).Elements("Psicologo")
                     select new
                     {
                         Codigo = int.Parse(p.Attribute("Codigo").Value),
                         Nombre = p.Element("Nombre").Value,
                         Apellido = p.Element("Apellido").Value,
                         DNI = int.Parse(p.Element("DNI").Value),
                         Telefono = long.Parse(p.Element("Telefono").Value),
                         FechaNacimiento = DateTime.Parse(p.Element("FechaNacimiento").Value),
                         Corriente = p.Element("Corriente").Value,
                         Dia = p.Element("Dia").Value,
                         Jornada = p.Element("Jornada").Value,
                         Sala = p.Element("Sala").Value,
                         Estado = p.Element("Estado").Value,
                         CodigoDeAcceso = int.Parse(p.Element("CodigoDeAcceso").Value)
                     };

                //Recorremos los pacientes 
                foreach (var p in consulta_dos)
                {
                    //Si el código de algún paciente coincide con el del paciente modificado
                    if (p.Codigo == bePsicologo.Codigo)
                    {
                        //Ingresamos a las sesiones
                        foreach (var s in consulta)
                        {
                            //Si encuentra algun paciente que coincida con el DNI (desactualizado) del paciente
                            if (s.Element("PsicologoDNI").Value == p.DNI.ToString())
                            {
                                //Actualizamos el dato del paciente asociado con el nuevo dni
                                s.Element("PsicologoDNI").Value = bePsicologo.DNI.ToString();
                                doc.Save(_doc);
                            }
                        }
                    }
                }

                return true;
            }
            catch (XmlException ex)
            { throw ex; }
        }
        public int ObtenerUltimoId()
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from r in doc.Elements("Turno")
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

        public bool CancelarTurnosPaciente(BEPaciente bePaciente) 
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                bool flag = false;

                var consulta =
                         from t in doc.Elements("Turno")
                         select t;

                foreach (var t in consulta)
                {
                    if (int.Parse(t.Element("PacienteDNI").Value) == bePaciente.DNI)
                    {
                        t.Element("Estado").Value = "Cancelado";
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

        public bool CancelarTurnosPsicologo(BEPsicologo bePsicologo)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                bool flag = false;

                var consulta =
                         from t in doc.Elements("Turno")
                         select t;

                foreach (var t in consulta)
                {
                    if (int.Parse(t.Element("PsicologoDNI").Value) == bePsicologo.DNI)
                    {
                        t.Element("Estado").Value = "Cancelado";
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
