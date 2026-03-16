using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;

namespace TRABAJO_FINAL
{
    public partial class FormAltaPago : Form
    {
        BLLMetodoDePago bllMetodoDePago;
        BLLTarifa bllTarifa;
        BLLSesion bllSesion;
        BLLPago bllPago;

        BEPago bePago;
        BETurno beTurno;   
        BETarifa beTarifa;
        BEPaciente bePaciente;

        //Objetos para generar factura
        BEFactura beFactura;
        ServicioDeFacturas servicioDeFacturas;
        
        public FormAltaPago(BETurno beTurno)
        {
            try
            {
                InitializeComponent();

                this.beTurno = beTurno;

                bllPago = new BLLPago();
                bllMetodoDePago = new BLLMetodoDePago();
                bllSesion = new BLLSesion();
                bllTarifa = new BLLTarifa();
                servicioDeFacturas = new ServicioDeFacturas();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al inicializar componentes\n♀{ex.Message}");
            }
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormAltaPago_Load(object sender, EventArgs e)
        {
            cb_metodo_pago.DataSource = bllMetodoDePago.retornarMetodosDePago();
            this.BackgroundImage = Image.FromFile(GestorArchivos.ObtenerRutaArchivoImg("fondo_pago.jpg"));
            this.BackgroundImageLayout = ImageLayout.Zoom;

        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                //Corroboramos que todos los text box esten llenos
                foreach (var c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        if (string.IsNullOrEmpty(((TextBox)c).Text))
                        {
                            MessageBox.Show("Por favor complete todos los campos.");
                            return;
                        }
                    }
                }

                //Guardamos el paciente asociado al turno
                bePaciente = beTurno.PacienteAsociado;

                //Creamos el pago asociado
                bePago = new BEPago();
                bePago.Codigo = -1;
                bePago.MetodoDePago = (BEMetodoDePago)cb_metodo_pago.SelectedItem;
                bePago.Fecha = dateTimePicker1.Value;
                bePago.NumeroDePago = int.Parse(txtNumPago.Text);
                bllPago.Guardar(bePago);
                MessageBox.Show("Pago registrado con éxito.");

                //Una vez que tenemos el pago y el turno, creamos la sesión
                BESesion bESesion = new BESesion();
                bESesion.Fecha = beTurno.Fecha;
                bESesion.Hora = beTurno.Hora;
                bESesion.PacienteAsociado = bePaciente;
                bESesion.PsicologoAsociado = beTurno.PsicologoAsociado;
                bESesion.Dia = beTurno.Dia;
                bESesion.Pago = bePago;
                bESesion.Observaciones = beTurno.Observaciones;
                bESesion.Estado = "Abonado";

                //Creamos el objeto tarifa
                beTarifa = bllTarifa.RetornarTarifaActual();

                //Lo vinculamos a la sesión
                bESesion.Tarifa = beTarifa;

                //Establecemos el codigo de la sesion para guardarlo
                bESesion.Codigo = -1;
                //Guardamos la sesión
                bllSesion.Guardar(bESesion);

                //Creamos el comprobante asociado al pago
                beFactura = new BEFactura();
                beFactura.Codigo = servicioDeFacturas.RetornarID();
                beFactura.NumeroFactura = servicioDeFacturas.RetornarNroFactura();
                beFactura.PuntoVenta = servicioDeFacturas.ObtenerPuntoDeVenta();
                beFactura.Monto = beTarifa.Total;
                beFactura.Fecha = DateTime.Now;
                beFactura.formaDePago = bePago.MetodoDePago.ToString();

                //Guardamos la factura
                servicioDeFacturas.Guardar(beFactura);
                //Generamos el PDF
                string ruta_comprobante = servicioDeFacturas.GenerarComprobante(bePago, beFactura, bePaciente);
                if (ruta_comprobante != "")
                {
                    if (File.Exists(ruta_comprobante))
                    {
                        MessageBox.Show($"Comprobante generado correctamente.\n Puede verlo en la ruta: {ConfigurationManager.AppSettings["PDF"]}");
                        //Objeto para abrir el PDF generado con el programa predeterminado del sistema
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = ruta_comprobante,
                            UseShellExecute = true
                        };
                        Process.Start(psi);

                    }

                        
                }
                else
                {
                    MessageBox.Show("Error al generar el comprobante.");
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al dar de alta el pago\n {ex.Message}");
            }
            

        }

        private void txtNumPago_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
