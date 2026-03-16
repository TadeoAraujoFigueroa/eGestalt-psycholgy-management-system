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
    public partial class FormListaPacientes : Form
    {
        BLLPsicologo bllPsico;
        BEPsicologo bePsico;

        BLLTurno bllTurno;
        BLLSesion bLLSesion;

        //Contadores de control para la actualización de combo box
        int contador = 0;
        int contador1 = 0;
        int contador2 = 0;
        int contador3 = 0;

        bool rb_checked = false;
        public FormListaPacientes()
        {
            try
            {
                InitializeComponent();
                bllPsico = new BLLPsicologo();
                bLLSesion = new BLLSesion();
                bllTurno = new BLLTurno();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormListaPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                //Solo me trae las salas que utilizan los psicólogos existentes
                cb_sala.DataSource = bllPsico.ListarTodo().Select(p => p.Sala).Distinct().ToList();

                //Solo me trae los días que utilizan los psicólogos existentes
                cb_dia.DataSource = bllPsico.ListarTodo().Select(p => p.Dia).Distinct().ToList();

                //Solo me trae las jornadas que utilizan los psicólogos existentes
                cb_jornada.DataSource = bllPsico.ListarTodo().Select(p => p.Jornada).Distinct().ToList();

                //Solo me trae el estado que tienen los psicólogos existentes
                cb_estado.DataSource = bllPsico.ListarTodo().Select(p => p.Estado).Distinct().ToList();

                dgvPsicologos.DataSource = bllPsico.ListarTodo();

                dgvPsicologos.Columns["Codigo"].Visible = false;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            

        }

        private void FiltrarTabla(string dia, string sala, string jornada, string estado) 
        {
            try
            {
                var listaFiltrada = bllPsico.ListarTodo().AsEnumerable();

                if (sala != "Todo")
                {
                    listaFiltrada = listaFiltrada.Where(p => p.Sala == sala);
                }
                if (dia != "Todo")
                {
                    listaFiltrada = listaFiltrada.Where(p => p.Dia == dia);
                }
                if (jornada != "Todo")
                {
                    listaFiltrada = listaFiltrada.Where(p => p.Jornada == jornada);
                }
                if(estado != "Todo")
                {
                    listaFiltrada = listaFiltrada.Where(p => p.Estado == bool.Parse(estado));
                }
                dgvPsicologos.DataSource = listaFiltrada.ToList();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        private void cb_sala_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (contador == 0)
                {
                    contador++;
                    return;
                }
                else
                {
                    FiltrarTabla(cb_dia.Text, cb_sala.Text, cb_jornada.Text, cb_estado.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
                
        }

        private void cb_dia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contador1 == 0)
            {
                contador1++;
                return;
            }
            FiltrarTabla(cb_dia.Text, cb_sala.Text, cb_jornada.Text, cb_estado.Text);
        }

        private void cb_jornada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contador2 == 0)
            {
                contador2++;
                return;
            }
            FiltrarTabla(cb_dia.Text, cb_sala.Text, cb_jornada.Text, cb_estado.Text);
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPsicologos.SelectedRows.Count > 0) 
                {
                    bePsico = dgvPsicologos.SelectedRows[0].DataBoundItem as BEPsicologo;

                    Form PerfilPsicologo = new PerfilPsicologo(bePsico);
                    PerfilPsicologo.ShowDialog();

                    //Actualizamos el data grid
                    dgvPsicologos.DataSource = bllPsico.ListarTodo();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPsicologos.SelectedRows.Count > 0)
                {
                    
                    bePsico = dgvPsicologos.SelectedRows[0].DataBoundItem as BEPsicologo;

                    if(bllTurno.TurnosRegistrados(bePsico) > 0) 
                    {
                        
                        DialogResult rta = MessageBox.Show("El psicólogo tiene turnos registrados \n ¿Desea cancelar todos sus turnos?", "Eliminar psicólogo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (rta == DialogResult.Yes) 
                        {
                            if (bllTurno.CancelarTurnosPsicologo(bePsico)) 
                            {
                                MessageBox.Show("Turnos cancelados con éxito");
                            }
                            
                        }
                        else 
                        {
                            return;

                        }
                            
                    }
                    if (bllPsico.Baja(bePsico))
                    {
                        MessageBox.Show("Psicólogo modificado con éxito.");
                        dgvPsicologos.DataSource = bllPsico.ListarTodo();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el psicólogo.");
                    }
                    ;


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contador3 == 0) 
            {
                contador3++;
                return;
            }
            FiltrarTabla(cb_dia.Text, cb_sala.Text, cb_jornada.Text, cb_estado.Text);
        }

   

        private void check_box_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!rb_checked)
                {
                    FiltrarTabla("Todo", "Todo", "Todo", cb_estado.Text);
                    rb_checked = true;
                }
                else
                {
                    FiltrarTabla(cb_dia.Text, cb_sala.Text, cb_jornada.Text, cb_estado.Text);
                    rb_checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
