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

namespace TRABAJO_FINAL
{
    public partial class FormObservacionInforme : Form
    {
        BEInforme beInforme;
        public FormObservacionInforme(BEInforme beInforme)
        {
            InitializeComponent();
            this.beInforme = beInforme;
        }

        private void FormObservacionInforme_Load(object sender, EventArgs e)
        {
  
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtObservacion.Text == "")
                {
                    MessageBox.Show("Debe incluir una observación");
                }
                else
                {
                    beInforme.Observaciones = txtObservacion.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }
    }
}
