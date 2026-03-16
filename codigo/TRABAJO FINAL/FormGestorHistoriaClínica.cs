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
using Servicios;

namespace TRABAJO_FINAL
{
    public partial class FormGestorHistoriaClínica : Form
    {
        BEPaciente bePaciente;

        HistoriaClinicaService sHistoriaClinica;

        private string _estado;

        public FormGestorHistoriaClínica(BEPaciente paciente, bool readOnly)
        {
            try
            {
                InitializeComponent();
                sHistoriaClinica = new HistoriaClinicaService();

                //Establecemos las imagenes
                tNegrita.Image = Image.FromFile(GestorArchivos.ObtenerRutaArchivoImg("n.png"));
                tItalic.Image = Image.FromFile(GestorArchivos.ObtenerRutaArchivoImg("i.png"));
                tSub.Image = Image.FromFile(GestorArchivos.ObtenerRutaArchivoImg("u.png"));

                bePaciente = paciente;

                //Llamamos al método que se encarga de crear la historia clínica de no existir y de actualizar el estado
                sHistoriaClinica.LeerHistoria(bePaciente.Nombre, bePaciente.Apellido, out _estado);

                ActualizarBloqueoEdicion();

                //Esto significa que se abrió solo para ver
                if (readOnly)
                {
                    rtbHistoriaClinica.ReadOnly = readOnly;
                    btnCambiarEstado.Enabled = false;
                    btnFinalizar.Enabled = false;
                    btnMas.Enabled = false;
                    btnGuardar.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void FormGestorHistoriaClínica_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"Historia clínica - {bePaciente.ToString()}";

                rtbHistoriaClinica.Font = new Font("Segoe UI", 10);

                //Cargamos el archivo a partir de la ruta que nos retorna el método Leer Historia
                rtbHistoriaClinica.LoadFile(sHistoriaClinica.LeerHistoria(bePaciente.Nombre, bePaciente.Apellido, out _estado), RichTextBoxStreamType.RichText);
                if(_estado == "Abierta") { btnCambiarEstado.Enabled = false; }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(sHistoriaClinica.GuardarHistoria(bePaciente.Nombre, bePaciente.Apellido, rtbHistoriaClinica)) 
                {
                    MessageBox.Show("Historia clínica guardada con éxito");
                    ActualizarBloqueoEdicion();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void rtbHistoriaClinica_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void ActualizarBloqueoEdicion()
        {
            try
            {
                bool bloqueado = _estado.Equals("Cerrada", StringComparison.OrdinalIgnoreCase);

                rtbHistoriaClinica.ReadOnly = bloqueado;

                btnGuardar.Enabled = !bloqueado;

                btnMas.Enabled = !bloqueado;

                btnFinalizar.Enabled = !bloqueado;

                btnCambiarEstado.Enabled = bloqueado;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    
        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                rtbHistoriaClinica.AppendText($"\n=============================\n");
                rtbHistoriaClinica.AppendText($"📅 Sesión del {DateTime.Now:dd/MM/yyyy}\n");
                rtbHistoriaClinica.AppendText($"Observaciones:\n\n");
                rtbHistoriaClinica.ScrollToCaret();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
       
        private void CambiarEstilo(FontStyle estilo)
        {
            try
            {
                if (rtbHistoriaClinica.SelectionFont != null)
                {
                    FontStyle nuevoEstilo = rtbHistoriaClinica.SelectionFont.Style ^ estilo;
                    rtbHistoriaClinica.SelectionFont = new Font(rtbHistoriaClinica.SelectionFont, nuevoEstilo);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CambiarEstilo(FontStyle.Bold);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CambiarEstilo(FontStyle.Italic);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CambiarEstilo(FontStyle.Underline);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Seguro que desea finalizar la historia clínica?", "Finalizando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.No) { return; }

                sHistoriaClinica.CambiarEstado(bePaciente.Nombre, bePaciente.Apellido, "Cerrada");
                //Actualizamos 
                rtbHistoriaClinica.LoadFile(sHistoriaClinica.LeerHistoria(bePaciente.Nombre, bePaciente.Apellido, out _estado), RichTextBoxStreamType.RichText);

                ActualizarBloqueoEdicion();

                MessageBox.Show("Historia clínica finalizada", "Finalizada", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Seguro que desea re-abrir la historia clínica?", "Abriendo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.No) { return; }

                sHistoriaClinica.CambiarEstado(bePaciente.Nombre, bePaciente.Apellido, "Abierta");
                _estado = "Abierta";
                ActualizarBloqueoEdicion();
                MessageBox.Show("Historia clínica abierta nuevamente", "Finalizado", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
