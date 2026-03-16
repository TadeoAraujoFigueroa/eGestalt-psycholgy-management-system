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
    public partial class FormPerfilUsuario : Form
    {
        BEPaciente bePaciente;
        BLLPaciente bllPaciente;

        BLLTurno bllTurno;
        BLLSesion bllSesion;
        public FormPerfilUsuario(BEPaciente paciente)
        {
            try
            {
                InitializeComponent();
                bllPaciente = new BLLPaciente();
                bePaciente = paciente;

                if (bePaciente.Estado == "Activo")
                {
                    btnAdmitir.Enabled = false;

                }
                if (bePaciente.Estado == "Discontinuado")
                {
                    btnNoAdm.Enabled = false;
                }

                bllTurno = new BLLTurno();
                bllSesion = new BLLSesion();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }


        private void FormPerfilUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargamos los text box con la información referida al paciente
                txtNombre.Text = bePaciente.Nombre;
                txtApellido.Text = bePaciente.Apellido;
                txtDni.Text = bePaciente.DNI.ToString();
                txtCorreo.Text = bePaciente.Correo;
                txtTel.Text = bePaciente.Telefono.ToString();
                txtEstado.Text = bePaciente.Estado;
                txtObservaciones.Text = bePaciente.Observaciones;

                if (bePaciente.Estado == "Activo")
                {
                    //No podemos admitir a una persona que ya fue admitida
                    btnAdmitir.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void ActualizarTurnosSesiones(BEPaciente paciente) 
        {
            try
            {
                bllTurno.ActualizarPaciente(paciente);
                bllSesion.ActualizarPaciente(paciente);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnAdmitir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Seguro que desea mover este paciente a la lista de pacientes activos?", "Guardando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.No) { return; }
                bePaciente.Estado = "Activo";
                if (bllPaciente.Modificar(bePaciente)) 
                {
                    ActualizarTurnosSesiones(bePaciente);

                    MessageBox.Show("Paciente admitido con éxito");
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
                DialogResult rta = MessageBox.Show("¿Seguro que desea modificar los datos de este paciente?", "Guardando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.No) { return; }
                foreach (var item in this.Controls) 
                {
                    if (item is TextBox) 
                    {
                        if (string.IsNullOrEmpty(((TextBox)item).Text))
                        {
                            throw new Exception("Por favor, complete todos los campos");
                        }
                    }
                }

                bePaciente.Estado = txtEstado.Text;
                bePaciente.Nombre = txtNombre.Text;
                bePaciente.Observaciones = txtObservaciones.Text;
                bePaciente.Apellido = txtApellido.Text;
                bePaciente.DNI = int.Parse(txtDni.Text);
                bePaciente.Telefono = long.Parse(txtTel.Text);
                bePaciente.Correo = txtCorreo.Text;

                //realizamos la prueba de modificación del dni
                var lista_paciente = bllPaciente.ListarTodo();

                foreach (var psico in lista_paciente)
                {
                    //Comparamos el objeto a modificar con el existente dentro de la base de datos (el código nunca varia)
                    if (psico.Codigo == bePaciente.Codigo)
                    {
                        //Si los DNI no son iguales, es porque se esta modificando el dni del objeto
                        if (psico.DNI != bePaciente.DNI)
                        {
                            //En ese caso llamamos a comprobar si el DNI es valido
                            if (bllPaciente.ExisteDni(bePaciente.DNI))
                            {
                                MessageBox.Show("El DNI ya se encuentra registrado");
                                return;
                            }

                        }
                    }
                }

                ActualizarTurnosSesiones(bePaciente);

                if (bllPaciente.Modificar(bePaciente))
                {
                    MessageBox.Show("Paciente modificado con éxito");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnNoAdm_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Seguro que desea mover este paciente a la lista de pacientes discontinuados?", "Guardando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.No) { return; }

                if (bllPaciente.Baja(bePaciente))
                {

                    bllSesion.ActualizarPaciente(bePaciente);
                    bllTurno.ActualizarPaciente(bePaciente);

                    //Si el usuario tuviese turnos, se cancelan
                    bllTurno.CancelarTurnosPaciente(bePaciente);
                    MessageBox.Show("Paciente dado de baja con éxito");
                    FormPerfilUsuario_Load(this, null);
                }
                else
                {
                    throw new Exception("Falla en la modificación");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
