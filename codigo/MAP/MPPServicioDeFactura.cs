using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Servicios;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using System.Windows.Forms;


namespace MAP
{
    public class MPPServicioDeFactura : IGestorXML<BEFactura>
    {
        // Cultura argentina para fechas y moneda
        private readonly CultureInfo CultureAr = new CultureInfo("es-AR");

        //Acceso al xml con la información de las facturas
        private string _doc = GestorArchivos.ObtenerRutaArchivo("facturas.xml");

        //Acceso a la ruta donde guardar los archivos PDF
        string ruta = ConfigurationManager.AppSettings["PDF"];
        string rutaBase;

        //Acceso a la ruta donde guardar los recursos
        string rutaRecurso = ConfigurationManager.AppSettings["Recursos"];
        string rutaRecursoBase;

        //Acceso a la ruta donde guardar los recursos
        string rutaCupon= ConfigurationManager.AppSettings["Cupon"];
        string rutaCuponBase;

        string rutaLogo;
        

        public MPPServicioDeFactura() 
        {
            rutaBase = Environment.ExpandEnvironmentVariables(
            ruta ?? "%LOCALAPPDATA%\\eGestalt\\Facturas");

            //Crea la carpeta si no existe
            Directory.CreateDirectory(rutaBase);

            rutaRecursoBase = Environment.ExpandEnvironmentVariables(
            rutaRecurso ?? "%LOCALAPPDATA%\\eGestalt\\Recursos");

            //Crea la carpeta si no existe
            Directory.CreateDirectory(rutaRecursoBase);


            rutaCuponBase = Environment.ExpandEnvironmentVariables(
            rutaCupon ?? "%LOCALAPPDATA%\\eGestalt\\Cupones");

            //Crea la carpeta si no existe
            Directory.CreateDirectory(rutaCuponBase);

            rutaLogo = GestorArchivos.ObtenerRutaArchivoImg("LOGO_PSICO.png");
        }
        public BEFactura BuscarXML(int id)
        {
            throw new NotImplementedException();
        }

        public bool EliminarXML(BEFactura bEFactura)
        {
            throw new NotImplementedException();
        }

        public bool GuardarXML(BEFactura beFactura)
        {
            if (!File.Exists(_doc))
            {
                var BDXML = new XDocument(new XElement("Facturas"));
                BDXML.Save(_doc);
               
            }
           
                XDocument xmlDoc = XDocument.Load(_doc);

                xmlDoc.Element("Facturas").Add(
                new XElement("Factura",
            new XAttribute("Codigo", beFactura.Codigo),
            new XElement("FormaDePago", beFactura.formaDePago),
            new XElement("Monto", beFactura.Monto.ToString()),
            new XElement("NumeroDePago", beFactura.NumeroPago.ToString()),
            new XElement("NumeroDeFactura", beFactura.NumeroFactura.ToString()),
            new XElement("PuntoDeVenta", beFactura.PuntoVenta.ToString()
            )));


                xmlDoc.Save(_doc);
                return true;
            
        }

        public List<BEFactura> ListarXML()
        {
          

            List<BEFactura> lista_facturas = new List<BEFactura>();

            if (!File.Exists(_doc))
            {
                var BDXML = new XDocument(new XElement("Facturas"));
                BDXML.Save(_doc);
                return lista_facturas;

            }
            var consulta =
                from t in XElement.Load(_doc).Elements("Factura")
                select new BEFactura
                {
                    Codigo = int.Parse(t.Attribute("Codigo").Value),
                    formaDePago = t.Element("FormaDePago").Value,
                    Monto = decimal.Parse(t.Element("Monto").Value),
                    NumeroPago = int.Parse(t.Element("NumeroDePago").Value),
                    NumeroFactura = int.Parse(t.Element("NumeroDeFactura").Value),
                    PuntoVenta = int.Parse(t.Element("PuntoDeVenta").Value)
                };
            foreach (var factura in consulta)
            {
                BEFactura bEFactura = new BEFactura();
                bEFactura.Codigo = factura.Codigo;
                bEFactura.formaDePago = factura.formaDePago;
                bEFactura.Monto = factura.Monto;
                bEFactura.NumeroFactura = factura.NumeroFactura;
                bEFactura.NumeroPago = factura.NumeroPago;
                bEFactura.PuntoVenta = factura.PuntoVenta;

                lista_facturas.Add(bEFactura);
            }
            return lista_facturas;
        }

        public bool ModificarXML(BEFactura bEFactura)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoId()
        {
            try
            {
                List<BEFactura> lista = new List<BEFactura>();

                lista = ListarXML();

                if(lista.Count > 0) 
                {
                    return lista.Select(f => f.Codigo).Max();
                }

                else 
                {
                    return 0;
                }

            }
            catch (Exception EX)
            {

                throw EX;
            }
        }

