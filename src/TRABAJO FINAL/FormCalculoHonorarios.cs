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
    public partial class FormCalculoHonorarios : Form
    {
        BLLSalario bllSalario;
        BESalario beSalario;

        BLLPsicologo bllPsicologo;
        BEPsicologo bePsicologo;

        BLLTarifa bllTarifa;

        decimal monto_tarifa;
        
        public FormCalculoHonorarios()
        {
            try
            {
                InitializeComponent();
                bllSalario = new BLLSalario();
                bllPsicologo = new BLLPsicologo();
                bllTarifa = new BLLTarifa();
                monto_tarifa = bllTarifa.RetornarTarifaActual().Total;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }

        private void FormCalculoHonorarios_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = bllPsicologo.ListarTodo().Where(p => p.Estado == true).ToList();

                //Ocultamos las columnas que no nos interesan ver
                dataGridView1.Columns["Codigo"].Visible = false;
                dataGridView1.Columns["Telefono"].Visible = false;
                dataGridView1.Columns["Corriente"].Visible = false;
                dataGridView1.Columns["Dia"].Visible = false;
                dataGridView1.Columns["Sala"].Visible = false;
                dataGridView1.Columns["Jornada"].Visible = false;
                dataGridView1.Columns["FechaNacimiento"].Visible = false;
                dataGridView1.Columns["Correo"].Visible = false;
                dataGridView1.Columns["CodigoDeAcceso"].Visible = false;
                dataGridView1.Columns["FechaIngreso"].Visible = false;

                //Tarifa por sesión
                txtMonto.Text = monto_tarifa.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count > 0) 
                {

                    foreach(var c in this.Controls) 
                    {
                        if (c is TextBox) 
                        {
                            if((c as TextBox).Text == "") 
                            {
                                throw new Exception("Debe completar todos los campos");
                            }
                        }
                    }
     
                    bePsicologo = dataGridView1.SelectedRows[0].DataBoundItem as BEPsicologo;
                    beSalario = new BESalario();
                    beSalario.Codigo = -1;
                    beSalario.Fecha = DateTime.Now;
                    beSalario.Monto = decimal.Parse(txtHonorario.Text);
                    beSalario.Psicologo = bePsicologo;

                    if (bllSalario.Guardar(beSalario))
                    {
                        MessageBox.Show("El salario ha sido registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (var c in this.Controls)
                        {
                            if (c is TextBox)
                            {
                                (c as TextBox).Text = "";
                           
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al registrar el salario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void calcular_honorario(int sesiones, decimal retencion_uno, decimal retencion_dos) 
        {
            try
            {
                //Monto de la tarifa por la cantidad de sesiones realizadas
                decimal monto_total = monto_tarifa * sesiones;

                //La retención uno representa el X por ciento del monto total
                txtRetencionUno.Text = (monto_total * retencion_uno).ToString("N");

                //La retención dos representa el X por ciento del total menos la retención uno
                txtRetencionDos.Text = ((monto_total * retencion_dos) * 0.15m).ToString("N");

                //El monto a percibir es el monto total menos las dos retenciones
                txtHonorario.Text = (((monto_total - decimal.Parse(txtRetencionUno.Text)) - decimal.Parse(txtRetencionDos.Text))).ToString("N");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
    
        }

        private void obtener_datos() 
        {
            try
            {
                if (txtSesionesRealizadas.Text != "")
                {
                    //Se activa el cálculo solo cuando los textos de porcentaje estan completos
                    if (txt_por_dos.Text != "" && txt_por_uno.Text != "")
                    {

                        //Se calcula en base a las sesiones realizadas el monto total a percibir y las retenciones
                        int sesiones_realizadas = int.Parse(txtSesionesRealizadas.Text);

                        decimal retencion_uno = decimal.Parse(txt_por_uno.Text)/100;

                        decimal retencion_dos = decimal.Parse(txt_por_dos.Text)/100;

                        calcular_honorario(sesiones_realizadas, retencion_uno, retencion_dos);

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtSesionesRealizadas_TextChanged(object sender, EventArgs e)
        {
            //función que obtiene las variables para calcular el honorario
            obtener_datos();
        }

        private void txt_por_uno_TextChanged(object sender, EventArgs e)
        {
            //función que obtiene las variables para calcular el honorario
            obtener_datos();
        }

        private void txt_por_dos_TextChanged(object sender, EventArgs e)
        {
            //función que obtiene las variables para calcular el honorario
            obtener_datos();
        }
    }
}
