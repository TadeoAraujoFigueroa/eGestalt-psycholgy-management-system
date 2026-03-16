using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormGeneracionCuponDePago : Form
    {
        private BECuponDePago _beCuponDePago;
        private BEPaciente _bePaciente;

        BLLCupon bllCupon;
        BLLSesion bllSesion;

        ServicioDeFacturas sFacturas;
        public FormGeneracionCuponDePago(BECuponDePago beCuponDePago)
        {
            try
            {
                InitializeComponent();
                this._beCuponDePago = beCuponDePago;
                this._bePaciente = beCuponDePago.PacienteAsociado;
                bllCupon = new BLLCupon();
                bllSesion = new BLLSesion();
                sFacturas = new ServicioDeFacturas();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void FormGeneracionCuponDePago_Load(object sender, EventArgs e)
        {
            try
            {
                //Desactivamos la opción de descargar el cupón de pago hasta que se genere
                btnDescargarCupon.Enabled = false;
                //Info del paciente
                txtDni.Text = _bePaciente.DNI.ToString();
                txtNombre.Text = _bePaciente.ToString();
                txtEstado.Text = _bePaciente.Estado;
                //Info del cupón pre-existente
                txtFechaEmision.Text = _beCuponDePago.FechaDeEmision.ToShortDateString();
                txtNro.Text = _beCuponDePago.NumeroDeCupon.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnGenerarCupon_Click(object sender, EventArgs e)
        {
            try
            {
                if(bllSesion.RetornarSesionesNoAbonadas(_bePaciente) > 2) 
                {
                    MessageBox.Show("El usuario debe más de dos sesiones, no es posible generar un cupón de pago");
                    return;
                }


                if(dateTimePicker1.Value <= DateTime.Now) 
                {
                    MessageBox.Show("La fecha de vencimiento del cupón no puede ser menor o igual a la fecha actual");
                    return;
                }
                //Asociamos la fecha de vencimiento
                _beCuponDePago.FechaVencimiento = dateTimePicker1.Value;

                if (bllCupon.Modificar(_beCuponDePago)) 
                {
                    MessageBox.Show("Cupón generado correctamente, ya puede descargarlo");
                    btnDescargarCupon.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
            

        }

        private void btnDescargarCupon_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta_cupon = sFacturas.GenerarCuponDePago(_beCuponDePago, _bePaciente, _beCuponDePago.Monto);
                if (ruta_cupon != "") 
                {
                    MessageBox.Show($"Comprobante generado correctamente.\n Puede verlo en la ruta: {ConfigurationManager.AppSettings["Cupon"]}");
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        FileName = ruta_cupon
                    };
                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
