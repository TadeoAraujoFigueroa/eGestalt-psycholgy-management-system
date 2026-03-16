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
    public partial class FormTurneroMensual : Form
    {
        BLLTurno bllTurno;
        BETurno beTurno;
        List<DateTime> fechasOcupadas;
        private int mesActual;

        private const int CANT_SALAS = 6;
        private const int CANT_HORAS = 8; //se contempla un horario de 9 a 17hs
        public FormTurneroMensual()
        {
            try
            {
                InitializeComponent();
                bllTurno = new BLLTurno();
                fechasOcupadas = new List<DateTime>();
                mesActual = DateTime.Now.Month;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormTurneroMensual_Load(object sender, EventArgs e)
        {
            try
            {
                calendario_turno.Font = new Font("Segoe UI", 9f);
                calendario_turno.CalendarDimensions = new Size(2, 2);
                Centrar();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

 

        private void Centrar() 
        {
            calendario_turno.Left = (ClientSize.Width - calendario_turno.Width) / 2;
            calendario_turno.Top = (ClientSize.Height - calendario_turno.Height) / 2;
        }
       

        private void calendario_turno_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                //Esta función corrobora que se realize una actualización de los días ocupados
                //Solo si existe un cambio en el mes
                if (e.Start.Month != mesActual)
                {
                    mesActual = e.Start.Month;
               
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void calendario_turno_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                Form formTurneroDiario = new FormTurneroDiarioDos(e.Start);
                formTurneroDiario.Show();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          

        }
    }

}
