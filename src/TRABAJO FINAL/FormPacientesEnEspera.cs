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
    public partial class FormPacientesEnEspera : Form
    {
        BLLPaciente bllPaciente;
        BEPaciente bePaciente;
        public FormPacientesEnEspera()
        {
            try
            {
                InitializeComponent();
                bllPaciente = new BLLPaciente();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormPacientesEnEspera_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUsuariosEnEspera.DataSource = bllPaciente.ListarTodo().Where(p => p.Estado == "A autorizar").ToList();
                dgvUsuariosEnEspera.Columns["FechaDeBaja"].Visible = false;
                dgvUsuariosEnEspera.Columns["Codigo"].Visible = false;
                dgvUsuariosEnEspera.Columns["Observaciones"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falla al cargar {ex.Message}");
            }
       
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuariosEnEspera.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosEnEspera.SelectedRows[0].DataBoundItem as BEPaciente;
                    if (bllPaciente.Activar(bePaciente))
                    {
                        MessageBox.Show("Paciente dado de alta");
                        FormPacientesEnEspera_Load(this, null);
                    }
                    else
                    {
                        MessageBox.Show("Error en la modificación");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvUsuariosEnEspera_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuariosEnEspera.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosEnEspera.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_perfil_usuario = new FormPerfilUsuario(bePaciente);
                    form_perfil_usuario.ShowDialog();
                    FormPacientesEnEspera_Load(this, null);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuariosEnEspera.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosEnEspera.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_perfil_usuario = new FormPerfilUsuario(bePaciente);
                    form_perfil_usuario.ShowDialog();
                    FormPacientesEnEspera_Load(this, null);

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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
