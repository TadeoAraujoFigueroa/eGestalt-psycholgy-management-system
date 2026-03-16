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
    public partial class FormPacientesDiscontinuados : Form
    {
        BLLPaciente bLLPaciente;
        BEPaciente bePaciente;
        public FormPacientesDiscontinuados()
        {
            try
            {
                InitializeComponent();
                bLLPaciente = new BLLPaciente();
            }
            catch (Exception ex)
            {

                MessageBox.Show(($"Falla al inicializar componentes\n{ex.Message}"));
            }
            
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuariosInactivos.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosInactivos.SelectedRows[0].DataBoundItem as BEPaciente;
                    if (bLLPaciente.Activar(bePaciente))
                    {
                        MessageBox.Show("Paciente dado de alta");
                        FormPacientesDiscontinuados_Load(this, null);
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

        private void FormPacientesDiscontinuados_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUsuariosInactivos.DataSource = bLLPaciente.ListarTodo().FindAll(p => p.Estado == "Discontinuado");
                dgvUsuariosInactivos.Columns["Codigo"].Visible = false;
                dgvUsuariosInactivos.Columns["Observaciones"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falla al cargar\n{ex.Message}");
            }
         
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuariosInactivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsuariosInactivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuariosInactivos.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosInactivos.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_perfil_usuario = new FormPerfilUsuario(bePaciente);
                    form_perfil_usuario.ShowDialog();
                    FormPacientesDiscontinuados_Load(this, null);

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

        private void btnDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuariosInactivos.SelectedRows.Count > 0)
                {
                    bePaciente = dgvUsuariosInactivos.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_perfil_usuario = new FormPerfilUsuario(bePaciente);
                    form_perfil_usuario.ShowDialog();
                    FormPacientesDiscontinuados_Load(this, null);
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
