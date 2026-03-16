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
    public partial class FormTablaDeSalarios : Form
    {
        private BLLPsicologo bllPsicologo;
        private BEPsicologo bePsicologo;
        private BLLSalario bllSalario;


        public FormTablaDeSalarios()
        {
            InitializeComponent();
            bllPsicologo = new BLLPsicologo();
            bllSalario = new BLLSalario();

        }


        private void FormTablaDeSalarios_Load(object sender, EventArgs e)
        {
            try
            {
                //Traemos apellidos y DNI de los psicólogos
                cb_psicologo.DataSource = bllPsicologo.ListarTodo();
                cb_psicologo.ValueMember = "DNI";
                cb_psicologo.DisplayMember = "Apellido";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
              

        }

        private void cb_psicologo_SelectedIndexChanged(object sender, EventArgs e)
        {

            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            try
            {
                if (cb_psicologo.SelectedValue != null)
                {
                    List<BEPsicologo> listPsico = bllPsicologo.ListarTodo().Where(p => p.DNI.ToString() == cb_psicologo.SelectedValue.ToString()).ToList();

                    //Como solo vamos a tener un psicólogo por DNI, recorremos la lista y asignamos el psicólogo a la variable bePsicologo
                    foreach (var p in listPsico)
                    {
                        bePsicologo = p;
                    }

                    if (bePsicologo != null)
                    {
                        dgv_salarios.DataSource = null;
                        dgv_salarios.DataSource = bllSalario.ListarTodo().Where(s => s.Psicologo.DNI == bePsicologo.DNI).ToList();
                        dgv_salarios.Columns["Codigo"].Visible = false;

                    }
                    else
                    {
                        dgv_salarios.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        
      
        
        }
    }

}
