using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormModificarSesion : Form
    {
        
        BETurno beTurno;

        BESesion beSesion;
        BLLSesion bllSesion;

        BLLCupon bLLCupon;
        BECuponDePago beCupon;

        BETarifa beTarifa;
        BLLTarifa bllTarifa;

        public FormModificarSesion(BESesion sesion)
        {
            InitializeComponent(); 

            bllSesion = new BLLSesion();
            bllTarifa = new BLLTarifa();
            bLLCupon = new BLLCupon();

            if (sesion == null)
                throw new ArgumentNullException(nameof(sesion), "Se recibió una sesión nula.");

            this.beSesion = sesion;
        }

        private void FormModificarSesion_Load(object sender, EventArgs e)
        {
            try
            {
                //Según el estado de la sesión, setea la opción
                if (beSesion.Estado == "Abonado")
                {
                    rb_2.Checked = true;
                    rb_2.Enabled = true;
                    rb_3.Enabled = false;
                    rb_1.Enabled = false;

                }
                if (beSesion.Estado == "No Abonado")
                {
                    rb_1.Checked = true;
                }
                if (beSesion.Estado == "Cupón Emitido")
                {
                    rb_3.Checked = true;
                }

                if (beSesion.Observaciones != "")
                {
                    txtObservaciones.Text = beSesion.Observaciones;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                //Si no hubo información en el campo de observaciones, se le asigna un valor por defecto para evitar problemas con la base de datos
                if (txtObservaciones.Text == "") 
                {
                    beSesion.Observaciones = "...";
                }

                beSesion.Observaciones = txtObservaciones.Text;

                //Estado 'ABONADO': Si el usuario selecciona esta opción, se le asigna el estado 'Abonado' a la sesión y se verifica si anteriormente no estaba abonada para generar el pago correspondiente
                if (rb_2.Checked)
                {
                    
                    beSesion.Estado = "Abonado";

                    foreach(var s in bllSesion.ListarTodo()) 
                    {
                        if(s.Codigo == beSesion.Codigo) 
                        {
                            //Esto significa que la sesión anteriormente no estaba 'Abonada'
                            //Por lo que debemos registrarle un pago
                            if(s.Estado != beSesion.Estado) 
                            {
                                //Procedemos a guardar los datos de la sesión en un nuevo turno para generar el pago y la nueva sesión con el estado modificado
                                beTurno = new BETurno();
                                beTurno.Observaciones = beSesion.Observaciones;
                                beTurno.Fecha = beSesion.Fecha;
                                beTurno.Dia = beSesion.Dia;
                                beTurno.Hora = beSesion.Hora;
                                beTurno.PacienteAsociado = beSesion.PacienteAsociado;
                                beTurno.PsicologoAsociado = beSesion.PsicologoAsociado;

                                //Procedemos a dar de baja esta sesión, ya que crearemos una nueva con el estado 'Abonado' y el pago asociado
                                bllSesion.Baja(beSesion);

                                //Abrimos el form para realizar el alta de pago
                                Form AltaPago = new FormAltaPago(beTurno);
                                AltaPago.ShowDialog();

                                MessageBox.Show("Sesión modificada con éxito");

                                //Una vez finalizada la modificación, se cierra el form para volver al listado de sesiones
                                this.Close();
                                return;
                            }

                        }
                    }
                }
                //Estado 'NO ABONADO': Si el usuario selecciona esta opción, se le asigna el estado 'No Abonado' a la sesión. No se generan pagos ni cupones de pago, ya que el paciente no abonó la sesión.
                if (rb_1.Checked)
                {
                    beSesion.Estado = "No Abonado";
                }
                //Estado 'CUPÓN EMITIDO': Si el usuario selecciona esta opción, se le asigna el estado 'Cupón Emitido' a la sesión. Se genera un cupón de pago para que el paciente pueda abonar la sesión posteriormente.
                if (rb_3.Checked)
                {
                    beSesion.Estado = "Cupón Emitido";

                    //Creamos la solicitud de cupón
                    beCupon = new BECuponDePago();
                    beTarifa = new BETarifa();
                    beTarifa = bllTarifa.RetornarTarifaActual();
                   
                    if(beSesion == null || beSesion.PacienteAsociado == null) 
                    {
                        MessageBox.Show("Debe seleccionar una sesión");
                        return;
                    }

                    beCupon.NumeroDeCupon = -1;
                    beCupon.FechaDeEmision = DateTime.Now;
                    beCupon.PacienteAsociado = beSesion.PacienteAsociado;
                    beCupon.Monto = beTarifa.Total;

                    if (bLLCupon.Guardar(beCupon)) { MessageBox.Show("Cupón enviado para su emisión"); }
                }

                if (bllSesion.Modificar(beSesion)) 
                {
                    MessageBox.Show("Sesión modificada con éxito");
                }

                //Una vez finalizada la modificación, se cierra el form para volver al listado de sesiones
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
