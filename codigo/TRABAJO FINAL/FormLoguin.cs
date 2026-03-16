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
using Servicios;

namespace TRABAJO_FINAL
{
    public partial class FormLoguin : Form
    {
        BEUsuarioSistema beUsuario;

        BEUsuarioSistema beUsuarioLogueado;

        BLLUsuarioSistema bllUsuario;

        BLLPermisoSimple bLLPermisoSimple;
        public FormLoguin()
        {
            InitializeComponent();
            bllUsuario = new BLLUsuarioSistema();
            bLLPermisoSimple = new BLLPermisoSimple();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GestorArchivos.CrearRecursos()) 
                {
                    //Creamos las carpetas donde se guardan los diferentes archivos
                    if (GestorArchivos.CrearCarpeta())
                    {
                        //Creamos la carpeta de permisos
                        if (bLLPermisoSimple.CrearXml())
                        {
                            //Creamos la carpeta de usuarios 
                            if (bllUsuario.CrearXml())
                            {

                                beUsuario = new BEUsuarioSistema();
                                beUsuario.Nombre = txtUsuario.Text;
                                beUsuario.Clave = txtContra.Text;

                                //Se corrobora el acceso
                                beUsuarioLogueado = bllUsuario.CorroborarAcceso(beUsuario);

                                if (beUsuarioLogueado != null)
                                {
                                    if (beUsuarioLogueado.Estado == false) { MessageBox.Show("El usuario está desactivado"); return; }

                                    Form form_menu = new FormMenu(beUsuarioLogueado);

                                    //Ocultamos este form cuando abrimos el menú
                                    this.Visible = false;
                                    txtContra.Text = "";
                                    txtUsuario.Text = "";

                                    form_menu.ShowDialog();

                                    //Lo cerramos al cerrar el menú
                                    this.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Falla en el inicio de sesión. Verifique sus datos");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Fallo en la creación del archivo de usuarios");
                            }
                        }
                        else { MessageBox.Show("Fallo uno"); }
                    }
                }
               
                else
                {
                        MessageBox.Show("Falla en el inicio de sesión. Inicie nuevamente");

                }
                
            
             

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormLoguin_Load(object sender, EventArgs e)
        {
           
        }
    }
}
