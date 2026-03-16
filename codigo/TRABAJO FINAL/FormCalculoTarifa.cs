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
    public partial class FormCalculoTarifa : Form
    {
        BETarifa beTarifa;
        BLLTarifa bllTarifa;
        decimal monto;
        public FormCalculoTarifa()
        {
            try
            {
                InitializeComponent();
                bllTarifa = new BLLTarifa();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void FormCalculoTarifa_Load(object sender, EventArgs e)
        {

        }

        private void CalcularRetenciones() 
        {
            try
            {
                txtHonorario.Clear();
                txtRetencionDos.Clear();
                txtRetencionUno.Clear();

                if (decimal.TryParse(txtMonto.Text, out monto))
                {
                    txtRetencionUno.Text = (monto * 0.05m).ToString("0.00");
                    txtRetencionDos.Text = ((monto * 0.95005m) * 0.15m).ToString("0.00");
                    txtHonorario.Text = (monto - decimal.Parse(txtRetencionUno.Text) - decimal.Parse(txtRetencionDos.Text)).ToString("0.00");
                }
                else
                {
                    throw new Exception("Ingrese un formato correcto");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
          
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            CalcularRetenciones();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var c in this.Controls) 
                {
                    if(c is TextBox) 
                    {
                        if((c as TextBox).Text == "") 
                        {
                            throw new Exception("No puede haber campos vacíos");
                        }
                    }
                }
                beTarifa = new BETarifa();
                beTarifa.Total = decimal.Parse(txtMonto.Text);
                beTarifa.RetencionUno = decimal.Parse(txtRetencionUno.Text);
                beTarifa.RetencionDos = decimal.Parse(txtRetencionDos.Text);
                beTarifa.HonorarioPsicologo = decimal.Parse(txtHonorario.Text);
                beTarifa.Fecha = DateTime.Now;
                beTarifa.Codigo = -1;

                if (bllTarifa.GuardarNuevaTarifa(beTarifa))
                {
                    MessageBox.Show("Tarifa guardada con exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar la tarifa");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
