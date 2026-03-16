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
    public partial class FornAltaPacientes : Form
    {
        BEPaciente bePaciente;
        BLLPaciente bLLPaciente;
    
        public FornAltaPacientes()
        {
            try
            {
                InitializeComponent();
                bLLPaciente = new BLLPaciente();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al inicializar componentes\n♀{ex.Message}");
            }
            

        }

      
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var c in this.Controls)
                { 
                    if (c is TextBox) 
                    {
                            if(string.IsNullOrEmpty(((TextBox)c).Text))
                            {
                            throw new Exception("Por favor, complete todos los campos");
                            }
                    }
                }   
                DialogResult rta = MessageBox.Show("¿Está seguro que desea guardar los datos en el sistema?", "Cargando paciente...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rta == DialogResult.Yes) 
                {
                    //Tomamos los datos del paciente a crear
                    var nombre = txtNom.Text;
                    var apellido = txtApe.Text;
                    var dni = int.Parse(txtDni.Text);

                    if (bLLPaciente.ExisteDni(dni))
                    {
                        rta =MessageBox.Show("El paciente ya se encuentra registrado en la base de datos. ¿Desea ver su información?", "Paciente exitente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta == DialogResult.Yes) 
                        {
                            try
                            {
                                    bePaciente = bLLPaciente.ListarTodo().FirstOrDefault(p => p.DNI.ToString() == dni.ToString());
                                    Form form_perfil_usuario = new FormPerfilUsuario(bePaciente);
                                    form_perfil_usuario.Show();
                                    return;
                                
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Operación cancelada. No se creó el paciente.");
                            return;
                        }
                    }
                    var tel = long.Parse(txtTel.Text);
                    var fecha_nac = dtp.Value;
                    var correo = txtCorreo.Text;

                    bePaciente = new BEPaciente(nombre, apellido, dni, tel, fecha_nac, correo, DateTime.Now);
                    bePaciente.Codigo = -1; //Se asigna el codigo automaticamente en el MPP
                    bePaciente.Estado = "A autorizar";
                    bePaciente.Observaciones = txtObservaciones.Text;
  

                    if (bLLPaciente.Guardar(bePaciente)) { MessageBox.Show("Paciente creado con exito"); btnCancelar_Click(this, null); }
                    else { MessageBox.Show("No se pudo crear el paciente"); }
                }
             
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                }
            }
        }


        #region "FUNCIONES NO UTILIZADAS"
        private void FornAltaPacientes_Load(object sender, EventArgs e)
        {
        }

        private void rbSinMutual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void cb_obra_social_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
