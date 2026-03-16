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
    public partial class FormCrearTurno : Form
    {
        BLLTurno bllTurno;
        BLLSesion bllSesion;

        BLLPsicologo bllPsicologo;
        BLLPaciente bllPaciente;

        BEPaciente bePaciente;
        BEPsicologo bePsicologo;

        private DateTime _fecha;

        List<int> horariosTarde;

        int cantidad_sesiones = 0;
        int cantidad_turnos = 0;
        int total = 0;

        //Pacientes a los cuáles le podemos asociar un nuevo turno
        List<BEPaciente> pacientes_habilitados;
        List<BEPaciente> pacientes_activos;
        public FormCrearTurno(DateTime fecha, int hora, string sala, string dia)
        {
            try
            {
                InitializeComponent();

                //Inicializamos los horarios que contiene la jornada de la tarde
                horariosTarde = new List<int>() { 13, 14, 15, 16, 17 };

                bllTurno = new BLLTurno();

                bllPaciente = new BLLPaciente();

                bllPsicologo = new BLLPsicologo();

                bllSesion = new BLLSesion();

                pacientes_habilitados = new List<BEPaciente>();

                pacientes_activos = new List<BEPaciente>();

                lbl_Dia.Text = dia;

                lbl_hora.Text = $"{hora}:00";

                lbl_sala.Text = sala;

                _fecha = fecha;

                lbl_psico.Text = "No hay psicólogos disponibles en este turno";

                bllPsicologo.ListarTodo().ForEach(p =>
                {
                    if (p.Dia == dia && p.Sala == sala)
                    {
                        //Si la jornada es tarde, verificamos que el horario este dentro de los horarios de la tarde
                        if (p.Jornada == "Tarde" && horariosTarde.Contains(hora))
                        {
                            lbl_psico.Text = $"{p}";
                            bePsicologo = p;
                        }
                        //Si la jornada es mañana, verificamos que el horario no este dentro de los horarios de la tarde
                        else if (p.Jornada == "Mañana" && !horariosTarde.Contains(hora))
                        {
                            lbl_psico.Text = $"{p}";
                            bePsicologo = p;
                        }

                    }
                });
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        
        private void FormCrearTurno_Load(object sender, EventArgs e)
        {
            try
            {
                pacientes_activos = bllPaciente.ListarActivo();

                foreach (var p in pacientes_activos)
                {
                    cantidad_sesiones = bllSesion.ListarPorPaciente(p.DNI).Count;
                    cantidad_turnos = bllTurno.ListarPorPaciente(p.DNI).Count;

                    total = cantidad_turnos + cantidad_sesiones;

                    if (total < 16)
                    {
                        pacientes_habilitados.Add(p);
                    }
                }
                dgvUsuariosEspera.DataSource = pacientes_habilitados;
                OcultarColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void OcultarColumnas() 
        {
            try
            {
                dgvUsuariosEspera.Columns["Codigo"].Visible = false;
                dgvUsuariosEspera.Columns["Estado"].Visible = false;
                dgvUsuariosEspera.Columns["DNI"].Visible = false;
                dgvUsuariosEspera.Columns["Correo"].Visible = false;
                dgvUsuariosEspera.Columns["FechaNacimiento"].Visible = false;
                dgvUsuariosEspera.Columns["Telefono"].Visible = false;
                dgvUsuariosEspera.Columns["Observaciones"].Visible = false;
                dgvUsuariosEspera.Columns["FechaIngreso"].Visible = false;
                dgvUsuariosEspera.Columns["FechaDeBaja"].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Falla al ocultar columnas\n{ex.Message}");
            }
          

        }
        private void btnCrearTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_psico.Text == "No hay psicólogos disponibles en este turno")
                {
                    MessageBox.Show("No se puede crear el turno porque no hay psicólogos disponibles en este horario y sala.");
                    return;
                }
                if (dgvUsuariosEspera.SelectedRows.Count > 0)
                {

                    if (cb_turnos.Checked)
                    {

                        int i = 0;
                        int add = 0;

                        while (i < 16)
                        {
                            bePaciente = (BEPaciente)dgvUsuariosEspera.SelectedRows[0].DataBoundItem;
                            BETurno beTurno = new BETurno();
                            beTurno.PacienteAsociado = bePaciente;
                            beTurno.PsicologoAsociado = bePsicologo;
                            beTurno.Fecha = _fecha.AddDays(add);
                            beTurno.Hora = int.Parse(lbl_hora.Text.Split(':')[0]);
                            beTurno.Sala = lbl_sala.Text;
                            beTurno.Dia = lbl_Dia.Text;
                            beTurno.Codigo = -1;
                            beTurno.Estado = "Programado";
                            beTurno.Observaciones = txtObservaciones.Text;
                            bllTurno.Guardar(beTurno);
                            bePaciente.Estado = "Activo";
                            bllPaciente.Modificar(bePaciente);
                            

                            //Logica para crear 16 turnos consecutivos (con diferencia de una semana)
                            i++;
                            add += 7;
                        }

                    }
                    else
                    {
                        //Solo creamos un turno
                        bePaciente = (BEPaciente)dgvUsuariosEspera.SelectedRows[0].DataBoundItem;
                        BETurno beTurno = new BETurno();
                        beTurno.PacienteAsociado = bePaciente;
                        beTurno.PsicologoAsociado = bePsicologo;
                        beTurno.Fecha = _fecha;
                        beTurno.Hora = int.Parse(lbl_hora.Text.Split(':')[0]);
                        beTurno.Sala = lbl_sala.Text;
                        beTurno.Dia = lbl_Dia.Text;
                        beTurno.Codigo = -1;
                        beTurno.Estado = "Programado";
                        bllTurno.Guardar(beTurno);
                        bePaciente.Estado = "Activo";
                        bllPaciente.Modificar(bePaciente);
                    }

                    MessageBox.Show("Turno creado con éxito");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un paciente de la lista");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
