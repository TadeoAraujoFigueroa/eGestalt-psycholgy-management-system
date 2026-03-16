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
    public partial class FormTablaDeTurnos : Form
    {
        BLLTurno bllTurno;
        BETurno beTurno;

        BLLSesion bllSesion;

        BLLTarifa bllTarifa;
        BETarifa beTarifa;

        BLLCupon bLLCupon;
        BECuponDePago bECuponDePago;

        DateTime fecha = DateTime.Now;

        int hora;

        List<string> horasExistentes;

        List<BETurno> listaTurnos;
        public FormTablaDeTurnos()
        {
            InitializeComponent();
            bllTurno = new BLLTurno();
            bllSesion = new BLLSesion();
            bllTarifa = new BLLTarifa();
            bLLCupon = new BLLCupon();
            listaTurnos = new List<BETurno>();
            listaTurnos = bllTurno.ListarTodo();
            horasExistentes = listaTurnos.Select(t => t.Hora.ToString()).Distinct().ToList();
            horasExistentes.Add("Todas");
        }

        private void FormTablaDeTurnos_Load(object sender, EventArgs e)
        {
            try
            {   
                //Traemos las horas existentes para desplegarlas en el combo box   
                cbHora.DataSource = horasExistentes;
                //Guardamos la fecha y hora para filtrar los turnos
                fecha = datePicker.Value;

                bool flag = int.TryParse(cbHora.Text, out hora);

                if (!flag)
                {
                    throw new Exception("No existen turnos que mostrar");
                }

                //Inicializamos la grilla con los turnos del día actual y la hora seleccionada
                var filtradas = listaTurnos.Where(t => t.Hora == hora && t.Estado == "Programado" &&
                                                       t.Fecha.Date >= datePicker.Value.Date  &&
                                                       t.Fecha.Date <= datePicker2.Value.Date ).ToList();

                dgvTurnos.DataSource = null;
                dgvTurnos.DataSource = filtradas;
                dgvTurnos.Columns["Codigo"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          

}

        private void ActualizarTabla() 
        {
            try
            {
                
                //Guardamos la fecha y hora para filtrar los turnos
                fecha = datePicker.Value;

                if(cbHora.Text == "Todas") 
                {
                    var filtradas = listaTurnos.Where(t => t.Estado == "Programado" &&
                                                          t.Fecha.Date >= datePicker.Value.Date &&
                                                          t.Fecha.Date <= datePicker2.Value.Date).ToList();
                    dgvTurnos.DataSource = null;
                    dgvTurnos.DataSource = filtradas;
                    return;
                }

                bool flag = int.TryParse(cbHora.Text, out hora);

                if (!flag)
                {
                    throw new Exception("No existen turnos que mostrar");
                }

                //Inicializamos la grilla con los turnos del día actual y la hora seleccionada
                var filtradas_dos = listaTurnos.Where(t => t.Hora == hora && t.Estado == "Programado" &&
                                                      t.Fecha.Date >= datePicker.Value.Date &&
                                                      t.Fecha.Date <= datePicker2.Value.Date).ToList();

                dgvTurnos.DataSource = null;
                dgvTurnos.DataSource = filtradas_dos;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void cbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvTurnos.SelectedRows.Count > 0) 
                {
                    //Creamos el objeto tarifa
                    beTarifa = bllTarifa.RetornarTarifaActual();

                    beTurno = dgvTurnos.SelectedRows[0].DataBoundItem as BETurno;

                    DialogResult rta = MessageBox.Show("¿Desea asociar un pago a este turno?", "Asociar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (rta == DialogResult.Yes)
                    {
                        FormAltaPago formAltaPago = new FormAltaPago(beTurno);
                        formAltaPago.ShowDialog();
                    }


                    else if (bllSesion.RetornarSesionesNoAbonadas(beTurno.PacienteAsociado) > 2)
                    {
                        rta = MessageBox.Show($"El usuario {beTurno.PacienteAsociado.ToString()} tiene más de dos sesiones sin pagar, ¿Seguro que desea continuar sin asociar un pago?", "Paciente deudor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rta == DialogResult.No) { return; }

                        else
                        {
                            RegistrarPagoNulo();

                        }
                    }

                    else
                    {
                        RegistrarPagoNulo();

                    }


                    //Cambiamos el estado del turno
                    beTurno.Estado = "Realizado";
                    bllTurno.Modificar(beTurno);


                    //Actualizamos la grilla
                    ActualizarTabla();
                }
                else 
                {
                    MessageBox.Show("Debe seleccionar un turno");
                }
                

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

                //Se crea la sesión pero con un pago nulo
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
                bESesion.Observaciones = beTurno.Observaciones;

   
                //Lo vinculamos a la sesión
                bESesion.Tarifa = beTarifa;
                bESesion.Codigo = -1;

                //Si se emite un cupón, se establece el estado correspondiente
                DialogResult rta = MessageBox.Show("¿Desea solicitar la emisión de un cupón de pago?", "Asociar cupón de pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rta == DialogResult.Yes)
                {
                    bESesion.Estado = "Cupón Emitido";
                    bllSesion.Guardar(bESesion);
                    //Creamos la solicitud de cupón
                    bECuponDePago = new BECuponDePago();
                    bECuponDePago.NumeroDeCupon = -1;
                    bECuponDePago.FechaDeEmision = DateTime.Now;
                    bECuponDePago.PacienteAsociado = beTurno.PacienteAsociado;
                    bECuponDePago.Monto = beTarifa.Total;

                    if (bLLCupon.Guardar(bECuponDePago)) { MessageBox.Show("Cupón enviado para su emisión"); }

                }
                else
                {
                    MessageBox.Show("Se registrará la sesión sin pago asociado.");
                    bESesion.Estado = "No Abonado";
                    bllSesion.Guardar(bESesion);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }
        private void datePicker2_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {

                if(dgvTurnos.SelectedRows.Count > 0) 
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro que desea dar de baja el turno seleccionado?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta == DialogResult.No)
                        return;

                    beTurno = dgvTurnos.SelectedRows[0].DataBoundItem as BETurno;

                    bllTurno.Baja(beTurno);

                    ActualizarTabla();
                }
                else 
                {
                    MessageBox.Show("Debe seleccionar un turno");
                }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
