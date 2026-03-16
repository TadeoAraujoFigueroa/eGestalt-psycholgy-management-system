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
    public partial class FormTablaTarifas : Form
    {
        BLLTarifa bllTarifa;
        BETarifa beTarifa;
        public FormTablaTarifas()
        {
            InitializeComponent();
            bllTarifa = new BLLTarifa();
        }

        private void FormTablaTarifas_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTarifas.DataSource = bllTarifa.ListarTarifas();
                dgvTarifas.Columns["RetencionUno"].Visible = false;
                dgvTarifas.Columns["RetencionDos"].Visible = false;
                dgvTarifas.Columns["RetencionDos"].Visible = false;
                dgvTarifas.Columns["Codigo"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form calcular_tarifa = new FormCalculoTarifa();
            calcular_tarifa.ShowDialog();
        }
    }
}
