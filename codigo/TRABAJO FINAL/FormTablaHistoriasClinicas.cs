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
    public partial class FormTablaHistoriasClinicas : Form
    {
        BLLSesion bllSesion;
        BEPaciente bePaciente;
        BEPsicologo bePsicologo;
        public FormTablaHistoriasClinicas(BEPsicologo psicologo)
        {
            try
            {
                InitializeComponent();

                bePsicologo = psicologo;

                bllSesion = new BLLSesion();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }  

        private void FormTablaHistoriasClinicas_Load(object sender, EventArgs e)
        {
            try
            {
                lblPsico.Text = bePsicologo.ToString();
                //Primero, traemos las sesiones vinculadas al psicologo
                var lista_sesiones = bllSesion.ListarPorPsicologo(bePsicologo.DNI);
                //Después, a partir de esas sesiones, vinculamos a los pacientes atendidos por el psicologo
                var lista_pacientes = lista_sesiones.Select(s => s.PacienteAsociado).GroupBy(p => p.DNI)
                                                                                    .Select(g => g.First())
                                                                                    .ToList();

                //Mostramos los pacientes, ya que a partir de ellos accederemos a las historias clínicas
                dgvHistoriasClinicas.DataSource = lista_pacientes;
                dgvHistoriasClinicas.Columns["Codigo"].Visible = false;
                dgvHistoriasClinicas.Columns["Estado"].Visible = false;
                dgvHistoriasClinicas.Columns["Correo"].Visible = false;
                dgvHistoriasClinicas.Columns["FechaNacimiento"].Visible = false;
                dgvHistoriasClinicas.Columns["Telefono"].Visible = false;
                dgvHistoriasClinicas.Columns["Codigo"].Visible = false;
                dgvHistoriasClinicas.Columns["Observaciones"].Visible = false;
                dgvHistoriasClinicas.Columns["FechaDeBaja"].Visible = false;
                dgvHistoriasClinicas.Columns["FechaIngreso"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
        }

        private void btnVerHistoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistoriasClinicas.SelectedRows.Count > 0) 
                { 
                    bePaciente = dgvHistoriasClinicas.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_gestor_historia_clinica = new FormGestorHistoriaClínica(bePaciente, true);
                    form_gestor_historia_clinica.ShowDialog();
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
                if (dgvHistoriasClinicas.SelectedRows.Count > 0)
                {
                    bePaciente = dgvHistoriasClinicas.SelectedRows[0].DataBoundItem as BEPaciente;
                    Form form_gestor_historia_clinica = new FormGestorHistoriaClínica(bePaciente, false);
                    form_gestor_historia_clinica.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
