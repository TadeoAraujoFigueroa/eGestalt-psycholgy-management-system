using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormValidarInformes : Form
    {
        ServicioDeInformes sInformes;
        BEInforme beInforme;
        public FormValidarInformes()
        {
            InitializeComponent();
            sInformes = new ServicioDeInformes();
        }

        private void FormValidarInformes_Load(object sender, EventArgs e)
        {
            try
            {
                dgInformesAValidar.DataSource = sInformes.retornarInformesParaValidar();
                dgInformesAValidar.Columns["ContenidoBytes"].Visible = false;
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInformesAValidar.SelectedRows.Count > 0) 
                {
                    beInforme = dgInformesAValidar.SelectedRows[0].DataBoundItem as BEInforme;
                    beInforme.Estado = "Rechazado";

                    
                    Form form_observacion = new FormObservacionInforme(beInforme);

                    if (form_observacion.ShowDialog() == DialogResult.OK) 
                    {
                        if (sInformes.ModificarInforme(beInforme))
                        {
                            MessageBox.Show("Informe eliminado con éxito");
                        }
                    }
                   
                    FormValidarInformes_Load(this, null);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInformesAValidar.SelectedRows.Count > 0)
                {
                    beInforme = dgInformesAValidar.SelectedRows[0].DataBoundItem as BEInforme;
                    beInforme.Estado = "Validado";
                    if (sInformes.ModificarInforme(beInforme))
                    {
                        MessageBox.Show("Informe validado con éxito");
                    }

                }

                FormValidarInformes_Load(this, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReconstruir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInformesAValidar.SelectedRows.Count > 0)
                {
                    beInforme = dgInformesAValidar.SelectedRows[0].DataBoundItem as BEInforme;

                    using (MemoryStream ms = new MemoryStream(beInforme.ContenidoBytes))
                    {
                        Image imagenGrafico = Image.FromStream(ms);

                        pictureBox1.Image = imagenGrafico;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
