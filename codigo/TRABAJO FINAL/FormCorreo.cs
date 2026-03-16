using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BLL;
using BE;
using System.Diagnostics.Contracts;

namespace TRABAJO_FINAL
{
    public partial class FormCorreo : Form
    {
        BLLPaciente bllPaciente;
        BLLPsicologo bllPsicologo;

        List<string> correos_todos;
        List<string> correos_pacientes;
        List<string> correos_psicologos;

        BEPlantillaCorreo bePlantilla;
        BLLPlantilla bllPlantilla;

        ServicioDeNotificaciones mensajero;
        //Flags que nos sirven para evitar validaciones al momento de cargar el form
        private bool _cargando;
     
        public FormCorreo()
        {
            try
            {
                InitializeComponent();

                bllPaciente = new BLLPaciente();
                bllPsicologo = new BLLPsicologo();
                bllPlantilla = new BLLPlantilla();
                mensajero = new ServicioDeNotificaciones();
                correos_todos = new List<string>();
                correos_pacientes = new List<string>();
                correos_psicologos = new List<string>();

                //Guardamos los correos de toda la red
                correos_todos.Add("(Seleccionar todos");
                correos_todos.AddRange(bllPaciente.ListarActivo().Select(p => p.Correo).ToList());
                correos_todos.AddRange(bllPsicologo.ListarTodo().Select(p => p.Correo).ToList());

                //Guardamos los correos de los pacientes
                correos_pacientes.Add("(Seleccionar todos");
                correos_pacientes.AddRange(bllPaciente.ListarActivo().Select(p => p.Correo).ToList());

                //Guardamos los correos de los psicólogos
                correos_psicologos.Add("(Seleccionar todos)");
                correos_psicologos.AddRange(bllPsicologo.ListarTodo().Select(p => p.Correo).ToList());
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Falla al inicializar componentes\n{ex.Message}");
            }
            

        }

