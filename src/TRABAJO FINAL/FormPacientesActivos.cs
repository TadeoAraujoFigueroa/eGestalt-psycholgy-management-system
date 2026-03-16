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
    public partial class FormPacientesActivos : Form
    {
        BLLPaciente bLLPaciente;
        BEPaciente bePaciente;

        BLLTurno bllTurno;
        BLLSesion bllSesion;
        public FormPacientesActivos()
        {
            InitializeComponent();
            bLLPaciente = new BLLPaciente();
            bllTurno = new BLLTurno();
            bllSesion = new BLLSesion();
        }

        private void FormPacientesActivos_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUsuariosActivos.DataSource = bLLPaciente.ListarActivo();
                dgvUsuariosActivos.Columns["FechaDeBaja"].Visible = false;
                dgvUsuariosActivos.Columns["Codigo"].Visible = false;
                dgvUsuariosActivos.Columns["Observaciones"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falla al cargar\n{ex.Message}");
            }
    

        }

        private void ActualizarTurnosSesiones(BEPaciente paciente)
        {
            try
            {
                bllTurno.ActualizarPaciente(paciente);
                bllSesion.ActualizarPaciente(paciente);
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
                dgvUsuariosActivos_CellDoubleClick(this, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuariosActivos.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosActivos.SelectedRows[0].DataBoundItem as BEPaciente;
                    if (bLLPaciente.Baja(bePaciente))
                    {

                        bllSesion.ActualizarPaciente(bePaciente);
                        bllTurno.ActualizarPaciente(bePaciente);
                        bllTurno.CancelarTurnosPaciente(bePaciente);
                        MessageBox.Show("Paciente dado de baja con éxito");
                        FormPacientesActivos_Load(this, null);
                    }
                    else
                    {
                        throw new Exception("Falla en la modificación");
                    }
                        
                }
                else
                {
                    MessageBox.Show("Tiene que seleccionar un paciente");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsuariosActivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuariosActivos.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosActivos.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_perfil_usuario = new FormPerfilUsuario(bePaciente);
                    form_perfil_usuario.ShowDialog();
                    FormPacientesActivos_Load(this, null);
                }


                else
                {
                    MessageBox.Show("Tiene que seleccionar un paciente");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
