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
    public partial class FormBackUp : Form
    {
        BEUsuarioSistema beUsuario;
        BEBitacora beBitacora;
        BEUsuarioSistema beUsuarioLogueado;

        BLLUsuarioSistema bLLUsuarioSistema;

        BLLGestorBD gestorBD;

        BLLBitacora bllBitacora;
        public FormBackUp(BEUsuarioSistema user)
        {
            try
            {
                InitializeComponent();
                bLLUsuarioSistema = new BLLUsuarioSistema();
                gestorBD = new BLLGestorBD();
                bllBitacora = new BLLBitacora();
                beUsuarioLogueado = user;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }


        private void FormBackUp_Load(object sender, EventArgs e)
        {
            try
            {
                dgvBackUp.DataSource = bllBitacora.ListarTodo().Where(b => b.Detalle == "BackUp").ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar formulario\n{ex.Message}");
            }
            

        }

        private void dgvBackUp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvBackUp.SelectedRows.Count > 0) 
                {
                    beBitacora  = dgvBackUp.SelectedRows[0].DataBoundItem as BEBitacora;
                    beUsuario = bLLUsuarioSistema.ListarTodo().FirstOrDefault(u => u.Codigo == beBitacora.beUsuario.Codigo);
                    txtIdU.Text = beUsuario.Codigo.ToString();
                    txtNombreU.Text = beUsuario.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                beBitacora = new BEBitacora();
                beBitacora.Codigo = -1;
                beBitacora.FechaRegistro = (DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Trim());
                beBitacora.Detalle = "BackUp";
                beBitacora.beUsuario = beUsuarioLogueado;

                bllBitacora.Guardar(beBitacora);
                if (gestorBD.CrearBackUp()) 
                {
                    MessageBox.Show("BackUp creado con éxito");
                    dgvBackUp.DataSource = bllBitacora.ListarTodo().Where(b => b.Detalle == "BackUp").ToList();
                }
                ;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
