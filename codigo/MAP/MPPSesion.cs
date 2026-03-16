using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;
using BE;
using System.Xml.Linq;
using System.Xml;
using System.Management.Instrumentation;
using System.IO;
using System.Globalization;

namespace MAP
{
    public class MPPSesion : IGestorXML<BESesion>
    {
        string _doc = GestorArchivos.ObtenerRutaArchivo("sesiones.xml");

        public BESesion BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        public bool EliminarXML(BESesion beSesion)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from t in doc.Elements("Sesion")
                         where int.Parse(t.Attribute("Codigo").Value) == beSesion.Codigo
                         select t;

                //Eliminamos el objeto
                foreach (var t in consulta)
                {
                    t.Remove();
                    doc.Save(_doc);
                }

                return true;
            }
            catch (XmlException ex)
            { throw ex; }
        }

        public bool GuardarXML(BESesion beSesion)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Sesiones"));
                    BDXML.Save(_doc);
                    
                }
               
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (beSesion.Codigo == -1)
                    {
                        beSesion.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Sesiones").Add(
                        new XElement("Sesion",
                    new XAttribute("Codigo", beSesion.Codigo),
                    new XElement("Dia", beSesion.Dia),
                    new XElement("Fecha", beSesion.Fecha.ToString("yyyy-MM-dd")),
                    new XElement("Hora", beSesion.Hora),
                    new XElement("Observaciones", beSesion.Observaciones),
                    new XElement("PacienteAsociado", beSesion.PacienteAsociado.DNI),
                    new XElement("PsicologoAsociado", beSesion.PsicologoAsociado.DNI),
                    new XElement("Tarifa", beSesion.Tarifa.Codigo.ToString()),
                    new XElement("NumeroDePago", beSesion.Pago.NumeroDePago.ToString()),
                    new XElement("Estado", beSesion.Estado)
                    ));
                    }

                    xmlDoc.Save(_doc);

                    return true;
                
               
            }
            catch (XmlException ex)
            {

                throw ex;
            }
           
        }

        public List<BESesion> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Sesiones"));
                    BDXML.Save(_doc);
                    return new List<BESesion>();
                }

                var xDoc = XElement.Load(_doc);
                var consulta =
                     from s in xDoc.Elements("Sesion")
                     select new 
                     {
                         Codigo = int.Parse(s.Attribute("Codigo").Value),
                         Dia = s.Element("Dia").Value,
                         Fecha = DateTime.TryParse(s.Element("Fecha")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var f) ? f : DateTime.MinValue,
                         Hora = int.Parse(s.Element("Hora").Value),
                         Observaciones = s.Element("Observaciones").Value,
                         PacienteAsociado = int.Parse(s.Element("PacienteAsociado").Value),
                         PsicologoAsociado = int.Parse(s.Element("PsicologoAsociado").Value),
                         Tarifa = decimal.Parse(s.Element("Tarifa").Value),
                         NumeroDePago = int.Parse(s.Element("NumeroDePago").Value),
                         Estado = s.Element("Estado").Value

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
                        Estado = bool.TryParse(p.Element("Estado")?.Value, out var f) ? f : false,
                        CodigoDeAcceso = int.Parse(p.Element("CodigoDeAcceso").Value)
                    };
        

                var xDoc_cuatro = XElement.Load(GestorArchivos.ObtenerRutaArchivo("tarifas.xml"));
                var consulta_cinco =
                    from t in xDoc_cuatro.Elements("Tarifa")
                    select new BETarifa
                    {
                        Codigo = int.Parse(t.Attribute("Codigo").Value),
                        Total = decimal.Parse(t.Element("Total").Value),
                        RetencionUno = decimal.Parse(t.Element("RetencionUno").Value),
                        RetencionDos = decimal.Parse(t.Element("RetencionDos").Value),
                        HonorarioPsicologo = decimal.Parse(t.Element("HonorarioPsicologo").Value),
                        Fecha = DateTime.TryParse(t.Element("Fecha")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var f) ? f : DateTime.MinValue,
                    };

                var xDoc_cinco = XElement.Load(GestorArchivos.ObtenerRutaArchivo("pagos.xml"));
                var consulta_seis =
                    from t in xDoc_cinco.Elements("Pago")
                    select new BEPago
                    {
                        Codigo = int.Parse(t.Attribute("Codigo").Value),
                        NumeroDePago = int.Parse(t.Element("NumeroDePago").Value),
                        Fecha = DateTime.TryParse(t.Element("Fecha")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var f) ? f : DateTime.MinValue,
                    };

                var sesionesRaw = consulta.ToList();
                var pacientes = consulta_dos.ToList();
                var psicologos = consulta_tres.ToList();
                var tarifas = consulta_cinco.ToList();
                var pagos = consulta_seis.ToList();

                //Creamos diccionarios para optimizar

                var pacientesPorDni = pacientes
                     .GroupBy(x => x.DNI)
                     .ToDictionary(g => g.Key, g => g.First());
                
                var psicologosPorDni = psicologos
                    .GroupBy(x => x.DNI)
                    .ToDictionary(g => g.Key, g=>  g.First());

                var tarifasPorCodigo = tarifas
                    .GroupBy(x => x.Codigo.ToString())
                    .ToDictionary(g => g.Key, g => g.First());

                var pagosPorNumero = 
                    pagos.GroupBy(x => x.NumeroDePago).ToDictionary(g => g.Key, g => g.First());

                List < BESesion > listaSesiones = new List<BESesion>();

                foreach (var s in sesionesRaw) 
                {
                    BESesion sesion = new BESesion();
                    sesion.Codigo = s.Codigo;
                    sesion.Dia = s.Dia;
                    sesion.Fecha = s.Fecha;
                    sesion.Hora = s.Hora;
                    sesion.Observaciones = s.Observaciones;


                    BEPaciente pac = null;
                    pacientesPorDni.TryGetValue(s.PacienteAsociado, out pac);
                    sesion.PacienteAsociado = pac;

                 
                    BEPsicologo psicologo = null;
                    psicologosPorDni.TryGetValue(s.PsicologoAsociado, out psicologo);
                    sesion.PsicologoAsociado = psicologo;

                    BETarifa tarifa = null;
                    tarifasPorCodigo.TryGetValue(s.Tarifa.ToString(), out tarifa);
                    sesion.Tarifa = tarifa;

                    BEPago pago = null;
                    pagosPorNumero.TryGetValue(s.NumeroDePago, out pago);
                    sesion.Pago = pago;


                    sesion.Estado = s.Estado;

                    listaSesiones.Add(sesion);
                }

                return listaSesiones;

            }
            catch(XmlException xmlEx)
            {
                throw xmlEx;
            }
            catch (Exception ex)
            { 
             throw ex; 
            }
        
        }

        public bool ModificarXML(BESesion beSesion)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from t in doc.Elements("Sesion")
                         where int.Parse(t.Attribute("Codigo").Value) == beSesion.Codigo
                         select t;

                foreach (var t in consulta)
                {
                    t.Element("Estado").Value = beSesion.Estado;
                    t.Element("Observaciones").Value = beSesion.Observaciones;

                    doc.Save(_doc);

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
                         from r in doc.Elements("Sesion")
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

        public bool ActualizarPaciente(BEPaciente bEPaciente) 
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                //Nos traemos todas las sesiones
                var consulta =
                      from s in doc.Elements("Sesion")
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
                        foreach(var s in consulta) 
                        {
                            //Si encuentra algun paciente que coincida con el DNI (desactualizado) del paciente
                            if(s.Element("PacienteAsociado").Value == p.DNI.ToString()) 
                            {
                                //Actualizamos el dato del paciente asociado con el nuevo dni
                                s.Element("PacienteAsociado").Value = bEPaciente.DNI.ToString();
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
                      from s in doc.Elements("Sesion")
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
                            if (s.Element("PsicologoAsociado").Value == p.DNI.ToString())
                            {
                                //Actualizamos el dato del paciente asociado con el nuevo dni
                                s.Element("PsicologoAsociado").Value = bePsicologo.DNI.ToString();
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
    }
}
