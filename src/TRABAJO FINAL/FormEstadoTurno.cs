using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormEstadoTurno : Form
    {
        //Datos para la creación del turno
        //Podemos reemplazarlos por un objeto BETurno
        DateTime _fecha;
        int _hora;
        string _psico;
        string _paciente;
        string _sala;

        //Objetos de BLL y BE
        BLLTurno bllTurno;
        BETurno beTurno;

        BETarifa beTarifa;
        BLLTarifa bllTarifa;    

        BLLSesion bllSesion;
        BESesion beSesion;

        //Contador para determinar el evento CheckedChanged
        int contador = 0;
        public FormEstadoTurno(DateTime fecha, BETurno turno)
        {
            InitializeComponent();
            beTurno = turno;

            _fecha = fecha;
            _psico = beTurno.PsicologoAsociado.ToString();
            _paciente = beTurno.PacienteAsociado.ToString();
            _sala = beTurno.Sala;
            _hora = beTurno.Hora;

            bllTurno = new BLLTurno();
            bllSesion = new BLLSesion();
            bllTarifa = new BLLTarifa();

        }

        private void FormEstadoTurno_Load(object sender, EventArgs e)
        {
            try
            {
                //En los lables mostramos la información del turno
                lbl_fecha.Text = _fecha.ToString("dd/MM/yyyy");
                lbl_hora.Text = $"{_hora}:00";
                lbl_psico.Text = _psico;
                lbl_paciente.Text = _paciente;
                lbl_sala.Text = _sala;
                //Por defecto, seteamos la opción programado
                if (beTurno.Estado == "Realizado")
                {
                    rb_realizado.Checked = true;

                    //Si el turno está realizado, no permitimos el cambio
                    //a otro estado
                    rb_cancelado.Enabled = false;
                    rb_programado.Enabled = false;
                    rbAusente.Enabled = false;
                }
                else if (beTurno.Estado == "Cancelado")
                {
                    rb_cancelado.Checked = true;
                }
                else
                {
                    rb_programado.Checked = true;
                }
                //guardamos las observaciones
                textBox1.Text = beTurno.Observaciones;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void RegistrarPagoNulo() 
        {
            try
            {
                BEPago pagoNulo = new BEPago();
                pagoNulo.Codigo = -1;
                pagoNulo.Fecha = DateTime.Now;
                pagoNulo.MetodoDePago = null;
                pagoNulo.NumeroDePago = 0;

                BESesion bESesion = new BESesion();
                bESesion.Fecha = beTurno.Fecha;
                bESesion.Hora = beTurno.Hora;
                bESesion.PacienteAsociado = beTurno.PacienteAsociado;
                bESesion.PsicologoAsociado = beTurno.PsicologoAsociado;
                bESesion.Dia = beTurno.Dia;
                bESesion.Pago = pagoNulo;
                bESesion.Estado = "No Abonado";
                bESesion.Observaciones = beTurno.Observaciones;

                //Creamos el objeto tarifa
                beTarifa = bllTarifa.RetornarTarifaActual();

                //Lo vinculamos a la sesión
                bESesion.Tarifa = beTarifa;
                bESesion.Codigo = -1;
                bllSesion.Guardar(bESesion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                //Según el estado del radio button, definimos el estado del turno
                if (rb_programado.Checked)
                {
                    beTurno.Observaciones = textBox1.Text;
                    bllTurno.Modificar(beTurno);
                    this.Close();
                }
                else
                {
                    if (rbAusente.Checked)
                    {
                        beTurno.Estado = "Ausente";
                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Debe ingresar una observación para cancelar el turno.");
                            return;
                        }
                        beTurno.Observaciones = textBox1.Text;
                        DialogResult rta = MessageBox.Show("¿Desea generar una sesión no abonada vinculada al paciente seleccionado?", "Modificando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rta == DialogResult.Yes)
                        {
                            RegistrarPagoNulo();
                        }
                        else 
                        {
                            MessageBox.Show("El turno no fue modificado"); return;
                        }
                        if (bllTurno.Modificar(beTurno))
                        {
                            MessageBox.Show("Turno cancelado con éxito.");
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al cancelar el turno.");
                        }


                    }
                    if (rb_realizado.Checked)
                    {
                        //Realizamos la modificación del estado del turno
                        beTurno.Estado = "Realizado";

                        foreach (var t in bllTurno.ListarTodo())
                        {
                            if (t.Codigo == beTurno.Codigo)
                            {

                                //Solo si el turno no estaba realizado anteriormente
                                //Se procede a cambiar su estado
                                if (t.Estado != beTurno.Estado)
                                {
                                    if (textBox1.Text == "")
                                    {
                                        textBox1.Text = "Turno realizado sin observaciones.";
                                    }

                                    beTurno.Observaciones = textBox1.Text;

                                    bllTurno.Modificar(beTurno);

                                    //Se crea la sesión pero con un pago nulo
                                    MessageBox.Show("Se registrará la sesión sin pago asociado.");
                                    RegistrarPagoNulo();
                                    this.Close();
                                }
                                else
                                {
                                    if (textBox1.Text == "")
                                    {
                                        textBox1.Text = "Turno realizado sin observaciones.";
                                    }

                                    beTurno.Observaciones = textBox1.Text;

                                    bllTurno.Modificar(beTurno);

                                }
                            }
                        }


                        MessageBox.Show("Turno modificado con éxito");
                    }
                    if (rb_cancelado.Checked)
                    {
                        beTurno.Estado = "Cancelado";

                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Debe ingresar una observación para cancelar el turno.");
                            return;
                        }

                        beTurno.Observaciones = textBox1.Text;

                        if (bllTurno.Modificar(beTurno))
                        {
                            MessageBox.Show("Turno cancelado con éxito.");
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al cancelar el turno.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void rb_realizado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (contador == 0)
                {
                    contador++;
                    return;
                }
                if (beTurno.Estado == "Realizado")
                {
                    rb_realizado.Checked = true;
                    MessageBox.Show("El turno ya se encuentra como realizado.");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        #region "FUNCIONES NO UTILIZADAS"

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbl_hora_Click(object sender, EventArgs e)
        {

        }

        private void rbAusente_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
