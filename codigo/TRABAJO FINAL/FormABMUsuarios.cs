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
using Seguridad;

namespace TRABAJO_FINAL
{
    public partial class FormABMUsuarios : Form
    {

        BLLUsuarioSistema bllUsuarioSistema;

        BEUsuarioSistema bEUsuarioSistema;

        bool check = false;
        public FormABMUsuarios()
        {
            InitializeComponent();
            bllUsuarioSistema = new BLLUsuarioSistema();
        }

        private void FormABMUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = bllUsuarioSistema.ListarTodo().Where(u => u.Estado == true).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar el formulario\n{ex.Message}");
            }
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuarioSistema.ValidarCreacion(txtNombre.Text))
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre. Intente nuevamente");
                    return;
                }

                bEUsuarioSistema = new BEUsuarioSistema();
                bEUsuarioSistema.Codigo = -1;
                bEUsuarioSistema.Nombre = txtNombre.Text;

           
                bEUsuarioSistema.Clave = Encriptacion.Encriptar(txtClave.Text);
                
             
                bEUsuarioSistema.Estado = true;

              
                if (bllUsuarioSistema.Guardar(bEUsuarioSistema)) 
                {
                    MessageBox.Show("Usuario creado con éxito");
                    FormABMUsuarios_Load(this, null);
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

                if(dgvUsuarios.SelectedRows.Count > 0) 
                {
                    bEUsuarioSistema = dgvUsuarios.SelectedRows[0].DataBoundItem as BEUsuarioSistema;

                    ModificarUsuario(bEUsuarioSistema);
                
                }
                else if(txtNombre.Text != null && txtClave.Text != "")
                {
                    if(cb_encriptar.Checked == true) 
                    {
                        bEUsuarioSistema = bllUsuarioSistema.ListarTodo().FirstOrDefault(u => Encriptacion.Desencriptar(u.Clave) == txtClave.Text);         
                    }
                    else 
                    {
                        bEUsuarioSistema = bllUsuarioSistema.ListarTodo().FirstOrDefault(u => u.Clave == txtClave.Text);
                    }
                    //Esto significa que existe el usuario, por lo que vamos a modificar
                    if (bEUsuarioSistema != null)
                    {
                        ModificarUsuario(bEUsuarioSistema);
                    }

                }
                else 
                {
                    MessageBox.Show("Seleccione un usuario existente para modificar");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ModificarUsuario(BEUsuarioSistema usuario) 
        {
            try
            {
                //Chequeamos si la modificación se esta haciendo sobre la clave

                //Si 'f' es verdadero, significa que la contraseña no se mofifico
                bool f = bllUsuarioSistema.ListarTodo().Exists(u => u.Clave == usuario.Clave);

                //Si no hubo coincidencia, la contraseña fue modificada y se procede a encriptarla
                if (!f)
                {
                    usuario.Clave = Encriptacion.Encriptar(bEUsuarioSistema.Clave);

                }
                //Realizamos la modificación
                if (bllUsuarioSistema.Modificar(usuario))
                {
                    MessageBox.Show("Usuario modificado con éxito");
                    FormABMUsuarios_Load(this, null);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al modificar al usuario\n {ex.Message}");
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    bEUsuarioSistema = dgvUsuarios.SelectedRows[0].DataBoundItem as BEUsuarioSistema;

                    if (bllUsuarioSistema.Baja(bEUsuarioSistema))
                    {
                        MessageBox.Show("Usuario eliminado con éxito");
                        FormABMUsuarios_Load(this, null);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    bEUsuarioSistema = dgvUsuarios.SelectedRows[0].DataBoundItem as BEUsuarioSistema;

                    txtNombre.Text = bEUsuarioSistema.Nombre;
                    txtClave.Text = bEUsuarioSistema.Clave;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cb_encriptar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(cb_encriptar.Checked == false) 
                {
                    txtClave.Text = Encriptacion.Encriptar(txtClave.Text);
                }
                else 
                {
                    txtClave.Text = Encriptacion.Desencriptar(txtClave.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {   
                if (check == false)
                {
                    dgvUsuarios.DataSource = null;
                    dgvUsuarios.DataSource = bllUsuarioSistema.ListarTodo().Where(u => u.Estado == false).ToList();
                    check = true;
                }
                else
                {
                    dgvUsuarios.DataSource = null;
                    dgvUsuarios.DataSource = bllUsuarioSistema.ListarTodo().Where(u => u.Estado == true).ToList();
                    check = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
