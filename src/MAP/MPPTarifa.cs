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
    public class MPPTarifa
    {
        string _doc = GestorArchivos.ObtenerRutaArchivo("tarifas.xml");

        decimal monto = 0;
        public BETarifa RetornarTarifa() 
        {
            if (!File.Exists(_doc))
            {
                var BDXML = new XDocument(new XElement("Tarifas"));
                BDXML.Save(_doc);
                return new BETarifa { Total = 0, RetencionUno = 0, RetencionDos = 0, HonorarioPsicologo = 0, Fecha = DateTime.MinValue };

            }
            var consulta = 
                from t in XElement.Load(_doc).Elements("Tarifa")
                select new 
                {
                    Codigo = int.Parse(t.Attribute("Codigo").Value),
                    Total = decimal.Parse(t.Element("Total").Value),
                    RetencionUno = decimal.Parse(t.Element("RetencionUno").Value),
                    RetencionDos = decimal.Parse(t.Element("RetencionDos").Value),
                    HonorarioPsicologo = decimal.Parse(t.Element("HonorarioPsicologo").Value),
                    Fecha = DateTime.TryParse(t.Element("Fecha")?.Value, new CultureInfo("es-AR"), DateTimeStyles.None, out DateTime fecha) ? fecha : DateTime.MinValue
                };

            //Creamos la tarifa final que se retornará
            BETarifa tarifa_final = new BETarifa(); 

            foreach (var tarifa in consulta)
            {
                //Agarramos la ultima tarifa registrada, que seria la vigente
                if (tarifa.Codigo == (consulta.Count() - 1))
                    //Asignamos el monto a retornar
                    tarifa_final.Codigo = tarifa.Codigo;
                    tarifa_final.Total = tarifa.Total;
                    tarifa_final.RetencionUno = tarifa.RetencionUno;
                    tarifa_final.RetencionDos = tarifa.RetencionDos;
                    tarifa_final.HonorarioPsicologo = tarifa.HonorarioPsicologo;
                    tarifa_final.Fecha = tarifa.Fecha;
            }

            return tarifa_final;

        }
        public bool GuardarNuevaTarifa(BETarifa beTarifa)
        {
            try
            {
                if (!File.Exists(_doc))
                {
                    var BDXML = new XDocument(new XElement("Tarifas"));
                    BDXML.Save(_doc);
                    
                }
            
                    XDocument xmlDoc = XDocument.Load(_doc);

                    if (beTarifa.Codigo == -1)
                    {
                        beTarifa.Codigo = ObtenerUltimoId() + 1;

                        xmlDoc.Element("Tarifas").Add(
                        new XElement("Tarifa",
                    new XAttribute("Codigo", beTarifa.Codigo),
                    new XElement("Total", beTarifa.Total),
                    new XElement("RetencionUno", beTarifa.RetencionUno),
                    new XElement("RetencionDos", beTarifa.RetencionDos),
                    new XElement("HonorarioPsicologo", beTarifa.HonorarioPsicologo),
                    new XElement("Fecha", beTarifa.Fecha.ToString("yyyy-MM-dd")
                    )));
                    }

                    xmlDoc.Save(_doc);
                    return true;
                
                   
            }
            catch(XmlException) 
            {
                return false;
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
                         from r in doc.Elements("Tarifa")
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
        public List<BETarifa> ListarTarifas()
        {
           
            List<BETarifa> lista_tarifas = new List<BETarifa>();

            if (!File.Exists(_doc))
            {
                var BDXML = new XDocument(new XElement("Tarifas"));
                BDXML.Save(_doc);
                return lista_tarifas;

            }

            var consulta =
                from t in XElement.Load(_doc).Elements("Tarifa")
                select new
                {
                    Codigo = int.Parse(t.Attribute("Codigo").Value),
                    Monto = decimal.Parse(t.Element("Total").Value),
                    RetencionUno = decimal.Parse(t.Element("RetencionUno").Value),
                    RetencionDos = decimal.Parse(t.Element("RetencionDos").Value),
                    HonorarioPsicologo = decimal.Parse(t.Element("HonorarioPsicologo").Value),
                    Fecha = DateTime.Parse(t.Element("Fecha").Value)
                };
            foreach (var tarifa in consulta)
            {
                BETarifa beTarifa = new BETarifa();
                beTarifa.Codigo = tarifa.Codigo;
                beTarifa.Total = tarifa.Monto;
                beTarifa.RetencionUno = tarifa.RetencionUno;
                beTarifa.RetencionDos = tarifa.RetencionDos;
                beTarifa.HonorarioPsicologo = tarifa.HonorarioPsicologo;
                beTarifa.Fecha = tarifa.Fecha;
                lista_tarifas.Add(beTarifa);
            }
            return lista_tarifas;
        }
    }
}
