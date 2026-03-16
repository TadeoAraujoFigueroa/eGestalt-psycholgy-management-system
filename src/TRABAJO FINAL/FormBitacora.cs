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
    public partial class FormBitacora : Form
    {
        BLLBitacora bllBitacora;
        BEBitacora beBitacora;

        List<BEBitacora> bitacoraList;

        BLLUsuarioSistema bllUsuario;
        BEUsuarioSistema beUsuario;
        public FormBitacora()
        {
            try
            {
                InitializeComponent();
                bllBitacora = new BLLBitacora();
                bllUsuario = new BLLUsuarioSistema();
                bitacoraList = new List<BEBitacora>();
                bitacoraList = bllBitacora.ListarTodo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }


        private void FormBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                dgvBitacoras.DataSource = bitacoraList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void CargarDataGrid() 
        {
            try
            {
                if (rb_backup.Checked)
                {
                    dgvBitacoras.DataSource = bitacoraList.Where(b => b.Detalle == "BackUp").ToList();
                }
                else
                {
                    dgvBitacoras.DataSource = bitacoraList.Where(b => b.Detalle == "Restore").ToList();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void dgvBitacoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvBitacoras.SelectedRows.Count > 0) 
                {
                    beBitacora = dgvBitacoras.SelectedRows[0].DataBoundItem as BEBitacora;
                    beUsuario = bllUsuario.ListarTodo().FirstOrDefault(u => u.Codigo == beBitacora.beUsuario.Codigo);

                    txtIdU.Text = beUsuario.Codigo.ToString();
                    txtNombreU.Text = beUsuario.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rb_backup_CheckedChanged(object sender, EventArgs e)
        {
            CargarDataGrid();
        }

        private void rb_restore_CheckedChanged(object sender, EventArgs e)
        {
            CargarDataGrid();
        }
    }
}
