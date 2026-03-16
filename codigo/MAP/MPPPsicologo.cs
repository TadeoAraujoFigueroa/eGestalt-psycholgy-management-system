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

namespace MAP
{
    public class MPPPsicologo : IGestorXML<BEPsicologo>
    {

        private string _doc = GestorArchivos.ObtenerRutaArchivo("psicologos.xml");
        public BEPsicologo BuscarXML(int id)  
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                BEPsicologo psicologo = null;

                var consulta =
                    from p in doc.Elements("Psicologos")
                    where int.Parse(p.Element("Codigo").Value) == id
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
                        Correo = p.Element("Correo").Value,
                        CodigoDeAcceso = int.Parse(p.Element("CodigoDeAcceso").Value),
                        FechaIngreso = DateTime.Parse(p.Element("FechaIngreso").Value)
                    };

                foreach (var item in consulta)
                {
                    psicologo = new BEPsicologo(item.Nombre, item.Apellido, item.DNI, item.Telefono, item.FechaNacimiento, item.Corriente, item.Dia, item.Jornada, item.Sala, bool.Parse(item.Estado), item.Correo, item.CodigoDeAcceso,item.FechaIngreso);
                    psicologo.Codigo = item.Codigo;
                }

                return psicologo;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }


        //Realizamos la baja lógica
        public bool EliminarXML(BEPsicologo psico)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                bool flag = false;
                var consulta =
                         from pac in doc.Elements("Psicologo")
                         select pac;
                foreach (var p in consulta)
                {
                    if (int.Parse(p.Attribute("Codigo").Value) == psico.Codigo)
                    {
                        p.Element("Estado").Value = "False";
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

        public bool GuardarXML(BEPsicologo psico)
        {
            try
            {
                if (!File.Exists(_doc)) 
                {
                    var BDXML = new XDocument(new XElement("Psicologos"));
                    BDXML.Save(_doc);
                  
                }
             
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (psico.Codigo == -1)
                    {
                        psico.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Psicologos").Add(
                        new XElement("Psicologo",
                    new XAttribute("Codigo", psico.Codigo),
                    new XElement("Nombre", psico.Nombre),
                    new XElement("Apellido", psico.Apellido),
                    new XElement("DNI", psico.DNI),
                    new XElement("Telefono", psico.Telefono),
                    new XElement("FechaNacimiento", psico.FechaNacimiento.ToString("yyyy-MM-dd")),
                    new XElement("Corriente", psico.Corriente),
                    new XElement("Dia", psico.Dia),
                    new XElement("Jornada", psico.Jornada),
                    new XElement("Sala", psico.Sala),
                    new XElement("Estado", psico.Estado.ToString()),
                    new XElement("Correo", psico.Correo),
                    new XElement("CodigoDeAcceso", psico.CodigoDeAcceso.ToString()),
                    new XElement("FechaIngreso", psico.FechaIngreso.ToString("yyyy-MM-dd"))
                    ));
                    

                    xmlDoc.Save(_doc);     
                    }

                    return true;

            }
            catch (XmlException ex)
            { throw ex; }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BEPsicologo> ListarXML()
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Psicologos"));
                    BDXML.Save(_doc);
                    return new List<BEPsicologo>();
                }
                XElement doc = XElement.Load(_doc);

                var consulta =
                    from p in doc.Elements("Psicologo")
                    select new
                    {
                        Codigo = int.Parse(p.Attribute("Codigo").Value),
                        Nombre = p.Element("Nombre").Value,
                        Apellido = p.Element("Apellido").Value,
                        DNI = int.Parse(p.Element("DNI").Value),
                        Telefono = long.Parse(p.Element("Telefono").Value),
                        FechaNacimiento = DateTime.TryParse(p.Element("FechaNacimiento")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fn)
                                                                                           ? fn
                                                                                           : DateTime.MinValue,
                        Corriente = p.Element("Corriente").Value,
                        Dia = p.Element("Dia").Value,
                        Jornada = p.Element("Jornada").Value,
                        Sala = p.Element("Sala").Value,
                        Estado = p.Element("Estado").Value,
                        Correo = p.Element("Correo").Value,
                        CodigoDeAceso = int.Parse(p.Element("CodigoDeAcceso").Value),
                        FechaIngreso = DateTime.TryParse(p.Element("FechaIngreso")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out var fi)
                                                                                           ? fi
                                                                                           : DateTime.MinValue
                    };

                List<BEPsicologo> lista_psicologos = new List<BEPsicologo>();

                foreach (var p in consulta)
                {
                    BEPsicologo psico = new BEPsicologo(p.Nombre, p.Apellido, p.DNI, p.Telefono, p.FechaNacimiento, p.Corriente, p.Dia, p.Jornada, p.Sala, bool.Parse(p.Estado), p.Correo, p.CodigoDeAceso, p.FechaIngreso);
                    psico.Codigo = p.Codigo;
                    lista_psicologos.Add(psico);
                }
                return lista_psicologos;
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

        public bool ModificarXML(BEPsicologo psico)
        {
            try
            {
                XElement doc = XElement.Load(_doc);

                var consulta =
                         from pac in doc.Elements("Psicologo")
                         where int.Parse(pac.Attribute("Codigo").Value) == psico.Codigo
                         select pac;

                foreach (var p in consulta)
                {
                    p.Element("Nombre").Value = psico.Nombre;
                    p.Element("Apellido").Value = psico.Apellido;
                    p.Element("DNI").Value = psico.DNI.ToString();
                    p.Element("Telefono").Value = psico.Telefono.ToString();
                    p.Element("FechaNacimiento").Value = psico.FechaNacimiento.ToString("yyyy-MM-dd");
                    p.Element("Corriente").Value = psico.Corriente;
                    p.Element("Dia").Value = psico.Dia;
                    p.Element("Jornada").Value = psico.Jornada;
                    p.Element("Sala").Value = psico.Sala;
                    p.Element("Estado").Value = psico.Estado.ToString();
                    p.Element("Correo").Value = psico.Correo;
                    p.Element("CodigoDeAcceso").Value = psico.CodigoDeAcceso.ToString();
                    p.Element("FechaIngreso").Value = psico.FechaIngreso.ToString("yyyy-MM-dd");

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
                         from r in doc.Elements("Psicologo")
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

        public bool ExisteDni(int dni)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                var consulta =
                         from pac in doc.Elements("Psicologo")
                         where int.Parse(pac.Element("DNI").Value) == dni
                         select pac;
                return consulta.Count() != 0;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }
        public bool ExisteCodigoDeAcceso(int codigo)
        {
            try
            {
                XElement doc = XElement.Load(_doc);
                var consulta =
                         from pac in doc.Elements("Psicologo")
                         where int.Parse(pac.Element("CodigoDeAcceso").Value) == codigo
                         select pac;
                return consulta.Count() != 0;
            }
            catch (XmlException ex)
            {

                throw ex;
            }
            
        }
    }
}