        public int ObtenerNumeroFactura() 
        {
            try
            {
                List<BEFactura> lista = new List<BEFactura>();

                lista = ListarXML();

                if (lista.Count > 0)
                {
                    return lista.Select(f => f.NumeroFactura).Max();
                }

                else
                {
                    return 0;
                }

            }
            catch (Exception EX)
            {

                throw EX;
            }
        }

        //La función devuelve un string correspondiente a la ruta del archivo PDF generado para poder abrirlo posteriormente. En caso de error, devuelve un string vacío.
        public string GenerarComprobante(BEPago bePago, BEFactura bEFactura, BEPaciente bePaciente) 
        { 
            try 
            {
                if(bePago != null) 
                {
                    if(bEFactura != null) 
                    {
                        if(bePaciente != null) 
                        {
                            //Generamos el nombre del archivo y obtenemos su ruta
                            string nombreArchivo = $"Factura_{bEFactura.Codigo}.pdf";
                            string rutaPDF = GestorArchivos.ObtenerRutaArchivoPDF(nombreArchivo);

                            if (String.IsNullOrEmpty(rutaPDF)) { throw new Exception("La ruta del archivo no puede estar vacía"); }

                            //Si llegase a existir el archivo, lo eliminamos ya que a continuación lo vamos a crear
                            if (File.Exists(rutaPDF)) {File.Delete(rutaPDF);}

                            using (FileStream fs = new FileStream(rutaPDF, FileMode.Create)) 
                            {
                                Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

                                //Creamos el lector de PDF
                                PdfWriter lectorPDF;

                                try
                                {
                                    lectorPDF = PdfWriter.GetInstance(doc, fs);
                                }
                                catch (Exception ex)
                                {

                                    throw ex;
                                }

                                //Instanciamos distintas fuentes a utilizar
                                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
                                var fontH1 = new Font(baseFont, 16, Font.BOLD);
                                var fontH2 = new Font(baseFont, 12, Font.BOLD);
                                var fontBody = new Font(baseFont, 10, Font.NORMAL);
                                var fontMono = new Font(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED), 10);

                                doc.Open();

                                var tblHeader = new PdfPTable(new float[] { 20f, 50f, 30f }) { WidthPercentage = 100 };

                                //AGREGAMOS EL LOGO A LA FACTURA
                                PdfPCell logoCell;
                                if (File.Exists(rutaLogo))
                                {
                                    var logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                                    logo.ScaleToFit(60f, 60f);
                                    logoCell = new PdfPCell(logo) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f };
                                }
                                else
                                {
                                    logoCell = new PdfPCell(new Phrase("")) { Border = Rectangle.NO_BORDER };
                                }

                                tblHeader.AddCell(logoCell);

                                tblHeader.AddCell(Cell($"{ConfigurationManager.AppSettings["Nombre"]}", fontH1, Element.ALIGN_LEFT, padding: 6, border: Rectangle.NO_BORDER));

                                var idFactura = FormatearFactura(bEFactura.PuntoVenta, bEFactura.NumeroFactura);

                                tblHeader.AddCell(Cell($"FACTURA\nN°: {idFactura}", fontH1, Element.ALIGN_RIGHT, padding: 6, border: Rectangle.NO_BORDER));

                             
                                tblHeader.AddCell(Cell($"{ConfigurationManager.AppSettings["Direccion"]}\nFecha: {bEFactura.Fecha.ToString("dd/MM/yyyy", CultureAr)}",
                                                       fontBody, Element.ALIGN_LEFT, padding: 4, border: Rectangle.NO_BORDER));

                                doc.Add(tblHeader);

                                doc.Add(Separador(12));

                                // Datos del paciente
                                var tblPaciente = new PdfPTable(new float[] { 25f, 75f }) { WidthPercentage = 100 };
                                tblPaciente.AddCell(HeaderCell("Paciente", fontH2, colspan: 2));
                                tblPaciente.AddCell(LabelCell("Apellido y Nombre:", fontBody));
                                tblPaciente.AddCell(ValueCell(bePaciente.ToString(), fontBody));
                                tblPaciente.AddCell(LabelCell("Documento:", fontBody));
                                tblPaciente.AddCell(ValueCell(bePaciente.DNI.ToString(), fontBody));
                                tblPaciente.AddCell(LabelCell("Teléfono / Email:", fontBody));
                                tblPaciente.AddCell(ValueCell($"{bePaciente.Telefono.ToString() ?? "-"} / {bePaciente.Correo ?? "-"}", fontBody));
                                doc.Add(tblPaciente);

                                doc.Add(Separador(10));

                                // Datos del pago
                                var tblPago = new PdfPTable(new float[] { 25f, 25f, 25f, 25f }) { WidthPercentage = 100 };
                                tblPago.AddCell(HeaderCell("Pago", fontH2, colspan: 4));
                                tblPago.AddCell(LabelCell("Medio de pago:", fontBody));
                                tblPago.AddCell(ValueCell(bePago.MetodoDePago.Nombre, fontBody));
                                tblPago.AddCell(LabelCell("N° de pago:", fontBody));
                                tblPago.AddCell(ValueCell(bePago.NumeroDePago.ToString() ?? "-", fontBody));

                                tblPago.AddCell(LabelCell("Monto total:", fontBody));
                                tblPago.AddCell(ValueCell(FormatearMoneda(bEFactura.Monto), fontBody));
                                tblPago.AddCell(LabelCell("Fecha:", fontBody));
                                tblPago.AddCell(ValueCell(bEFactura.Fecha.ToString("dd/MM/yyyy", CultureAr), fontBody));
                                doc.Add(tblPago);

                                doc.Add(Separador(15));

                                //Observaciones
                                    var tblObs = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
                                    tblObs.AddCell(HeaderCell("Observaciones", fontH2));
                                    tblObs.AddCell(ValueCell("Factura relacionada al abono de una sesión", fontBody, padding: 6));

                                    doc.Add(tblObs);

                                    doc.Add(Separador(6));
                                

                                var tblPie = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
                                tblPie.AddCell(Cell("Este documento es un comprobante emitido por sistema. Conserve para su control.\n" +
                                                    "No válido como factura fiscal AFIP salvo que se indique lo contrario.",
                                                    new Font(baseFont, 8, Font.ITALIC, BaseColor.GRAY),
                                                    Element.ALIGN_CENTER, padding: 6, border: Rectangle.NO_BORDER));
                                doc.Add(tblPie);

                                doc.Close();
                                lectorPDF.Close();

                                return rutaPDF;

                            }

                        }
                        return "";
                    }
                    return "";
                }
                return "";
            } 
            catch 
            {
                return "";
            }  
        }

        public string GenerarCuponDePago(BEPaciente bePaciente, BECuponDePago beCupon, decimal beTarifa) 
        {
            try
            {
                if (bePaciente != null)
                {
                    if (beCupon != null)
                    {
                       
                            //Generamos el nombre del archivo y obtenemos su ruta
                            string nombreArchivo = $"Cupon_{beCupon.Codigo}.pdf";
                            string rutaPDF = GestorArchivos.ObtenerRutaCupon(nombreArchivo);

                            if (String.IsNullOrEmpty(rutaPDF)) { throw new Exception("La ruta del archivo no puede estar vacía"); }

                            //Si llegase a existir el archivo, lo eliminamos ya que a continuación lo vamos a crear
                            if (File.Exists(rutaPDF)) { File.Delete(rutaPDF); }

                            using (FileStream fs = new FileStream(rutaPDF, FileMode.Create))
                            {
                                Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

                                //Creamos el lector de PDF
                                PdfWriter lectorPDF;

                                try
                                {
                                    lectorPDF = PdfWriter.GetInstance(doc, fs);
                                }
                                catch (Exception ex)
                                {

                                    throw ex;
                                }

                                //Instanciamos distintas fuentes a utilizar
                                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
                                var fontH1 = new Font(baseFont, 16, Font.BOLD);
                                var fontH2 = new Font(baseFont, 12, Font.BOLD);
                                var fontBody = new Font(baseFont, 10, Font.NORMAL);
                                var fontMono = new Font(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.EMBEDDED), 10);

                                doc.Open();

                                var tblHeader = new PdfPTable(new float[] { 20f, 50f, 30f }) { WidthPercentage = 100 };

                                //AGREGAMOS EL LOGO A LA FACTURA
                                PdfPCell logoCell;
                                if (File.Exists(rutaLogo))
                                {
                                    var logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                                    logo.ScaleToFit(60f, 60f);
                                    logoCell = new PdfPCell(logo) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f };
                                }
                                else
                                {
                                    logoCell = new PdfPCell(new Phrase("")) { Border = Rectangle.NO_BORDER };
                                }

                                tblHeader.AddCell(logoCell);

                                tblHeader.AddCell(Cell($"{ConfigurationManager.AppSettings["Nombre"]}", fontH1, Element.ALIGN_LEFT, padding: 6, border: Rectangle.NO_BORDER));

                                tblHeader.AddCell(Cell("CUPÓN DE PAGO", fontH1, Element.ALIGN_RIGHT, padding: 6, border: Rectangle.NO_BORDER));

                                tblHeader.AddCell(Cell($"{ConfigurationManager.AppSettings["Direccion"]}",
                                                       fontBody, Element.ALIGN_LEFT, padding: 4, border: Rectangle.NO_BORDER));

                                tblHeader.AddCell(Cell($"N°: {beCupon.NumeroDeCupon}\nFecha: {beCupon.FechaDeEmision.ToString("dd/MM/yyyy", CultureAr)}",
                                                       fontBody, Element.ALIGN_RIGHT, padding: 4, border: Rectangle.NO_BORDER));
                                doc.Add(tblHeader);

                                doc.Add(Separador(12));

                                // Datos del paciente
                                var tblPaciente = new PdfPTable(new float[] { 25f, 75f }) { WidthPercentage = 100 };
                                tblPaciente.AddCell(HeaderCell("Paciente", fontH2, colspan: 2));
                                tblPaciente.AddCell(LabelCell("Apellido y Nombre:", fontBody));
                                tblPaciente.AddCell(ValueCell(bePaciente.ToString(), fontBody));
                                tblPaciente.AddCell(LabelCell("Documento:", fontBody));
                                tblPaciente.AddCell(ValueCell(bePaciente.DNI.ToString(), fontBody));
                                tblPaciente.AddCell(LabelCell("Teléfono / Email:", fontBody));
                                tblPaciente.AddCell(ValueCell($"{bePaciente.Telefono.ToString() ?? "-"} / {bePaciente.Correo ?? "-"}", fontBody));
                                doc.Add(tblPaciente);

                                doc.Add(Separador(10));

                                // Datos del pago
                                var tblPago = new PdfPTable(new float[] { 25f, 25f, 25f, 25f }) { WidthPercentage = 100 };
                            tblPago.AddCell(HeaderCell("Datos del cupón", fontH2, colspan: 4));

                                tblPago.AddCell(LabelCell("Monto a abonar:", fontBody));
                                tblPago.AddCell(ValueCell(beTarifa.ToString(), fontBody));
                                tblPago.AddCell(LabelCell("Fecha de vencimiento:", fontBody));
                                tblPago.AddCell(ValueCell(beCupon.FechaVencimiento.ToString("dd/MM/yyyy", CultureAr), fontBody));
                                doc.Add(tblPago);

                                doc.Add(Separador(15));

                                //Observaciones
                                var tblObs = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
                                tblObs.AddCell(HeaderCell("Observaciones", fontH2));
                                tblObs.AddCell(ValueCell("Puede abonar este cupón de pago en cualquier RapiPago o PagoFácil", fontBody, padding: 6));

                                doc.Add(tblObs);

                                doc.Add(Separador(6));


                                var tblPie = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100 };
                                tblPie.AddCell(Cell("Este documento es un comprobante emitido por sistema. Conserve para su control.\n" +
                                                    "No válido como factura fiscal AFIP salvo que se indique lo contrario.",
                                                    new Font(baseFont, 8, Font.ITALIC, BaseColor.GRAY),
                                                    Element.ALIGN_CENTER, padding: 6, border: Rectangle.NO_BORDER));
                                doc.Add(tblPie);

                                doc.Close();
                                lectorPDF.Close();

                                return rutaPDF;

                            }
                    }
                    return "";
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        private string FormatearMoneda(decimal value)
        {
            // Si trabajás con ARS: muestra $ con separador de miles y coma
            return string.Format(CultureAr, "{0:C}", value);
        }

        private string FormatearFactura(int pVta, int NroFactura) 
        {
            return $"{pVta:0000}--{NroFactura:00000000}";
        }

        private static PdfPCell HeaderCell(string text, Font font, int colspan = 1)
        {
            var c = new PdfPCell(new Phrase(text, font))
            {
                Colspan = colspan,
                HorizontalAlignment = Element.ALIGN_LEFT,
                BackgroundColor = new BaseColor(245, 245, 245),
                Padding = 6f,
                Border = Rectangle.BOX
            };
            return c;
        }

        private static PdfPCell LabelCell(string text, Font font)
        {
            var f = new Font(font.BaseFont, font.Size, Font.BOLD);
            return Cell(text, f, Element.ALIGN_LEFT, padding: 5f);
        }

        private static PdfPCell ValueCell(string text, Font font, float padding = 5f)
        {
            return Cell(text ?? "-", font, Element.ALIGN_LEFT, padding: padding);
        }

        private static PdfPCell Cell(string text, Font font, int hAlign, float padding = 4f, int border = Rectangle.BOX)
        {
            return new PdfPCell(new Phrase(text ?? "", font))
            {
                HorizontalAlignment = hAlign,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Padding = padding,
                Border = border
            };
        }

        private static Paragraph Separador(float espacio)
        {
            return new Paragraph(" ") { SpacingBefore = espacio / 2f, SpacingAfter = espacio / 2f };
        }


    }
}
