using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRABAJO_FINAL
{
    public partial class FormActualizarTarifa : Form
    {
        public FormActualizarTarifa()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al inicializar componentes\n{ex.Message}");
            }
            
        }

        private void btnTarifaActual_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FormTablaTarifas();
                form.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnNvaTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FormCalculoTarifa();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void FormActualizarTarifa_Load(object sender, EventArgs e)
        {

        }
    }
}
