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
    public partial class FormCuponesSolicitados : Form
    {
        BLLCupon bllCupon;
        BECuponDePago bECuponDePago;

        BLLPaciente bllPaciente;
        BEPaciente bePaciente;
        public FormCuponesSolicitados()
        {
            try
            {
                InitializeComponent();
                bllPaciente = new BLLPaciente();
                bllCupon = new BLLCupon();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
             
        }

        private void FormCuponesSolicitados_Load(object sender, EventArgs e)
        {
            try
            {
                //Los cupones sin vencimiento corresponden a aquellos que fueron solicitados
                //El vencimiento se establece una vez generado el cupón
                dgv_cupones.DataSource = bllCupon.ListarCuponesSinVencimiento();
                dgv_cupones.Columns["Nombre"].Visible = false;
                dgv_cupones.Columns["FechaVencimiento"].Visible = false;
                dgv_cupones.Columns["Codigo"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         

        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgv_cupones.SelectedRows.Count > 0) 
                {
                    bECuponDePago = dgv_cupones.SelectedRows[0].DataBoundItem as BECuponDePago;
                    Form form_generacion_cupon = new FormGeneracionCuponDePago(bECuponDePago);
                    form_generacion_cupon.Show();
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
