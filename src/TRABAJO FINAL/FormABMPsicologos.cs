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

    public partial class FormABMPsicologos : Form
    {
        BLLPsicologo bllPsicologo;
        BEPsicologo bePsicologo;

        //Nos brinda toda la información para rellenar los combo box
        BLLDatos bllDatos;

        //Para generar el código de acceso
        Random rn;
        public FormABMPsicologos()
        {
            try
            {
                InitializeComponent();
                bllPsicologo = new BLLPsicologo();
                rn = new Random();
                bllDatos = new BLLDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al inicializar componentes \n {ex.Message}");
            }
            
        }

        private void FormABMPsicologos_Load(object sender, EventArgs e)
        {
            try
            {
                listDia.DataSource = bllDatos.retornarDias().Select(d => d.Nombre).ToList();
                listSala.DataSource = bllDatos.retornarSalas().Select(s => s.Nombre).ToList();
                listJornada.DataSource = bllDatos.retornarJornada().Select(j => j.Nombre).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar el formulario \n{ex.Message}");
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpiamos los text box
                foreach (var c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        (c as TextBox).Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private int ValidarCodigoDeAcceso() 
        {
            try
            {
                //Genera una credencial aleatoria de 4 dígitos
                var codigoDeAcceso = rn.Next(0, 9999);

                if (bllPsicologo.ExisteCodigoDeAcceso(codigoDeAcceso))
                {
                    //Si ya existe, vuelve a llamar a la función
                    ValidarCodigoDeAcceso();
                }

                return codigoDeAcceso;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var c in this.Controls)
                {
                    if (c is TextBox && (c as TextBox).Text == "")
                    {
                        throw new Exception("Todos los campos deben completarse");
                    }
                }

                var nombre = txtNom.Text;
                var apellido = txtApe.Text;

                //VALIDAMOS EL DNI
                var dni = int.Parse(txtDni.Text);

                if (bllPsicologo.ExisteDni(dni)) 
                {
                    MessageBox.Show("El DNI ingresado ya se encuentra registrado en el sistema");
                    return;
                }

                var tel = long.Parse(txtTel.Text);
                var fecha_nac = dtp.Value;
                var corriente = txtCorriente.Text;

                //VALIDAMOS QUE NO EXISTA UN PSICÓLOGO EN EL MISMO DÍA, JORNADA Y SALA
                var dia = listDia.SelectedItem.ToString();
                var jornada = listJornada.SelectedItem.ToString();
                var sala = listSala.SelectedItem.ToString();

                 
                if (bllPsicologo.ExistePsicologo(jornada, dia, sala) != null)
                {
                    MessageBox.Show("Ya existe un psicólogo en ese día, jornada y sala.");
                    return;
                }

                var correo = txtCorreo.Text;

                //Se genera una credencial aleatoria de 4 dígitos
                var codigoDeAcceso = ValidarCodigoDeAcceso();

              
                bePsicologo = new BEPsicologo(nombre, apellido, dni, tel, fecha_nac, corriente, dia, jornada, sala, true, correo, int.Parse(codigoDeAcceso.ToString()), DateTime.Now);

                bePsicologo.Codigo = -1;

                if (bllPsicologo.Guardar(bePsicologo))
                {
                    MessageBox.Show("Psicólogo creado con éxito");
                    btnCancelar_Click(this, null);
                }
                else 
                {
                    throw new Exception("Fallo al cargar psicólogo");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