        private void FormCorreo_Load(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                //Posibilitamos la opción de seleccionar todos los mails
                cb_todos.DataSource = correos_todos;
                cb_psicologos.DataSource = correos_psicologos;
                cb_pacientes.DataSource = correos_pacientes;
                //Inicializamos el dgv con las plantillas
                dgvPlantillas.DataSource = bllPlantilla.ListarTodo().Where(p => p.Estado == "Habilitada").ToList();

                if (dgvPlantillas.Rows.Count > 1)
                {
                    dgvPlantillas.Columns["Estado"].Visible = false;
                    dgvPlantillas.Columns["Codigo"].Visible = false;
                }



                rb_uno.Checked = true;
                /*
                cb_todos.Items.AddRange(correos_todos.ToArray());

                cb_pacientes.Items.Add("(Seleccionar todos)"); cb_pacientes.Items.AddRange(correos_pacientes.ToArray());

                cb_psicologos.Items.Add("(Seleccionar todos)"); cb_psicologos.Items.AddRange(correos_psicologos.ToArray());

                */
                _cargando = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falla al cargar el formulario\n{ex.Message}");
            }
          


        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Está seguro que desea enviar el correo?", "Enviando correo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.Yes) 
                {
                   if(txtAsunto.Text == "" || txtCuerpo.Text == ""|| txtDestinatario.Text == "")
                    {
                        MessageBox.Show("Todos los campos deben estar completos");
                        return;
                    }
                    string remitente = "tadeoaraujof@gmail.com";
                    string contrasenia = "ogle elmh xncd elbq";

                    string asunto = txtAsunto.Text;
                    string cuerpo = txtCuerpo.Text;

                    string destinatario = txtDestinatario.Text;
                    //Lo dividimos por si fueron elegidos mutiples destinatarios
                    string[] destinatarios = destinatario.Split(';');

           
                   
                    if (mensajero.EnviarNotificacion(remitente, contrasenia, asunto, cuerpo, destinatario, destinatarios))
                    {
                        MessageBox.Show("¡Mensaje enviado correctamente!");
                    }

                }


            } catch (Exception ex) { MessageBox.Show($"Falla al enviar el correo\n{ex.Message}"); }
            
        }

       

        private void SeleccionarDestinatario()
        {
            try
            {
                if (_cargando) {  return; }
                if (rb_uno.Checked)
                {
                    if (cb_todos.SelectedIndex == 0)
                    {
                       
                            // Seleccionó "(Seleccionar todos)"
                            string todos = string.Join(";", correos_todos);
                            if(todos.Count() > 20) 
                            {
                            todos = todos.Substring(19, todos.Length - 19);
                            txtDestinatario.Text = todos;
                            }                       
                            
                        
                    }
                       
                    else
                    {
                        txtDestinatario.Text = cb_todos.SelectedItem.ToString();
                    }
                }

                if (rb_dos.Checked)
                {
                    if (cb_pacientes.SelectedIndex == 0)
                    {
                            // Seleccionó "(Seleccionar todos)"
                            string todos = string.Join(";", correos_pacientes);
                        if (todos.Count() > 20)
                        {
                            todos = todos.Substring(19, todos.Length - 19);
                            txtDestinatario.Text = todos;
                        }


                    }
                    else
                    {
                        txtDestinatario.Text = cb_pacientes.SelectedItem.ToString();
                    }
                }
                if (rb_tres.Checked)
                {
                    if (cb_psicologos.SelectedIndex == 0)
                    {
                        
                            // Seleccionó "(Seleccionar todos)"
                            string todos = string.Join(";", correos_psicologos);
                             if (todos.Count() > 20)
                             {
                            todos = todos.Substring(19, todos.Length - 19);
                            txtDestinatario.Text = todos;
                             }


                    }
                    else
                    {
                        txtDestinatario.Text = cb_psicologos.SelectedItem.ToString();
                    }
                }
                if (rb_uno.Checked == false && rb_dos.Checked == false && rb_tres.Checked == false)
                {
                    MessageBox.Show("Debe seleccionar una opción para elegir destinatario");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
        private void cb_todos_SelectedIndexChanged(object sender, EventArgs e)
        {

            SeleccionarDestinatario();
            
        }

        private void cb_pacientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            SeleccionarDestinatario();
        }

        private void cb_psicologos_SelectedIndexChanged(object sender, EventArgs e)
        {

            SeleccionarDestinatario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls) 
            {
                if (c is TextBox) 
                {
                    ((TextBox)c).Clear();
                }
            }
        }

        private void rb_uno_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionarDestinatario();
        }

        private void rb_dos_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionarDestinatario();
        }

        private void rb_tres_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionarDestinatario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPlantillas.SelectedRows.Count > 0) 
                {
                    bePlantilla = dgvPlantillas.SelectedRows[0].DataBoundItem as BEPlantillaCorreo;

                    if (bllPlantilla.Baja(bePlantilla))
                    {
                        MessageBox.Show("Planilla eliminada con éxito");
                        dgvPlantillas.DataSource = bllPlantilla.ListarTodo().Where(p => p.Estado == "Habilitada").ToList();
                    }
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPlantillas.SelectedRows.Count > 0)
                {
                    bePlantilla = dgvPlantillas.SelectedRows[0].DataBoundItem as BEPlantillaCorreo;
                   if(bllPlantilla.Modificar(bePlantilla)) 
                   {
                        MessageBox.Show("Planilla modificada con éxito");
                        dgvPlantillas.DataSource = bllPlantilla.ListarTodo().Where(p => p.Estado == "Habilitada").ToList();
                    }
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNvoAsunto.Text == "" || txtNvoMensaje.Text == "") 
                {
                    throw new Exception("Debe llenar los campos de asunto y mensaje");
                }

                bePlantilla = new BEPlantillaCorreo();
                bePlantilla.Codigo = -1;
                bePlantilla.Estado = "Habilitada";
                bePlantilla.Asunto = txtNvoAsunto.Text;
                bePlantilla.Mensaje = txtNvoMensaje.Text;

                if (bllPlantilla.Guardar(bePlantilla))
                {
                    MessageBox.Show("Planilla modificada con éxito");
                    dgvPlantillas.DataSource = bllPlantilla.ListarTodo().Where(p => p.Estado == "Habilitada").ToList();
                }

                txtNvoMensaje.Text = "";
                txtNvoAsunto.Text = "";
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dgvPlantillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPlantillas.SelectedRows.Count > 0) 
                {
                    bePlantilla = dgvPlantillas.SelectedRows[0].DataBoundItem as BEPlantillaCorreo;
                    txtAsunto.Text = bePlantilla.Asunto;
                    txtCuerpo.Text = bePlantilla.Mensaje;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPlantillas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlantillas_CellClick(this, null);
        }
    }
}
