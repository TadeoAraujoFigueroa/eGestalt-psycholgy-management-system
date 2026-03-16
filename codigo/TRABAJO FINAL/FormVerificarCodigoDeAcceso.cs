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
    public partial class FormVerificarCodigoDeAcceso : Form
    {
        BLLPsicologo bllPsicologo;
        BEPsicologo bePsicologo;
        public FormVerificarCodigoDeAcceso()
        {
            InitializeComponent();
            bllPsicologo = new BLLPsicologo();
        }

        private void FormVerificarCodigoDeAcceso_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCod.Text.Length > 0)
                {
                    if(bllPsicologo.ExisteCodigoDeAcceso(int.Parse(txtCod.Text)))
                    {
                      
                            bePsicologo = bllPsicologo.ListarTodo().FirstOrDefault(p => p.CodigoDeAcceso.ToString() == txtCod.Text) as BEPsicologo;
                            Form form_tabla_historias = new FormTablaHistoriasClinicas(bePsicologo);
                            form_tabla_historias.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron psicólogos con el código de acceso ingresado");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese el código de acceso");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
